using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace TTLauncher.Classes
{
    class CheckSum
    {
        private static string CalculateCheckSum(string FileName)
        {
            using (Stream Executable = File.OpenRead(FileName))
            {
                byte[] CheckSum = SHA256.Create().ComputeHash(Executable);

                string Formatted = BitConverter.ToString(CheckSum).Replace("-", String.Empty);

                return Formatted;
            }
        }

        public static void GetCheckSum(string FileName)
        {
            string CheckSum = CalculateCheckSum(FileName);
            
            if (VersionCheckSum.Contains(CheckSum))
            {
                Launcher.SettingsLoaded[0] = (byte)VersionCheckSum.IndexOf(CheckSum);
                File.WriteAllBytes(Launcher.SettingsFileName, Launcher.SettingsLoaded);
            }

            else
            {
                Launcher.SettingsLoaded[0] = 0x04;
                File.WriteAllBytes(Launcher.SettingsFileName, Launcher.SettingsLoaded);

                FlexibleMessageBox.Show(Program.Launcher, "Game version couldn't be identified. " +
                    "Get a clean copy of the game, or use at your own risk.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, Program.Launcher, 3);
            }
        }

        public static List<string> VersionCheckSum = new List<string>
        {
            "17457C330D11621474A50B2852618D7DF53468C24899176CB2AFC951B51518FB", // REVIEW ENGLISH : TT221099-PC - SPANISH - PROTECTED
            "C379FFADD35C738C0041CEB9916CCA31C35C6EC096B1B3F257F2C66000F0BBFA", // REVIEW ENGLISH : TT221099-PC - ITALIAN - PROTECTED
            "6AD8506714FC86856369FFE834BB22792AEBCD0FF4FAB780E03AA0ADB47643B3", // RETAIL MASTER V5 : TT181099-PC - FRENCH - UNPROTECTED
            "EA4BE88CEB9BB7C438BEE7F97767CF12C0F9439707A2CDAEE362FFA01C88FDA6", // RETAIL MASTER GERMAN V3: TT221099-PC - GERMAN - PROTECTED
            "37631F2FE37C07DD4CCDE32C0981685E152AC016920BEB01CCC0E8FC0E53DC57"  // RETAIL MASTER V3 : TT131099-PC - BRAZILIAN|CHINESE|EUROPE|USA - PROTECTED
        };

        public static List<string> VersionDetails = new List<string>
        {
            "REVIEW ENGLISH : TT221099 - SPANISH",
            "REVIEW ENGLISH : TT221099 - ITALIAN",
            "RETAIL MASTER V5 : TT181099-PC",
            "RETAIL MASTER GERMAN V3: TT221099-PC",
            "RETAIL MASTER V3 : TT131099-PC"
        };

        public static List<string> VersionLanguage = new List<string>
        {
            "Spanish",
            "Italian",
            "French",
            "German",
            "English"
        };
    }
}
