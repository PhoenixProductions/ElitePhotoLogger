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
    public partial class TwitterCaptcha : Form
    {
        public string CaptchaText;
        public TwitterCaptcha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CaptchaText = textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
