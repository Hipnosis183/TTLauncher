namespace TTLauncher
{
    partial class LauncherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.PictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.Button_Run = new System.Windows.Forms.Button();
            this.Button_Settings = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItem_Other = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ImportSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ExportSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_DeleteSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox_Logo
            // 
            this.PictureBox_Logo.ErrorImage = null;
            this.PictureBox_Logo.Image = global::TTLauncher.Properties.Resources.Logo_1;
            this.PictureBox_Logo.Location = new System.Drawing.Point(10, 28);
            this.PictureBox_Logo.Name = "PictureBox_Logo";
            this.PictureBox_Logo.Size = new System.Drawing.Size(238, 124);
            this.PictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_Logo.TabIndex = 0;
            this.PictureBox_Logo.TabStop = false;
            this.PictureBox_Logo.Click += new System.EventHandler(this.PictureBox_Logo_Click);
            // 
            // Button_Run
            // 
            this.Button_Run.Location = new System.Drawing.Point(10, 158);
            this.Button_Run.Name = "Button_Run";
            this.Button_Run.Size = new System.Drawing.Size(75, 23);
            this.Button_Run.TabIndex = 1;
            this.Button_Run.Text = "Run";
            this.Button_Run.UseVisualStyleBackColor = true;
            this.Button_Run.Click += new System.EventHandler(this.Button_Run_Click);
            // 
            // Button_Settings
            // 
            this.Button_Settings.Location = new System.Drawing.Point(92, 158);
            this.Button_Settings.Name = "Button_Settings";
            this.Button_Settings.Size = new System.Drawing.Size(75, 23);
            this.Button_Settings.TabIndex = 2;
            this.Button_Settings.Text = "Settings";
            this.Button_Settings.UseVisualStyleBackColor = true;
            this.Button_Settings.Click += new System.EventHandler(this.Button_Settings_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.Location = new System.Drawing.Point(173, 158);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(75, 23);
            this.Button_Exit.TabIndex = 3;
            this.Button_Exit.Text = "Exit";
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.AutoSize = false;
            this.MenuStrip.BackColor = System.Drawing.Color.White;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Other,
            this.MenuItem_About});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(6, 0, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(260, 20);
            this.MenuStrip.TabIndex = 4;
            this.MenuStrip.TabStop = true;
            // 
            // MenuItem_Other
            // 
            this.MenuItem_Other.AutoSize = false;
            this.MenuItem_Other.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuItem_Other.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_ImportSave,
            this.MenuItem_ExportSave,
            this.MenuItem_DeleteSave});
            this.MenuItem_Other.Margin = new System.Windows.Forms.Padding(0, 0, 142, 0);
            this.MenuItem_Other.Name = "MenuItem_Other";
            this.MenuItem_Other.Padding = new System.Windows.Forms.Padding(0);
            this.MenuItem_Other.Size = new System.Drawing.Size(52, 19);
            this.MenuItem_Other.Text = "Other";
            // 
            // MenuItem_ImportSave
            // 
            this.MenuItem_ImportSave.Name = "MenuItem_ImportSave";
            this.MenuItem_ImportSave.Size = new System.Drawing.Size(146, 22);
            this.MenuItem_ImportSave.Text = "Import Save...";
            this.MenuItem_ImportSave.Click += new System.EventHandler(this.MenuItem_ImportSave_Click);
            // 
            // MenuItem_ExportSave
            // 
            this.MenuItem_ExportSave.Enabled = false;
            this.MenuItem_ExportSave.Name = "MenuItem_ExportSave";
            this.MenuItem_ExportSave.Size = new System.Drawing.Size(146, 22);
            this.MenuItem_ExportSave.Text = "Export Save...";
            this.MenuItem_ExportSave.Click += new System.EventHandler(this.MenuItem_ExportSave_Click);
            // 
            // MenuItem_DeleteSave
            // 
            this.MenuItem_DeleteSave.Enabled = false;
            this.MenuItem_DeleteSave.Name = "MenuItem_DeleteSave";
            this.MenuItem_DeleteSave.Size = new System.Drawing.Size(146, 22);
            this.MenuItem_DeleteSave.Text = "Delete Save...";
            this.MenuItem_DeleteSave.Click += new System.EventHandler(this.MenuItem_DeleteSave_Click);
            // 
            // MenuItem_About
            // 
            this.MenuItem_About.AutoSize = false;
            this.MenuItem_About.BackColor = System.Drawing.Color.White;
            this.MenuItem_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuItem_About.Name = "MenuItem_About";
            this.MenuItem_About.Padding = new System.Windows.Forms.Padding(0);
            this.MenuItem_About.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MenuItem_About.Size = new System.Drawing.Size(52, 19);
            this.MenuItem_About.Text = "About";
            this.MenuItem_About.Click += new System.EventHandler(this.MenuItem_About_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 191);
            this.Controls.Add(this.Button_Exit);
            this.Controls.Add(this.Button_Settings);
            this.Controls.Add(this.Button_Run);
            this.Controls.Add(this.PictureBox_Logo);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "LauncherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.Shown += new System.EventHandler(this.LauncherForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Button_Settings;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Other;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ImportSave;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_About;
        public System.Windows.Forms.ToolStripMenuItem MenuItem_ExportSave;
        public System.Windows.Forms.ToolStripMenuItem MenuItem_DeleteSave;
        private System.Windows.Forms.Button Button_Run;
        public System.Windows.Forms.PictureBox PictureBox_Logo;
    }
}