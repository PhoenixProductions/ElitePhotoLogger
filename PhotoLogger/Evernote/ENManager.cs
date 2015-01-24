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
        
        /// <summary>
        /// Set the width that images are resized to
        /// </summary>
        const int IMAGEWIDTH = 1024;

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
        /// <summary>
        /// Save a log entry with no images
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void SaveLog(string title, string content)
        {
            this.SaveLog(title, content, null);
        }
        /// <summary>
        /// Save log with images
        /// </summary>
        /// <param name="title">The Entry's title</param>
        /// <param name="content">Textual content</param>
        /// <param name="attachmentPaths">Any images that should be attached</param>
        public void SaveLog(string title, string content, string[] attachmentPaths) {
            ENNote n = new ENNote();
            string targetNotebook = PhotoLogger.Properties.Settings.Default.ENNotebook;
            ENNotebook nb = ENSession.SharedSession.ListNotebooks().Where(b => b.Name == targetNotebook).FirstOrDefault();

            if (nb != null)
            {

            }

            n.Title = title;
            n.Content = ENNoteContent.NoteContentWithString(content);
            if (attachmentPaths != null && attachmentPaths.Length > 0)
            {
                int counter = 1;
                foreach (string fp in attachmentPaths){
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
#if (NoEN)
                        string tmpdir = System.IO.Path.Combine(Form1._workingdir, "tmp");
                        if (!System.IO.Directory.Exists(tmpdir))
                        {
                            System.IO.Directory.CreateDirectory(tmpdir);
                        }
                        i2.Save(System.IO.Path.Combine(tmpdir, "tmpimage" + counter + ".png"), System.Drawing.Imaging.ImageFormat.Png);
#endif
                        //ENResource r = new ENResource(i);
                        ENResource r = new ENResource(ms.ToArray(), "image/png");//, System.IO.Path.GetFileName(fp));
                        n.AddResource(r);
                    }
                    else // Otherwise we just use as is.
                    {
                        ENResource r = new ENResource(i);
                        n.AddResource(r);
                    }
                    i.Dispose();
                    i = null;
                    counter++;
                }
	        }
#if (!NoEN) 
            ENNoteRef enref = ENSession.SharedSession.UploadNote(n, nb);
#else 
            System.Diagnostics.Debug.WriteLine("Evernote request suppressed by NoEN compile flag.");
#endif
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
