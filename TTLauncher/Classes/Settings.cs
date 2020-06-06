using System.Windows.Forms;

namespace TTLauncher.Classes
{
    class Settings
    {
        // Handle checkboxes status with the configuration.
        public static void GetCheck(CheckBox Check, int HexPosition)
        {
            if (Launcher.SettingsLoaded[HexPosition] == 0x01)
            {
                Check.Checked = true;
            }

            else
            {
                Check.Checked = false;
            }
        }

        public static void GetMultiCheck(CheckBox CheckBoxIn, CheckBox CheckBoxOut1, CheckBox CheckBoxOut2)
        {
            if (CheckBoxIn.Checked)
            {
                CheckBoxOut1.Enabled = true;
                CheckBoxOut2.Enabled = true;
            }

            else
            {
                CheckBoxOut1.Enabled = false;
                CheckBoxOut2.Enabled = false;
            }
        }

        public static void SetConfig_CheckBox(CheckBox Check, int HexPosition)
        {
            if (Check.Checked)
            {
                Launcher.SettingsLoaded[HexPosition] = 0x01;
            }

            else
            {
                Launcher.SettingsLoaded[HexPosition] = 0x00;
            }
        }

        public static void SetConfig_CheckBox_Disable(CheckBox CheckBoxIn, CheckBox CheckBoxOut)
        {
            if (CheckBoxIn.Checked)
            {
                CheckBoxOut.Enabled = true;
            }

            else
            {
                CheckBoxOut.Enabled = false;
            }
        }

        public static void GetText(TextBox Box, string Text)
        {
            if (Launcher.CheckExecutable())
            {
                Box.Text = Text;
            }

            else
            {
                Box.Text = null;
            }
        }
    }
}
