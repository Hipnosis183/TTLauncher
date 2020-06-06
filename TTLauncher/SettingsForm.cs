using System;
using System.IO;
using System.Windows.Forms;
using TTLauncher.Classes;

namespace TTLauncher
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            Settings.GetText(TextBox_Version, CheckSum.VersionDetails[Launcher.SettingsLoaded[0]]);

            Settings.GetCheck(CheckBox_PortableMode, 1);
            Settings.GetCheck(CheckBox_Widescreen, 2);
            Settings.GetCheck(CheckBox_VideoWrapper, 3);
            Settings.GetCheck(CheckBox_HighResolution, 4);
            Settings.GetCheck(CheckBox_AntiAliasing, 5);

            Settings.GetMultiCheck(CheckBox_VideoWrapper, CheckBox_HighResolution, CheckBox_AntiAliasing);
        }

        private void CheckBox_PortableMode_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetConfig_CheckBox(CheckBox_PortableMode, 1);
        }

        private void CheckBox_Widescreen_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetConfig_CheckBox(CheckBox_Widescreen, 2);
        }

        private void CheckBox_VideoWrapper_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetConfig_CheckBox(CheckBox_VideoWrapper, 3);
            Settings.SetConfig_CheckBox_Disable(CheckBox_VideoWrapper, CheckBox_HighResolution);
            Settings.SetConfig_CheckBox_Disable(CheckBox_VideoWrapper, CheckBox_AntiAliasing);
        }

        private void CheckBox_HighResolution_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetConfig_CheckBox(CheckBox_HighResolution, 4);
        }

        private void CheckBox_AntiAliasing_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetConfig_CheckBox(CheckBox_AntiAliasing, 5);
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(Launcher.SettingsFileName, Launcher.SettingsLoaded);

            this.Hide();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Launcher.SettingsLoaded = File.ReadAllBytes(Launcher.SettingsFileName);

            this.Hide();
        }
    }
}
