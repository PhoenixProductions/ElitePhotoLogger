using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace PhotoLogger.Twitter
{
    public abstract class BaseTwitter: ITwitter
    {
        static int twitterErrorCount = 0;

        bool _initialised = false;
        bool _inhibit = false;
		bool _loggedin = false;

        public bool Inhibit
        {
            get { return _inhibit; }
            set { _inhibit = value; }
        }
		public bool LoggedIn {
			get { return _loggedin; }
		}
        public void Initialise()
        {
            System.Diagnostics.Debug.WriteLine(@"Initialising twitter sub system");
            Tweetinvi.TwitterCredentials.SetCredentials(PhotoLogger.Properties.Settings.Default.TwitterCredentials);
			if (PhotoLogger.Properties.Settings.Default.TwitterCredentials == null) {
				System.Diagnostics.Debug.WriteLine (@"No credentials");
				_initialised = false;
				return;
			}
            try
            {
                System.Diagnostics.Debug.WriteLine(@"Checking logged in");
                Tweetinvi.User.GetLoggedUser();
				_loggedin = true;
                _initialised = true;
                System.Diagnostics.Debug.WriteLine(@"Initialising twitter sub system...ok");
            }
            catch (Tweetinvi.Core.Exceptions.TwitterNullCredentialsException ex)
            {
				_loggedin = false;
                if (twitterErrorCount > 2)
                {
                    _initialised = false;

                    throw ex;
                }
                twitterErrorCount++;
                if (!this.Authorise())
                {
                    throw ex;
                }
            }
        }

        public bool Authorise()
        {
			System.Diagnostics.Debug.WriteLine (@"Authorising");
            Tweetinvi.Core.Interfaces.Credentials.ITemporaryCredentials tCred = Tweetinvi.CredentialsCreator.GenerateApplicationCredentials(
                   this.GetConsumerKey(),
                   this.GetSharedSecret());

            string url = Tweetinvi.CredentialsCreator.GetAuthorizationURL(
                tCred
                );
            System.Diagnostics.Process.Start(url);
            TwitterCaptcha c = new TwitterCaptcha();
            if (c.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Diagnostics.Debug.WriteLine(@"Authorising with twitter");
                Tweetinvi.Core.Interfaces.oAuth.IOAuthCredentials nCred = Tweetinvi.CredentialsCreator.GetCredentialsFromVerifierCode(c.CaptchaText, tCred);
                Tweetinvi.TwitterCredentials.SetCredentials(nCred);
                PhotoLogger.Properties.Settings.Default.TwitterCredentials = (Tweetinvi.WebLogic.OAuthCredentials)nCred;
                PhotoLogger.Properties.Settings.Default.Save();
				System.Diagnostics.Debug.WriteLine (@"Authorised");
				_loggedin = true;
                return true;
            }
			System.Diagnostics.Debug.WriteLine (@"Not Authorised");
            return false;
        }
		/// <summary>
		/// Revoke Twitter authorisation
		/// </summary>
		public void DeAuthorise() {
			_loggedin = false;
			PhotoLogger.Properties.Settings.Default.TwitterCredentials = null;
			Tweetinvi.TwitterCredentials.SetCredentials (null);
			PhotoLogger.Properties.Settings.Default.Save();
		}
        abstract public string GetConsumerKey();
            /*
        {
            throw new NotImplementedException();
        }*/

        abstract public string GetSharedSecret();
        /*
        {
            throw new NotImplementedException();
        }*/
        public void Post(string text)
        {
            if (_initialised && !_inhibit)
            {
                Tweetinvi.Core.Interfaces.ITweet tweet = Tweetinvi.Tweet.CreateTweet(text);
                //string mediaUrl = tweet.Entities.Medias.First().MediaURL;
                tweet.Publish();
            }
            else
            {
                if (!_initialised)
                {
                    System.Diagnostics.Debug.WriteLine(@"Not initialised");
                }
                if (_inhibit)
                {
                    System.Diagnostics.Debug.WriteLine(@"Inhibited");
                }
            }
        }
        public bool PostMedia(string filepath)
        {
            if (_initialised && !_inhibit)
            {
                if (!System.IO.File.Exists(filepath))
                {
                    throw new System.IO.FileNotFoundException(@"Not found", filepath);
                }
                System.Diagnostics.Debug.WriteLine(Tweetinvi.User.GetLoggedUser().ToString());
                
                Tweetinvi.TwitterCredentials.SetCredentials(PhotoLogger.Properties.Settings.Default.TwitterCredentials);
                byte[] media = ResizeImageAsBytes(filepath);
                
                //Tweetinvi.Core.Interfaces.ITweet tweet = Tweetinvi.Tweet.CreateTweetWithMedia(@"ED Photo Logger: ", media);
                
                Tweetinvi.Core.Interfaces.ITweet tweet = Tweetinvi.Tweet.CreateTweet(PhotoLogger.Properties.Settings.Default.TweetText);
                object o = tweet.AddMedia(media);

                tweet.Publish();
                return true;
            }
            else
            {
                if (!_initialised)
                {
                    System.Diagnostics.Debug.WriteLine(@"Not initialised");
                }
                if (_inhibit)
                {
                    System.Diagnostics.Debug.WriteLine(@"Inhibited");
                }
            }
            return false;
        }

        /// <summary>
        /// Set the width that images are resized to
        /// </summary>
        const int IMAGEWIDTH = 1024;
        byte[] ResizeImageAsBytes(string fp)
        {
            System.Drawing.Image i = System.Drawing.Image.FromFile(fp);

            if (i.Width >= IMAGEWIDTH)  // only resize if larger than set size
            {
                //This was an attempt to do an on-the-fly resize
                float aspect = (float)i.Width / (float)i.Height;
                float newheight = (int)(IMAGEWIDTH / aspect);
                System.Drawing.Rectangle dr = new System.Drawing.Rectangle(0, 0, IMAGEWIDTH, (int)Math.Ceiling(newheight));    //probably want to make this an option
                System.Drawing.Bitmap i2 = new System.Drawing.Bitmap(IMAGEWIDTH, (int)Math.Ceiling(newheight));
                i2.SetResolution(i.HorizontalResolution, i.VerticalResolution);
                using (var graphics = System.Drawing.Graphics.FromImage(i2))
                {
                    graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                    using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                    {
                        wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                        graphics.DrawImage(i, dr, 0, 0, i.Width, i.Height, System.Drawing.GraphicsUnit.Pixel, wrapMode);
                    }
                }
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                i2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                i2.Save(System.IO.Path.Combine(@"C:\Users\michael\Documents\FlightLog-debug\twitter", @"twitter.png"), System.Drawing.Imaging.ImageFormat.Png);
                return ms.GetBuffer();
            }
            return System.IO.File.ReadAllBytes(fp);
        }
    }
}
