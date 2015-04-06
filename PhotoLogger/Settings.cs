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
    public partial class Settings : Form
    {
        bool _dirty = false;
        public Settings()
        {
            InitializeComponent();
        }
        Form1 _host;

        public Settings(Form1 host): this()
        {
            _host = host;

        }

        private void EvernoteEnabled_CheckedChanged(object sender, EventArgs e)
        {
            PhotoLogger.Properties.Settings.Default.ENEnabled = EvernoteEnabled.Checked;

            ENNotebookList.Enabled = EvernoteEnabled.Checked;
            _dirty = true;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_dirty)
            {
                PhotoLogger.Properties.Settings.Default.Save();
                _dirty = false;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
		{
			loadEnConfiguration ();
			loadTwitterConfiguration ();
		}
		void loadEnConfiguration() {
			//get list of EN Notebooks
			if (Evernote.ENManager.GetInstance ().Mode != Evernote.ENManager.EverNoteMode.Disabled &
			             PhotoLogger.Properties.Settings.Default.ENEnabled) {
				ENNotebookList.BeginUpdate ();
				this.loadNotebooks ();
                
				ENNotebookList.EndUpdate ();
			} else {
				EvernoteEnabled.Enabled = false;
				ENNotebookList.Enabled = false;
			}

		}

		void loadTwitterConfiguration() {
			// Load twitter settings
            CheckAutoPostTwitter.Checked = PhotoLogger.Properties.Settings.Default.AutoPostTwitter;

			this.twitterStatus.Text = "Not Logged in";
			if (_host.TWITTER.LoggedIn) {
				Tweetinvi.Core.Interfaces.ILoggedUser u = Tweetinvi.User.GetLoggedUser ();
				this.twitterStatus.Text = "Logged in as " + u.ScreenName;
				BtnConfigureTwitter.Text = @"Logout";
			} else {
				this.twitterStatus.Text = "Not Logged in";
				BtnConfigureTwitter.Text = @"Configure";
			}

            if (PhotoLogger.Properties.Settings.Default.AutoPostTwitter)
            {
                this.TxtTweetText.Text = PhotoLogger.Properties.Settings.Default.TweetText;
            }
            
        }

        void loadNotebooks() {
            ENNotebookList.Items.Clear();
            ENNotebookList.Items.AddRange(Evernote.ENManager.GetInstance().GetNotebooks().ToArray());
            ENNotebookList.DisplayMember = "Name";
            ENNotebookList.SelectedText = PhotoLogger.Properties.Settings.Default.ENNotebook;
        }


        private void ENNotebookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(ENNotebookList.SelectedItem);
            PhotoLogger.Properties.Settings.Default.ENNotebook = ((EvernoteSDK.ENNotebook)ENNotebookList.SelectedItem).Name;
            _dirty = true;
        }

        private void BtnLogoutEvernote_Click(object sender, EventArgs e)
        {
            if (Evernote.ENManager.GetInstance().Session().IsAuthenticated)
            {
                
            }
        }

        private void EvernoteEnabled_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!Evernote.ENManager.GetInstance().Session().IsAuthenticated)
            {
                Evernote.ENManager.GetInstance().Session().AuthenticateToEvernote();
                ENNotebookList.BeginUpdate();
                this.loadNotebooks();
                ENNotebookList.EndUpdate();
            }
           
        }

        private void ENNotebookList_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void CheckAutoPostTwitter_CheckedChanged(object sender, EventArgs e)
        {
            PhotoLogger.Properties.Settings.Default.AutoPostTwitter = CheckAutoPostTwitter.Checked;
            _dirty = true;
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
			System.Diagnostics.Debug.WriteLine (@"starting login process");
			if(_host.TWITTER.LoggedIn) 
            {
				/*
                PhotoLogger.Properties.Settings.Default.TwitterCredentials = null;
                PhotoLogger.Properties.Settings.Default.Save();
*/
				_host.TWITTER.DeAuthorise ();
				this.loadTwitterConfiguration ();
            } else {
				System.Diagnostics.Debug.WriteLine (@"Attempting to authorise");
                _host.TWITTER.Authorise();
				this.loadTwitterConfiguration ();
            }
        }

        private void TxtTweetText_TextChanged(object sender, EventArgs e)
        {
            PhotoLogger.Properties.Settings.Default.TweetText = TxtTweetText.Text;
        }
    }
}
