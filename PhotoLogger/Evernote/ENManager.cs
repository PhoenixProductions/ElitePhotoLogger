using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvernoteSDK;

namespace PhotoLogger.Evernote
{
    /// <summary>
    /// Manages interaction with Evernote
    /// </summary>
    public class ENManager
    {
        static ENManager _instance;

        public static ENManager Initialise(EverNoteMode mode)
        {
            if (_instance == null) {
                _instance = new ENManager(mode);    
            }
            
            return _instance;
        }
        public static ENManager GetInstance()
        {
            return _instance;
        }
        public enum EverNoteMode
        {
            Disabled = -1,
            Normal = 0,
            Personal
        }
#if DEBUG
        string _enHost = "sandbox.evernote.com";
#else
        string _enHost = "";
#endif
        EverNoteMode _mode;

        public EverNoteMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        private ENManager(EverNoteMode mode)
        {
            if (mode == EverNoteMode.Personal)
            {
                _mode = EverNoteMode.Personal;
                ENSession.SetSharedSessionDeveloperToken(
                    PhotoLogger.Properties.Settings.Default.ENPersonalToken,
                    PhotoLogger.Properties.Settings.Default.ENNoteStoreUrl
                    );
            }
            else if (mode== EverNoteMode.Normal)
            {
                _mode = EverNoteMode.Normal;
                IENDevTokens tokenClass = new ENDevTokens();
                ENSession.SetSharedSessionConsumerKey(tokenClass.GetConsumerKey(), tokenClass.GetSharedSecret(), _enHost);
            }
            else
            {
                _mode = EverNoteMode.Disabled;
            }

            if (_mode != EverNoteMode.Disabled)
            {
                if (ENSession.SharedSession.IsAuthenticated == false)
                {
                    ENSession.SharedSession.AuthenticateToEvernote();
                }
            }
        }
        public void SaveLog(string title, string content)
        {
            this.SaveLog(title, content, null);
        }
        public void SaveLog(string title, string content, System.Drawing.Image[] attachments) {
            ENNote n = new ENNote();
            string targetNotebook = PhotoLogger.Properties.Settings.Default.ENNotebook;
            ENNotebook nb = ENSession.SharedSession.ListNotebooks().Where(b => b.Name == targetNotebook).FirstOrDefault();

            if (nb != null)
            {

            }

            n.Title = title;
            n.Content = ENNoteContent.NoteContentWithString(content);
            if (attachments != null && attachments.Length > 0)
            {
                foreach (System.Drawing.Image i in attachments){
                    ENResource r = new ENResource(i);
                    n.AddResource(r);
                }
	        }
            ENNoteRef enref = ENSession.SharedSession.UploadNote(n, nb);
        }
        public List<ENNotebook> GetNotebooks()
        {
            return ENSession.SharedSession.ListNotebooks();
            
        }
        public ENSession Session()
        {
            return ENSession.SharedSession;
        }
    }
}
