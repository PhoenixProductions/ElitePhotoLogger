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
        public Settings()
        {
            InitializeComponent();
        }

        private void EvernoteEnabled_CheckedChanged(object sender, EventArgs e)
        {
            PhotoLogger.Properties.Settings.Default.ENEnabled = EvernoteEnabled.Checked;
            PhotoLogger.Properties.Settings.Default.Save();

        }
    }
}
