﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PhotoLogger
{
    public partial class LogProcessor : Form
    {
        string _workingdir = "";
        const int eliteyearadjust = 1286;
        Evernote.ENManager EN = null;

        public LogProcessor()
        {
            InitializeComponent();
            _workingdir = Form1._workingdir;
            /*
                System.IO.Path.Combine(
                Environment.ExpandEnvironmentVariables(PhotoLogger.Properties.Settings.Default.FlightLogBaseDir),
                "input");]*/

        }
        public LogProcessor(Evernote.ENManager EN): this()
        {
            this.EN = EN;
        }

        private void LogProcessor_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(_workingdir))
            {
                // no working directory
            }
        }

        private void LogProcessor_Shown(object sender, EventArgs e)
        {
            UpdateListOfPhotos();
            if (ListPhotos.Items.Count >0 &  TxtLogTitle.Text == "")
            {
                PhotoListItem first = (PhotoListItem) ListPhotos.Items[0];
                DateTime elitetime = first.Timestamp.AddYears(eliteyearadjust);
                LogDatePicker.Value = first.Timestamp;
                TxtLogTitle.Text = "Pilot's Log " + elitetime.ToString("D");
            }
            else if (ListPhotos.Items.Count == 0 & TxtLogTitle.Text == "")
            {
                DateTime elitetime = DateTime.Now.AddYears(eliteyearadjust);
                LogDatePicker.Value = elitetime;
                TxtLogTitle.Text = "Pilot's Log " + elitetime.ToString("D");
            }
            if (ListPhotos.Items.Count > 0)
            {
                ListPhotos.SelectedIndex = 0;
            }
        }
        void UpdateListOfPhotos()
        {
            
            ListPhotos.BeginUpdate();
            ListPhotos.Items.Clear();
            if (System.IO.Directory.Exists(_workingdir)){
                System.IO.DirectoryInfo i = new System.IO.DirectoryInfo(_workingdir);
                System.IO.FileInfo[] files = i.GetFiles("*.png").OrderBy(p => p.LastWriteTime).ToArray();
                System.Diagnostics.Debug.WriteLine(files.Length + " files found in "+ _workingdir);
                foreach (FileInfo file in files)
                {
                    System.Diagnostics.Debug.Write(file.Name);
                    PhotoListItem pi = new PhotoListItem(file.FullName, file.LastWriteTime);
                    ListPhotos.Items.Add(pi);
                
                }
                i = null;
                files = null;
            }
            ListPhotos.EndUpdate();
            ListPhotos.DisplayMember = "Timestamp";
            ListPhotos.ValueMember = "Fullpath";
        }
        void DisplayItem(PhotoListItem item)
        {
            System.Drawing.Image i;
            byte[] imageBytes = System.IO.File.ReadAllBytes(item.Fullpath);
            //= System.Drawing.Image.FromFile(item.Fullpath);
            using (System.IO.MemoryStream ms = new MemoryStream(imageBytes))
            {
                i = System.Drawing.Image.FromStream(ms);
                pictureBox1.Image = i;
            }
            
            //pictureBox1.Load(item.Fullpath);
            //i.Dispose();
            //i = null;
        }
        void SaveLog()
        {
            this.BtnSaveLogEntry.Enabled = false;
            UploadingProgress.Visible = true;
            
            //we always write a local text log at present
            {
                string _logdir = System.IO.Path.Combine(
                    Environment.ExpandEnvironmentVariables(PhotoLogger.Properties.Settings.Default.FlightLogBaseDir),
                    "log");
                if (!Directory.Exists(_logdir))
                {
                    try
                    {
                        Directory.CreateDirectory(_logdir);
                    }
                    catch (IOException e)
                    {
                        throw e;
                    }
                }
                string filepath = Path.Combine(_logdir, "LogEntry_" + LogDatePicker.Value.ToString("yyyy-MM-dd") + ".txt");
                bool pad = false;
                if (File.Exists(filepath))
                {
                    pad = true;
                }
                StreamWriter f = new StreamWriter(filepath, true);
                //File.CreateText(filepath);
                if (pad)
                {
                    f.WriteLine();
                    f.WriteLine(new string('=', TxtLogTitle.Text.Length));
                }
                f.WriteLine(TxtLogTitle.Text);
                f.WriteLine(new string('=', TxtLogTitle.Text.Length));
                f.WriteLine(TxtEntry.Text);
                f.Close();

            }
            if (EN.Mode != Evernote.ENManager.EverNoteMode.Disabled){ 
                backgroundWorker1.RunWorkerAsync();
                //this.backgroundWorker1_RunWorkerCompleted(this, new RunWorkerCompletedEventArgs(null, null, false));
            }
            else
            {
                UploadingProgress.Visible = false;
                this.BtnSaveLogEntry.Enabled = true;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            if (RemoveOnSave.Checked) {
                foreach (PhotoListItem i in ListPhotos.Items)
                {
                    try
                    {
                        File.Delete(i.Fullpath);
                    }
                    catch (IOException e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                    }
                }
                UpdateListOfPhotos();
            }


        }
        private void ListPhotos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayItem((PhotoListItem)ListPhotos.SelectedItem);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnSaveLogEntry_Click(object sender, EventArgs e)
        {
            SaveLog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (EN.Mode != Evernote.ENManager.EverNoteMode.Disabled)
            {
                if (ListPhotos.CheckedItems.Count > 0)
                {
                    List<string> paths = new List<string>();
                    foreach (PhotoListItem i in ListPhotos.CheckedItems)
                    {
                        paths.Add(i.Fullpath);
                    }
                    EN.SaveLog(TxtLogTitle.Text, TxtEntry.Text, paths.ToArray());
                }
                else
                {
                    EN.SaveLog(TxtLogTitle.Text, TxtEntry.Text);
                }
                //TODO allow selected screenshots to be saved along side
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            UploadingProgress.Visible = false;
            this.BtnSaveLogEntry.Enabled = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListPhotos.BeginUpdate();
            foreach (PhotoListItem i in ListPhotos.CheckedItems)
            {
                if (i.Fullpath.Equals(pictureBox1.ImageLocation))
                {
                    pictureBox1.Image = null;
                }
                 
                try
                {
                    System.Diagnostics.Debug.WriteLine(@"Removing " + i.Fullpath);
                    File.Delete(i.Fullpath);
                }
                catch (IOException ex)
                {
                    System.Diagnostics.Debug.WriteLine(@"Failed to remove: " +ex.Message);
                }
            }
            UpdateListOfPhotos();
            ListPhotos.EndUpdate(); ;
        }

        private void MenuListPhotos_Opening(object sender, CancelEventArgs e)
        {
            if (ListPhotos.CheckedItems.Count == 0)
            {
                DeleteCheckedPhotos.Visible = false;
            }
            else { DeleteCheckedPhotos.Visible = true;  }
        }



        private void LogProcessor_KeyUp(object sender, KeyEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(e.KeyCode);
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


    }
    class PhotoListItem
    {
        public PhotoListItem(string path, DateTime timestamp)
        {
            this._fullpath = path;
            this._timestamp = timestamp;
        }
        string _fullpath;

        public string Fullpath
        {
            get { return _fullpath; }
            set { _fullpath = value; }
        }
        DateTime _timestamp;

        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

    }
}
