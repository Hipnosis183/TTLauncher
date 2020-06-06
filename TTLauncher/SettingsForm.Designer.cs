namespace TTLauncher
{
    partial class SettingsForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.CheckBox_VideoWrapper = new System.Windows.Forms.CheckBox();
            this.CheckBox_HighResolution = new System.Windows.Forms.CheckBox();
            this.CheckBox_AntiAliasing = new System.Windows.Forms.CheckBox();
            this.CheckBox_Widescreen = new System.Windows.Forms.CheckBox();
            this.CheckBox_PortableMode = new System.Windows.Forms.CheckBox();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Label_Widescreen = new System.Windows.Forms.Label();
            this.GroupBox_Game = new System.Windows.Forms.GroupBox();
            this.GroupBox_Video = new System.Windows.Forms.GroupBox();
            this.GroupBox_Version = new System.Windows.Forms.GroupBox();
            this.TextBox_Version = new System.Windows.Forms.TextBox();
            this.GroupBox_Game.SuspendLayout();
            this.GroupBox_Video.SuspendLayout();
            this.GroupBox_Version.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBox_VideoWrapper
            // 
            this.CheckBox_VideoWrapper.AutoSize = true;
            this.CheckBox_VideoWrapper.Location = new System.Drawing.Point(10, 30);
            this.CheckBox_VideoWrapper.Name = "CheckBox_VideoWrapper";
            this.CheckBox_VideoWrapper.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckBox_VideoWrapper.Size = new System.Drawing.Size(97, 17);
            this.CheckBox_VideoWrapper.TabIndex = 5;
            this.CheckBox_VideoWrapper.Text = "Video Wrapper";
            this.CheckBox_VideoWrapper.UseVisualStyleBackColor = true;
            this.CheckBox_VideoWrapper.CheckedChanged += new System.EventHandler(this.CheckBox_VideoWrapper_CheckedChanged);
            // 
            // CheckBox_HighResolution
            // 
            this.CheckBox_HighResolution.AutoSize = true;
            this.CheckBox_HighResolution.Location = new System.Drawing.Point(20, 54);
            this.CheckBox_HighResolution.Name = "CheckBox_HighResolution";
            this.CheckBox_HighResolution.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckBox_HighResolution.Size = new System.Drawing.Size(101, 17);
            this.CheckBox_HighResolution.TabIndex = 6;
            this.CheckBox_HighResolution.Text = "High Resolution";
            this.CheckBox_HighResolution.UseVisualStyleBackColor = true;
            this.CheckBox_HighResolution.CheckedChanged += new System.EventHandler(this.CheckBox_HighResolution_CheckedChanged);
            // 
            // CheckBox_AntiAliasing
            // 
            this.CheckBox_AntiAliasing.AutoSize = true;
            this.CheckBox_AntiAliasing.Location = new System.Drawing.Point(20, 76);
            this.CheckBox_AntiAliasing.Name = "CheckBox_AntiAliasing";
            this.CheckBox_AntiAliasing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckBox_AntiAliasing.Size = new System.Drawing.Size(83, 17);
            this.CheckBox_AntiAliasing.TabIndex = 7;
            this.CheckBox_AntiAliasing.Text = "Anti-Aliasing";
            this.CheckBox_AntiAliasing.UseVisualStyleBackColor = true;
            this.CheckBox_AntiAliasing.CheckedChanged += new System.EventHandler(this.CheckBox_AntiAliasing_CheckedChanged);
            // 
            // CheckBox_Widescreen
            // 
            this.CheckBox_Widescreen.AutoSize = true;
            this.CheckBox_Widescreen.Location = new System.Drawing.Point(10, 57);
            this.CheckBox_Widescreen.Name = "CheckBox_Widescreen";
            this.CheckBox_Widescreen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckBox_Widescreen.Size = new System.Drawing.Size(83, 17);
            this.CheckBox_Widescreen.TabIndex = 2;
            this.CheckBox_Widescreen.Text = "Widescreen";
            this.CheckBox_Widescreen.UseVisualStyleBackColor = true;
            this.CheckBox_Widescreen.CheckedChanged += new System.EventHandler(this.CheckBox_Widescreen_CheckedChanged);
            // 
            // CheckBox_PortableMode
            // 
            this.CheckBox_PortableMode.AutoSize = true;
            this.CheckBox_PortableMode.Location = new System.Drawing.Point(10, 30);
            this.CheckBox_PortableMode.Name = "CheckBox_PortableMode";
            this.CheckBox_PortableMode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheckBox_PortableMode.Size = new System.Drawing.Size(95, 17);
            this.CheckBox_PortableMode.TabIndex = 1;
            this.CheckBox_PortableMode.Text = "Portable Mode";
            this.CheckBox_PortableMode.UseVisualStyleBackColor = true;
            this.CheckBox_PortableMode.CheckedChanged += new System.EventHandler(this.CheckBox_PortableMode_CheckedChanged);
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(266, 127);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(75, 23);
            this.Button_Save.TabIndex = 8;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(266, 156);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 9;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Label_Widescreen
            // 
            this.Label_Widescreen.AutoSize = true;
            this.Label_Widescreen.Location = new System.Drawing.Point(10, 77);
            this.Label_Widescreen.Name = "Label_Widescreen";
            this.Label_Widescreen.Size = new System.Drawing.Size(87, 13);
            this.Label_Widescreen.TabIndex = 3;
            this.Label_Widescreen.Text = "(Select 800x600)";
            // 
            // GroupBox_Game
            // 
            this.GroupBox_Game.Controls.Add(this.CheckBox_PortableMode);
            this.GroupBox_Game.Controls.Add(this.Label_Widescreen);
            this.GroupBox_Game.Controls.Add(this.CheckBox_Widescreen);
            this.GroupBox_Game.Location = new System.Drawing.Point(12, 74);
            this.GroupBox_Game.Name = "GroupBox_Game";
            this.GroupBox_Game.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GroupBox_Game.Size = new System.Drawing.Size(110, 105);
            this.GroupBox_Game.TabIndex = 0;
            this.GroupBox_Game.TabStop = false;
            this.GroupBox_Game.Text = "Game";
            // 
            // GroupBox_Video
            // 
            this.GroupBox_Video.Controls.Add(this.CheckBox_VideoWrapper);
            this.GroupBox_Video.Controls.Add(this.CheckBox_HighResolution);
            this.GroupBox_Video.Controls.Add(this.CheckBox_AntiAliasing);
            this.GroupBox_Video.Location = new System.Drawing.Point(128, 74);
            this.GroupBox_Video.Name = "GroupBox_Video";
            this.GroupBox_Video.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GroupBox_Video.Size = new System.Drawing.Size(128, 105);
            this.GroupBox_Video.TabIndex = 4;
            this.GroupBox_Video.TabStop = false;
            this.GroupBox_Video.Text = "dgVoodoo";
            // 
            // GroupBox_Version
            // 
            this.GroupBox_Version.Controls.Add(this.TextBox_Version);
            this.GroupBox_Version.Location = new System.Drawing.Point(12, 12);
            this.GroupBox_Version.Name = "GroupBox_Version";
            this.GroupBox_Version.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GroupBox_Version.Size = new System.Drawing.Size(329, 56);
            this.GroupBox_Version.TabIndex = 10;
            this.GroupBox_Version.TabStop = false;
            this.GroupBox_Version.Text = "Version";
            // 
            // TextBox_Version
            // 
            this.TextBox_Version.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBox_Version.Location = new System.Drawing.Point(10, 25);
            this.TextBox_Version.Name = "TextBox_Version";
            this.TextBox_Version.ReadOnly = true;
            this.TextBox_Version.Size = new System.Drawing.Size(308, 20);
            this.TextBox_Version.TabIndex = 11;
            this.TextBox_Version.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBox_Version.WordWrap = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 191);
            this.Controls.Add(this.GroupBox_Version);
            this.Controls.Add(this.GroupBox_Video);
            this.Controls.Add(this.GroupBox_Game);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.GroupBox_Game.ResumeLayout(false);
            this.GroupBox_Game.PerformLayout();
            this.GroupBox_Video.ResumeLayout(false);
            this.GroupBox_Video.PerformLayout();
            this.GroupBox_Version.ResumeLayout(false);
            this.GroupBox_Version.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox CheckBox_VideoWrapper;
        private System.Windows.Forms.CheckBox CheckBox_HighResolution;
        private System.Windows.Forms.CheckBox CheckBox_AntiAliasing;
        private System.Windows.Forms.CheckBox CheckBox_Widescreen;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Button Button_Cancel;
        public System.Windows.Forms.CheckBox CheckBox_PortableMode;
        private System.Windows.Forms.Label Label_Widescreen;
        private System.Windows.Forms.GroupBox GroupBox_Game;
        private System.Windows.Forms.GroupBox GroupBox_Video;
        private System.Windows.Forms.GroupBox GroupBox_Version;
        private System.Windows.Forms.TextBox TextBox_Version;
    }
}

