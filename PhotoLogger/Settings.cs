﻿using System;
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
            //get list of EN Notebooks
            if (PhotoLogger.Properties.Settings.Default.ENEnabled)
            {
                ENNotebookList.Items.AddRange(Evernote.ENManager.GetInstance().GetNotebooks().ToArray());
                ENNotebookList.DisplayMember = "Name";
                ENNotebookList.SelectedText = PhotoLogger.Properties.Settings.Default.ENNotebook;
            }
        }

        private void ENNotebookList_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(ENNotebookList.SelectedItem);
            PhotoLogger.Properties.Settings.Default.ENNotebook = ((EvernoteSDK.ENNotebook)ENNotebookList.SelectedItem).Name;
            _dirty = true;
        }
    }
}
