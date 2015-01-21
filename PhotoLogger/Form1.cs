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
        string _logbasedir = "";
        string _logdir = "";
        string _workingdir = "";
        //string _elitelogs = @"C:\Users\michael\AppData\Local\Frontier_Developments\Products\FORC-FDEV-D-1001\Logs";
        string _elitePhotos = "";//@"C:\Users\michael\Pictures\Frontier Developments\Elite Dangerous";
        bool _running = false;

        public Form1()
        {
            InitializeComponent();
            _elitePhotos =  System.IO.Path.GetFullPath(Environment.ExpandEnvironmentVariables(PhotoLogger.Properties.Settings.Default.EDPhotoDir));
            _logbasedir =  System.IO.Path.GetFullPath(Environment.ExpandEnvironmentVariables(PhotoLogger.Properties.Settings.Default.FlightLogBaseDir));
            _logdir = System.IO.Path.Combine(_logbasedir, "log");
            _workingdir = System.IO.Path.Combine(_logbasedir, "input");
            if (!System.IO.Directory.Exists(_logbasedir))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(_logbasedir);
                }
                catch(System.IO.IOException e)
                {
                    throw e;
                }
            } 
            if (!System.IO.Directory.Exists(_logdir))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(_logdir);
                }
                catch (System.IO.IOException e)
                {
                    throw e;
                }
            }
            if (!System.IO.Directory.Exists(_workingdir))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(_workingdir);
                }
                catch (System.IO.IOException e)
                {
                    throw e;
                }
            }
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
                src.Save(System.IO.Path.Combine(_workingdir, convertedFilename), System.Drawing.Imaging.ImageFormat.Png);
                src.Dispose();
                src = null;
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogProcessor p = new LogProcessor();
            p.Show();
        }


    }
}
