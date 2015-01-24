namespace PhotoLogger
{
    partial class Settings
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
            this.SettingsTabContainer = new System.Windows.Forms.TabControl();
            this.TabGeneralSettings = new System.Windows.Forms.TabPage();
            this.TabEvernote = new System.Windows.Forms.TabPage();
            this.BtnLogoutEvernote = new System.Windows.Forms.Button();
            this.ENNotebookList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EvernoteEnabled = new System.Windows.Forms.CheckBox();
            this.SettingsTabContainer.SuspendLayout();
            this.TabEvernote.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsTabContainer
            // 
            this.SettingsTabContainer.Controls.Add(this.TabGeneralSettings);
            this.SettingsTabContainer.Controls.Add(this.TabEvernote);
            this.SettingsTabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsTabContainer.Location = new System.Drawing.Point(0, 0);
            this.SettingsTabContainer.Name = "SettingsTabContainer";
            this.SettingsTabContainer.SelectedIndex = 0;
            this.SettingsTabContainer.Size = new System.Drawing.Size(547, 261);
            this.SettingsTabContainer.TabIndex = 0;
            // 
            // TabGeneralSettings
            // 
            this.TabGeneralSettings.Location = new System.Drawing.Point(4, 22);
            this.TabGeneralSettings.Name = "TabGeneralSettings";
            this.TabGeneralSettings.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneralSettings.Size = new System.Drawing.Size(539, 235);
            this.TabGeneralSettings.TabIndex = 0;
            this.TabGeneralSettings.Text = "General";
            this.TabGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // TabEvernote
            // 
            this.TabEvernote.Controls.Add(this.BtnLogoutEvernote);
            this.TabEvernote.Controls.Add(this.ENNotebookList);
            this.TabEvernote.Controls.Add(this.label1);
            this.TabEvernote.Controls.Add(this.EvernoteEnabled);
            this.TabEvernote.Location = new System.Drawing.Point(4, 22);
            this.TabEvernote.Name = "TabEvernote";
            this.TabEvernote.Size = new System.Drawing.Size(539, 235);
            this.TabEvernote.TabIndex = 1;
            this.TabEvernote.Text = "Evernote";
            this.TabEvernote.UseVisualStyleBackColor = true;
            // 
            // BtnLogoutEvernote
            // 
            this.BtnLogoutEvernote.Location = new System.Drawing.Point(392, 10);
            this.BtnLogoutEvernote.Name = "BtnLogoutEvernote";
            this.BtnLogoutEvernote.Size = new System.Drawing.Size(139, 44);
            this.BtnLogoutEvernote.TabIndex = 6;
            this.BtnLogoutEvernote.Text = "Logout From Evernote";
            this.BtnLogoutEvernote.UseVisualStyleBackColor = true;
            this.BtnLogoutEvernote.Visible = false;
            this.BtnLogoutEvernote.Click += new System.EventHandler(this.BtnLogoutEvernote_Click);
            // 
            // ENNotebookList
            // 
            this.ENNotebookList.FormattingEnabled = true;
            this.ENNotebookList.Location = new System.Drawing.Point(99, 38);
            this.ENNotebookList.Name = "ENNotebookList";
            this.ENNotebookList.Size = new System.Drawing.Size(192, 21);
            this.ENNotebookList.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "NoteBook";
            // 
            // EvernoteEnabled
            // 
            this.EvernoteEnabled.AutoSize = true;
            this.EvernoteEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EvernoteEnabled.Checked = global::PhotoLogger.Properties.Settings.Default.ENEnabled;
            this.EvernoteEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PhotoLogger.Properties.Settings.Default, "ENEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EvernoteEnabled.Location = new System.Drawing.Point(8, 15);
            this.EvernoteEnabled.Name = "EvernoteEnabled";
            this.EvernoteEnabled.Size = new System.Drawing.Size(105, 17);
            this.EvernoteEnabled.TabIndex = 3;
            this.EvernoteEnabled.Text = "Enable Evernote";
            this.EvernoteEnabled.UseVisualStyleBackColor = true;
            this.EvernoteEnabled.CheckedChanged += new System.EventHandler(this.EvernoteEnabled_CheckedChanged_1);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 261);
            this.Controls.Add(this.SettingsTabContainer);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.SettingsTabContainer.ResumeLayout(false);
            this.TabEvernote.ResumeLayout(false);
            this.TabEvernote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SettingsTabContainer;
        private System.Windows.Forms.TabPage TabGeneralSettings;
        private System.Windows.Forms.TabPage TabEvernote;
        private System.Windows.Forms.ComboBox ENNotebookList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox EvernoteEnabled;
        private System.Windows.Forms.Button BtnLogoutEvernote;
    }
}