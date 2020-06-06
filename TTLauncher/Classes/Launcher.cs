using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace TTLauncher.Classes
{
    class Launcher
    {
        // Extract a defined byte range from resource into a file.
        public static void ExtractFileFromResources(string ResourceInput, string FileOutput, int Offset, int Lenght)
        {
            Assembly AssemblyFile = Assembly.GetExecutingAssembly();
            Stream FileStream = AssemblyFile.GetManifestResourceStream(ResourceInput);

            if (FileStream != null)
            {
                FileStream FileStr = new FileStream(FileOutput, FileMode.Create);
                BinaryReader BinRead = new BinaryReader(FileStream);
                BinaryWriter BinWrite = new BinaryWriter(FileStr);

                byte[] FSArray = new byte[FileStream.Length];

                FileStream.Read(FSArray, 0, FSArray.Length);
                BinWrite.Write(FSArray, Offset, Lenght);

                BinRead.Close();
                BinWrite.Close();
                FileStream.Close();
            }
        }

        public static byte[] SettingsLoaded;
        public static string SettingsFileName;

        // Prepare the program configuration.
        public static void InitialSetup()
        {
            SettingsFileName = LauncherForm.ExeName + ".bin";

            if (!File.Exists(SettingsFileName))
            {
                Launcher.ExtractFileFromResources("TTLauncher.Files.App.bin", SettingsFileName, 0, 16);
            }

            SettingsLoaded = File.ReadAllBytes(SettingsFileName);
        }

        private const string ExeSetup = "SetupTT.exe";
        private const string ExeGame = "TonicTrouble.exe";

        public static bool CheckExecutable()
        {
            if (File.Exists(ExeGame))
            {
                return true;
            }

            else
            {
                FlexibleMessageBox.Show(Program.Launcher, "Game executable not found. \nGet a clean copy of the game.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, Program.Launcher, 2);

                return false;
            }
        }

        public static void CalculateCheckSum()
        {
            if (CheckExecutable())
            {
                CheckSum.GetCheckSum(ExeGame);
            }
        }

        public static bool IsProtected()
        {
            if (SettingsLoaded[0] != 0x02)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        // Decide if the alternative logo will be used.
        public static void SetPictureBox(PictureBox Picture)
        {
            if (SettingsLoaded[15] == 0x01)
            {
                Picture.Image = Properties.Resources.Logo_2;
            }
        }

        // An easter egg, since i couldn't decide which one to use.
        public static void ChangePictureBox(PictureBox Picture)
        {
            if (Picture.Image.Size == Properties.Resources.Logo_1.Size)
            {
                Picture.Image = Properties.Resources.Logo_2;

                Launcher.SettingsLoaded[15] = 0x01;
                File.WriteAllBytes(Launcher.SettingsFileName, Launcher.SettingsLoaded);
            }

            else
            {
                Picture.Image = Properties.Resources.Logo_1;

                Launcher.SettingsLoaded[15] = 0x00;
                File.WriteAllBytes(Launcher.SettingsFileName, Launcher.SettingsLoaded);
            }
        }

        public static void LaunchApplication()
        {
            if (CheckExecutable())
            {
                Program.Launcher.Close();
                Program.Settings.Close();

                // For protected versions.
                if (IsProtected())
                {
                    BackupFiles();
                    UnpackFiles();
                }

                // For unprotected versions.
                else
                {
                    CopyFiles();
                }
                
                CheckConfiguration();
                RunGame();
                DeleteFiles();
                RestoreFiles();

                Application.ExitThread();
            }
        }

        private static void BackupFiles()
        {
            File.Move(ExeGame, ExeGame + ".bak");
            File.Move(ExeSetup, ExeSetup + ".bak");
        }

        private static void UnpackFiles()
        {
            ExtractFileFromResources("TTLauncher.Files.Data.bin", ExeGame, 16, 967168);
            ExtractFileFromResources("TTLauncher.Files.Data.bin", ExeSetup, 967200, 95744);

            UnpackedFiles.Add(ExeGame);
            UnpackedFiles.Add(ExeSetup);
        }

        private static void CopyFiles()
        {
            File.Copy(ExeGame, ExeGame + ".bak");
            File.Copy(ExeSetup, ExeSetup + ".bak");

            UnpackedFiles.Add(ExeGame );
            UnpackedFiles.Add(ExeSetup);
        }

        private static void CheckConfiguration()
        {
            InitialPatching();
            
            // Portable Mode.
            if (SettingsLoaded[1] == 0x01)
            {
                // Manage configuration file.
                if (!File.Exists("Ubi.ini"))
                {
                    using (StreamWriter Stream = File.CreateText("Ubi.ini"))
                    {
                        Stream.WriteLine("[TONICT]");

                        // Needed for the game and setup executables.
                        Stream.WriteLine("Directory=");

                        // Necessary to play the intro video and some sounds.
                        Stream.WriteLine("Language=" + CheckSum.VersionLanguage[SettingsLoaded[0]]);
                    }
                }

                PatchExecutables();
            }

            // Adjust the FOV to the desktop resolution aspect ratio.
            if (SettingsLoaded[2] == 0x01)
            {
                PatchWidescreen();
            }

            // Configure dgVoodoo 2(.63.1).
            if (SettingsLoaded[3] == 0x01)
            {
                ExtractFileFromResources("TTLauncher.Files.Video.bin", "D3DImm.dll", 16, 119808);
                ExtractFileFromResources("TTLauncher.Files.Video.bin", "DDraw.dll", 119840, 145408);

                UnpackedFiles.Add("D3DImm.dll");
                UnpackedFiles.Add("DDraw.dll");

                ConfigureVideo();
            }
        }

        // Make some initial patches, regardless of the configuration set.
        private static void InitialPatching()
        {
            // For unprotected versions.
            if (SettingsLoaded[0] == 0x02)
            {
                Patches.PatcherBlanker(ExeGame, 0xD24A8, 11);
                Patches.PatcherBlanker(ExeGame, 0xD24EC, 9);
                Patches.PatcherBlanker(ExeSetup, 0x77C4, 9);
            }

            // For protected versions.
            else
            {
                Patches.PatcherBlanker(ExeGame, 0xD28A8, 11);
                Patches.PatcherBlanker(ExeGame, 0xD28EC, 9);
                Patches.PatcherBlanker(ExeSetup, 0x69C4, 9);
            }
        }

        // Patch the game and setup executables.
        private static void PatchExecutables()
        {
            // For unprotected versions.
            if (SettingsLoaded[0] == 0x02)
            {
                Patches.PatcherPortable(ExeGame, 0xD56CC, 0xD5784, 0xFCF0, 0x12C5D, 0x40EF6);
                Patches.PatcherSetup(ExeSetup, 0x70E8, 0x439, 0x5D9);
            }

            // For protected versions.
            else
            {
                Patches.PatcherPortable(ExeGame, 0xD5ACC, 0xD5B84, 0xFDD0, 0x12D4D, 0x41AA6);
                Patches.PatcherSetup(ExeSetup, 0x62E8, 0x42D, 0x5C0);
            }
        }

        private static void PatchWidescreen()
        {
            // For unprotected versions.
            if (SettingsLoaded[0] == 0x02)
            {
                Patches.PatcherWidescreen(ExeGame, 0x11155, 0x1115B, 0xCF4D8);
            }

            // For protected versions.
            else
            {
                Patches.PatcherWidescreen(ExeGame, 0x11235, 0x1123B, 0xD0B50);
            }
        }

        private static void RunGame()
        {
            Process TonicTrouble = new Process();
                    
            TonicTrouble.StartInfo.FileName = ExeGame;                
            
            if (SettingsLoaded[1] == 0x01)
            {
                TonicTrouble.StartInfo.Arguments = "-cdrom:";
            }                
            
            TonicTrouble.Start();

            CheckGame();
        }

        private static void CheckGame()
        {
            System.Threading.Thread.Sleep(1000);

            Process[] CurrentProcess = Process.GetProcessesByName("TonicTrouble");

            foreach (Process Process in CurrentProcess)
            {
                if (Process.ProcessName == "TonicTrouble")
                {
                    Process.WaitForExit();
                }
            }
        }

        private static ArrayList UnpackedFiles = new ArrayList();

        private static void DeleteFiles()
        {
            foreach (string UnpackedFile in UnpackedFiles)
            {
                File.Delete(UnpackedFile);
            }
        }

        // Restore all the game files to their original state.
        private static void RestoreFiles()
        {
            File.Move(ExeGame + ".bak", ExeGame);
            File.Move(ExeSetup + ".bak", ExeSetup);
        }

        private static void ConfigureVideo()
        {
            // Change values to adjust the configuration. Defaults cover most user needs.
            using (StreamWriter Stream = File.CreateText("dgVoodoo.conf"))
            {
                Stream.WriteLine("[General]");
                Stream.WriteLine("FullScreenMode=true");
                Stream.WriteLine("ScalingMode=stretched_ar");
                Stream.WriteLine("[DirectX]");
                Stream.WriteLine("VRAM=128");
                Stream.WriteLine("dgVoodooWatermark=false");
                Stream.WriteLine("BilinearBlitStretch=true");

                if (SettingsLoaded[4] == 0x01)
                {
                    Stream.WriteLine("Resolution=max");
                }

                if (SettingsLoaded[5] == 0x01)
                {
                    Stream.WriteLine("Antialiasing=4x");
                }
            }

            UnpackedFiles.Add("dgVoodoo.conf");
        }
    }
}
