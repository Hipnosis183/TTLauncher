using System;
using System.IO;
using System.Windows.Forms;
using TTLauncher.Classes;

namespace TTLauncher
{
    public partial class LauncherForm : Form
    {
        public static string ExeName;

        public LauncherForm()
        {
            ExeName = Path.GetFileNameWithoutExtension(this.GetType().Assembly.Location);

            InitializeComponent();
            Launcher.InitialSetup();

            Launcher.SetPictureBox(this.PictureBox_Logo);
        }

        private void Button_Run_Click(object sender, EventArgs e)
        {
            Launcher.LaunchApplication();
        }

        private void Button_Settings_Click(object sender, EventArgs e)
        {
            Program.Settings.ShowDialog();
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void MenuItem_ImportSave_Click(object sender, EventArgs e)
        {
            MenuExtras.ImportSave();
        }

        private void MenuItem_ExportSave_Click(object sender, EventArgs e)
        {
            MenuExtras.ExportSave();
        }

        private void MenuItem_DeleteSave_Click(object sender, EventArgs e)
        {
            MenuExtras.DeleteSave();
        }

        private void MenuItem_About_Click(object sender, EventArgs e)
        {
            MenuExtras.AboutDisplay(this);
        }

        private void LauncherForm_Shown(object sender, EventArgs e)
        {
            MenuExtras.CheckSave();
            Launcher.CalculateCheckSum();
        }

        private void PictureBox_Logo_Click(object sender, EventArgs e)
        {
            Launcher.ChangePictureBox(this.PictureBox_Logo);
        }
    }
}
