using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoLogger
{
    public partial class Form1 : Form
    {
        public static string _logbasedir = "";
        public static string _logdir = "";
        public static string _workingdir = "";
        //string _elitelogs = @"C:\Users\michael\AppData\Local\Frontier_Developments\Products\FORC-FDEV-D-1001\Logs";
        public string _elitePhotos = "";//@"C:\Users\michael\Pictures\Frontier Developments\Elite Dangerous";
        bool _running = false;

        Evernote.ENManager EN = null;
        Twitter.Twitter TWITTER = null;

        public Form1()
        {
            InitializeComponent();
            //watch for settings changing
            
        }
        void toggle()
        {

            if (!_running)
            {
                System.Diagnostics.Process[] potentialElites = System.Diagnostics.Process.GetProcessesByName("EliteDangerous32");
                if (potentialElites.Length == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Elite not running");
                    return;
                }
            }
            _running = !_running;
            if (_running)
            {
                System.Diagnostics.Debug.WriteLine("Starting");
                startMonitoring();
                timer1.Enabled = true;
                btnControl.Text = "Stop";
            }
            else {
                
                System.Diagnostics.Debug.WriteLine("Stopping");
                
                timer1.Enabled = false;
                
                stopMonitoring();
                btnControl.Text = "Start";

                //clean up when we indicate a session is over?
            }
            System.Diagnostics.Debug.WriteLine("Done");
        }

        void startMonitoring()
        {
            fileSystemWatcher1.Path =_elitePhotos;
            fileSystemWatcher1.EnableRaisingEvents = true;

        }
        void stopMonitoring()
        {
            fileSystemWatcher1.EnableRaisingEvents = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Originally intended to capture a screen shot on regular intervals so that 
        /// the pilot doesn't have to.
        /// 
        /// If we reinstate this we may have to name auto-captures differently so that we can 
        /// differentiate them and filter them out when writing the log entry, especially if we're offering the
        /// option to upload images to evernote 
        /// </remarks>
        void capture()
        {
            return;
            System.Diagnostics.Debug.WriteLine("Sending Screen Cap");
            SendKeys.Send("{F10}");
            System.Diagnostics.Debug.WriteLine("Done");
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            this.toggle();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            capture();
        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            bool store = false;
            bool convert = true;
            string filename = System.IO.Path.GetFileName(e.FullPath);
            
            if (store)
            {
                //System.IO.File.Copy(e.FullPath, System.IO.Path.Combine(_selectedPath, filename));
            }
            if (convert) {
                string convertedFilename = System.IO.Path.GetFileNameWithoutExtension(e.FullPath) + ".png";
                System.Drawing.Image src = System.Drawing.Image.FromFile(e.FullPath);
                string savefile = System.IO.Path.Combine(_workingdir, convertedFilename);
                src.Save(savefile, System.Drawing.Imaging.ImageFormat.Png);
                src.Dispose();
                src = null;
                if (PhotoLogger.Properties.Settings.Default.AutoPostTwitter)
                {
                    PostTweet(savefile);

                }
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (PhotoLogger.Properties.Settings.Default.ENEnabled)
            {
                System.Diagnostics.Debug.WriteLine("Enabling evernote");
                EN = Evernote.ENManager.Initialise((Evernote.ENManager.EverNoteMode)PhotoLogger.Properties.Settings.Default.ENMode);
                    
            }
            else
            {
                EN = Evernote.ENManager.Initialise(Evernote.ENManager.EverNoteMode.Disabled);
            }
            _elitePhotos = System.IO.Path.GetFullPath(Environment.ExpandEnvironmentVariables(PhotoLogger.Properties.Settings.Default.EDPhotoDir));
#if DEBUG
            _logbasedir = System.IO.Path.GetFullPath(Environment.ExpandEnvironmentVariables(PhotoLogger.Properties.Settings.Default.FlightLogBaseDir + "-debug"));
#else
            _logbasedir =  System.IO.Path.GetFullPath(Environment.ExpandEnvironmentVariables(PhotoLogger.Properties.Settings.Default.FlightLogBaseDir));
#endif
            _logdir = System.IO.Path.Combine(_logbasedir, "log");
            _workingdir = System.IO.Path.Combine(_logbasedir, "input");
            if (!System.IO.Directory.Exists(_logbasedir))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(_logbasedir);
                }
                catch (System.IO.IOException ex)
                {
                    throw ex;
                }
            }
            if (!System.IO.Directory.Exists(_logdir))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(_logdir);
                }
                catch (System.IO.IOException ex)
                {
                    throw ex;
                }
            }
            if (!System.IO.Directory.Exists(_workingdir))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(_workingdir);
                }
                catch (System.IO.IOException ex)
                {
                    throw ex;
                }
            }
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogProcessor p = new LogProcessor(EN);
            p.ShowDialog(this);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                //save window position
                PhotoLogger.Properties.Settings.Default.MainWindowStartLocation = this.Location;
                
                //perform clean ups?
            }

            PhotoLogger.Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Clean up at the [start?|end?]of a run
        /// </summary>
        void CleanUp()
        {

        }
        static int twitterErrorCount = 0;
        void PostTweet(string filepath)
        {
            if (TWITTER == null) {
                return;
            }
            //try to load existing credentials
            //PhotoLogger.Properties.Settings.Default.TwitterCredentials = (Tweetinvi.WebLogic.OAuthCredentials)nCred;
            Tweetinvi.TwitterCredentials.SetCredentials(PhotoLogger.Properties.Settings.Default.TwitterCredentials);
            try
            {
                System.Diagnostics.Debug.WriteLine(@"Checking logged in");
                Tweetinvi.User.GetLoggedUser();

                System.Diagnostics.Debug.WriteLine(@"Posting " + filepath);
                Tweetinvi.Tweet.PublishTweet("test");
                /*byte[] media = System.IO.File.ReadAllBytes(filepath);
                Tweetinvi.Core.Interfaces.ITweet tweet = Tweetinvi.Tweet.CreateTweetWithMedia("", media);
                tweet.Publish();
                 */ 

            }
            catch (Tweetinvi.Core.Exceptions.TwitterNullCredentialsException ex)
            {
                if (twitterErrorCount > 2) {
                    throw ex;
                }
                twitterErrorCount++;
                Tweetinvi.Core.Interfaces.Credentials.ITemporaryCredentials tCred = Tweetinvi.CredentialsCreator.GenerateApplicationCredentials(
                   TWITTER.GetConsumerKey(),
                   TWITTER.GetSharedSecret());

                string url = Tweetinvi.CredentialsCreator.GetAuthorizationURL(
                    tCred
                    );
                System.Diagnostics.Process.Start(url);
                TwitterCaptcha c = new TwitterCaptcha();
                if (c.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                    System.Diagnostics.Debug.WriteLine(@"Authorising with twitter");
                    Tweetinvi.Core.Interfaces.oAuth.IOAuthCredentials nCred = Tweetinvi.CredentialsCreator.GetCredentialsFromVerifierCode(c.CaptchaText,tCred);
                    Tweetinvi.TwitterCredentials.SetCredentials(nCred);
                    PhotoLogger.Properties.Settings.Default.TwitterCredentials = (Tweetinvi.WebLogic.OAuthCredentials) nCred;
                    //PhotoLogger.Properties.Settings.Default.TwitterAccessToken = nCred.AccessToken;
                    //PhotoLogger.Properties.Settings.Default.TwitterAccessSecret = nCred.AccessTokenSecret;
                    PhotoLogger.Properties.Settings.Default.Save();
                    PostTweet(filepath);//retry
                }
                else
                {
                    throw ex;
                }
            }
            /*
            byte[] media = System.IO.File.ReadAllBytes(filepath);
            Tweetinvi.Core.Interfaces.ITweet tweet = Tweetinvi.Tweet.CreateTweetWithMedia("", media);
            tweet.Publish();
             */
        }

        private void testTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostTweet(@"C:\Users\michael\Documents\FlightLog\input\Screenshot_0058.png");
        }


    }
}
