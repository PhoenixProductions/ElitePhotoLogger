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
            this.label1 = new System.Windows.Forms.Label();
            this.ENNotebookList = new System.Windows.Forms.ComboBox();
            this.EvernoteEnabled = new System.Windows.Forms.CheckBox();
            this.SettingsTabContainer.SuspendLayout();
            this.TabGeneralSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsTabContainer
            // 
            this.SettingsTabContainer.Controls.Add(this.TabGeneralSettings);
            this.SettingsTabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsTabContainer.Location = new System.Drawing.Point(0, 0);
            this.SettingsTabContainer.Name = "SettingsTabContainer";
            this.SettingsTabContainer.SelectedIndex = 0;
            this.SettingsTabContainer.Size = new System.Drawing.Size(547, 261);
            this.SettingsTabContainer.TabIndex = 0;
            // 
            // TabGeneralSettings
            // 
            this.TabGeneralSettings.Controls.Add(this.ENNotebookList);
            this.TabGeneralSettings.Controls.Add(this.label1);
            this.TabGeneralSettings.Controls.Add(this.EvernoteEnabled);
            this.TabGeneralSettings.Location = new System.Drawing.Point(4, 22);
            this.TabGeneralSettings.Name = "TabGeneralSettings";
            this.TabGeneralSettings.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneralSettings.Size = new System.Drawing.Size(539, 235);
            this.TabGeneralSettings.TabIndex = 0;
            this.TabGeneralSettings.Text = "General";
            this.TabGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NoteBook";
            // 
            // ENNotebookList
            // 
            this.ENNotebookList.FormattingEnabled = true;
            this.ENNotebookList.Location = new System.Drawing.Point(69, 39);
            this.ENNotebookList.Name = "ENNotebookList";
            this.ENNotebookList.Size = new System.Drawing.Size(121, 21);
            this.ENNotebookList.TabIndex = 2;
            this.ENNotebookList.SelectedIndexChanged += new System.EventHandler(this.ENNotebookList_SelectedIndexChanged);
            // 
            // EvernoteEnabled
            // 
            this.EvernoteEnabled.AutoSize = true;
            this.EvernoteEnabled.Checked = global::PhotoLogger.Properties.Settings.Default.ENEnabled;
            this.EvernoteEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::PhotoLogger.Properties.Settings.Default, "ENEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EvernoteEnabled.Location = new System.Drawing.Point(11, 22);
            this.EvernoteEnabled.Name = "EvernoteEnabled";
            this.EvernoteEnabled.Size = new System.Drawing.Size(105, 17);
            this.EvernoteEnabled.TabIndex = 0;
            this.EvernoteEnabled.Text = "Enable Evernote";
            this.EvernoteEnabled.UseVisualStyleBackColor = true;
            this.EvernoteEnabled.CheckedChanged += new System.EventHandler(this.EvernoteEnabled_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 261);
            this.Controls.Add(this.SettingsTabContainer);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.SettingsTabContainer.ResumeLayout(false);
            this.TabGeneralSettings.ResumeLayout(false);
            this.TabGeneralSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SettingsTabContainer;
        private System.Windows.Forms.TabPage TabGeneralSettings;
        private System.Windows.Forms.CheckBox EvernoteEnabled;
        private System.Windows.Forms.ComboBox ENNotebookList;
        private System.Windows.Forms.Label label1;
    }
}