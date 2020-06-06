using System;
using System.Windows.Forms;

namespace TTLauncher
{
    static class Program
    {
        public static LauncherForm Launcher;
        public static SettingsForm Settings;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Start();
        }

        public static void Start()
        {
            LauncherForm Launcher = new LauncherForm();
            SettingsForm Settings = new SettingsForm();

            Program.Launcher = Launcher;
            Program.Settings = Settings;

            Application.Run(Launcher);
        }
    }
}

// Settings Values:
// 
// Version ---------- 0x00
// Portable Mode ---- 0x01
// Widescreen ------- 0x02
// dgVoodoo --------- 0x03
// High Resolution -- 0x04
// Anti-Aliasing ---- 0x05
//
