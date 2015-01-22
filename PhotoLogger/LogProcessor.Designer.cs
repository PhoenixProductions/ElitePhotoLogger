namespace PhotoLogger
{
    partial class LogProcessor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ListPhotos = new System.Windows.Forms.CheckedListBox();
            this.RemoveOnSave = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEntry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtLogTitle = new System.Windows.Forms.TextBox();
            this.BtnSaveLogEntry = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LogDatePicker = new System.Windows.Forms.DateTimePicker();
            this.Statusbar = new System.Windows.Forms.StatusStrip();
            this.UploadingProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Statusbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListPhotos);
            this.splitContainer1.Panel1.Controls.Add(this.RemoveOnSave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(919, 529);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 0;
            // 
            // ListPhotos
            // 
            this.ListPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListPhotos.FormattingEnabled = true;
            this.ListPhotos.Location = new System.Drawing.Point(3, 3);
            this.ListPhotos.Name = "ListPhotos";
            this.ListPhotos.Size = new System.Drawing.Size(127, 469);
            this.ListPhotos.TabIndex = 2;
            this.ListPhotos.SelectedIndexChanged += new System.EventHandler(this.ListPhotos_SelectedIndexChanged);
            // 
            // RemoveOnSave
            // 
            this.RemoveOnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveOnSave.AutoSize = true;
            this.RemoveOnSave.Enabled = false;
            this.RemoveOnSave.Location = new System.Drawing.Point(12, 500);
            this.RemoveOnSave.Name = "RemoveOnSave";
            this.RemoveOnSave.Size = new System.Drawing.Size(117, 17);
            this.RemoveOnSave.TabIndex = 1;
            this.RemoveOnSave.Text = "Remove On Save?";
            this.RemoveOnSave.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.TxtEntry);
            this.splitContainer2.Size = new System.Drawing.Size(783, 529);
            this.splitContainer2.SplitterDistance = 332;
            this.splitContainer2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(783, 332);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entry";
            // 
            // TxtEntry
            // 
            this.TxtEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtEntry.Location = new System.Drawing.Point(17, 26);
            this.TxtEntry.Multiline = true;
            this.TxtEntry.Name = "TxtEntry";
            this.TxtEntry.Size = new System.Drawing.Size(751, 155);
            this.TxtEntry.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Log Title:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TxtLogTitle
            // 
            this.TxtLogTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLogTitle.Location = new System.Drawing.Point(70, 12);
            this.TxtLogTitle.Name = "TxtLogTitle";
            this.TxtLogTitle.Size = new System.Drawing.Size(756, 20);
            this.TxtLogTitle.TabIndex = 2;
            this.TxtLogTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BtnSaveLogEntry
            // 
            this.BtnSaveLogEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveLogEntry.Location = new System.Drawing.Point(832, 12);
            this.BtnSaveLogEntry.Name = "BtnSaveLogEntry";
            this.BtnSaveLogEntry.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveLogEntry.TabIndex = 3;
            this.BtnSaveLogEntry.Text = "Save Log Entry";
            this.BtnSaveLogEntry.UseVisualStyleBackColor = true;
            this.BtnSaveLogEntry.Click += new System.EventHandler(this.BtnSaveLogEntry_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Log Date:";
            // 
            // LogDatePicker
            // 
            this.LogDatePicker.Location = new System.Drawing.Point(73, 48);
            this.LogDatePicker.Name = "LogDatePicker";
            this.LogDatePicker.Size = new System.Drawing.Size(141, 20);
            this.LogDatePicker.TabIndex = 5;
            // 
            // Statusbar
            // 
            this.Statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadingProgress});
            this.Statusbar.Location = new System.Drawing.Point(0, 606);
            this.Statusbar.Name = "Statusbar";
            this.Statusbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Statusbar.Size = new System.Drawing.Size(919, 22);
            this.Statusbar.TabIndex = 6;
            // 
            // UploadingProgress
            // 
            this.UploadingProgress.Name = "UploadingProgress";
            this.UploadingProgress.Size = new System.Drawing.Size(180, 16);
            this.UploadingProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.UploadingProgress.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // LogProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 628);
            this.Controls.Add(this.Statusbar);
            this.Controls.Add(this.LogDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnSaveLogEntry);
            this.Controls.Add(this.TxtLogTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LogProcessor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Write Log Entry";
            this.Load += new System.EventHandler(this.LogProcessor_Load);
            this.Shown += new System.EventHandler(this.LogProcessor_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Statusbar.ResumeLayout(false);
            this.Statusbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox TxtEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtLogTitle;
        private System.Windows.Forms.Button BtnSaveLogEntry;
        private System.Windows.Forms.CheckBox RemoveOnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker LogDatePicker;
        private System.Windows.Forms.CheckedListBox ListPhotos;
        private System.Windows.Forms.StatusStrip Statusbar;
        private System.Windows.Forms.ToolStripProgressBar UploadingProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}