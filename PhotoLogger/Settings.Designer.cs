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
            this.TabGeneralSettings.Controls.Add(this.EvernoteEnabled);
            this.TabGeneralSettings.Location = new System.Drawing.Point(4, 22);
            this.TabGeneralSettings.Name = "TabGeneralSettings";
            this.TabGeneralSettings.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneralSettings.Size = new System.Drawing.Size(539, 235);
            this.TabGeneralSettings.TabIndex = 0;
            this.TabGeneralSettings.Text = "General";
            this.TabGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // EvernoteEnabled
            // 
            this.EvernoteEnabled.AutoSize = true;
            this.EvernoteEnabled.Location = new System.Drawing.Point(8, 22);
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
            this.SettingsTabContainer.ResumeLayout(false);
            this.TabGeneralSettings.ResumeLayout(false);
            this.TabGeneralSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SettingsTabContainer;
        private System.Windows.Forms.TabPage TabGeneralSettings;
        private System.Windows.Forms.CheckBox EvernoteEnabled;
    }
}