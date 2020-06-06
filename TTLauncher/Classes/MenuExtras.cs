using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TTLauncher.Classes
{
    class MenuExtras
    {
        private static string SaveFileName = LauncherForm.ExeName + ".sav";
        private static string SaveDirectory = "GAMEDATA/SaveGame";

        public static void ImportSave()
        {
            using (OpenFileDialog OpenFile = new OpenFileDialog())
            {
                OpenFile.DefaultExt = ".sav";
                OpenFile.Filter = "Save Files |*.sav";
                OpenFile.FileName = SaveFileName;
                OpenFile.InitialDirectory = Directory.GetCurrentDirectory();

                if (OpenFile.ShowDialog(Program.Launcher) == DialogResult.OK)
                {
                    try
                    {
                        Compression.DecompressToDirectory(OpenFile.FileName, Directory.GetCurrentDirectory() + "/" + SaveDirectory + "/");

                        FlexibleMessageBox.Show(Program.Launcher, "Save data imported successfully.",
                            "Import Save", MessageBoxButtons.OK, MessageBoxIcon.Information, Program.Launcher, 1);
                    }

                    catch
                    {
                        FlexibleMessageBox.Show(Program.Launcher, "Invalid or inaccessible file.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, Program.Launcher, 1);
                    }
                }
            }

            CheckSave();
        }

        public static void ExportSave()
        {
            using (SaveFileDialog SaveFile = new SaveFileDialog())
            {
                SaveFile.DefaultExt = ".sav";
                SaveFile.Filter = "Save Files |*.sav";
                SaveFile.FileName = SaveFileName;
                SaveFile.InitialDirectory = Directory.GetCurrentDirectory();

                if (SaveFile.ShowDialog(Program.Launcher) == DialogResult.OK)
                {
                    try
                    {
                        Compression.CompressDirectory(Directory.GetCurrentDirectory() + "/" + SaveDirectory + "/", SaveFile.FileName);

                        FlexibleMessageBox.Show(Program.Launcher, "Save data exported successfully.",
                            "Export Save", MessageBoxButtons.OK, MessageBoxIcon.Information, Program.Launcher, 1);
                    }

                    catch
                    {
                        FlexibleMessageBox.Show(Program.Launcher, "Save data not found.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, Program.Launcher, 1);
                    }
                }
            }

            CheckSave();
        }

        public static void DeleteSave()
        {
            DialogResult Result = FlexibleMessageBox.Show(Program.Launcher, "Are you sure you want to delete all the save data?",
                "Delete Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information, Program.Launcher, 2);

            if (Result == DialogResult.Yes)
            {
                // Added 2 catch statements: one for normal behaviour and another for a design
                // fault between Directory.Delete and Explorer in regards to file handling.
                try
                {
                    Directory.Delete(SaveDirectory, true);

                    FlexibleMessageBox.Show(Program.Launcher, "Save data deleted successfully.",
                        "Delete Save", MessageBoxButtons.OK, MessageBoxIcon.Information, Program.Launcher, 1);
                }

                catch (IOException)
                {
                    // Just for safety, lower values may break in slow systems.
                    Thread.Sleep(100);

                    Directory.Delete(SaveDirectory, true);

                    FlexibleMessageBox.Show(Program.Launcher, "Save data deleted successfully.",
                        "Delete Save", MessageBoxButtons.OK, MessageBoxIcon.Information, Program.Launcher, 1);
                }

                catch
                {
                    FlexibleMessageBox.Show(Program.Launcher, "Save data not found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, Program.Launcher, 1);
                }
            }

            CheckSave();
        }

        public static void CheckSave()
        {
            if (Directory.Exists(SaveDirectory))
            {
                Program.Launcher.MenuItem_ExportSave.Enabled = true;
                Program.Launcher.MenuItem_DeleteSave.Enabled = true;
            }

            else
            {
                Program.Launcher.MenuItem_ExportSave.Enabled = false;
                Program.Launcher.MenuItem_DeleteSave.Enabled = false;
            }
        }

        public static void AboutDisplay(Form Parent)
        {
            string AboutMessage = "  Launcher for Tonic Trouble [Retail] (1.0)\n\n" +
                                  "--------------------------------------------\n\n" +
                                  "- Launcher and Patches by Hipnosis\n" +
                                  "   https://hipnosis183.github.io/\n\n" +
                                  "- Unpacked Executable by RibShark\n\n" +
                                  "- Wrapper dgVoodoo 2.63.1 by Dege\n" +
                                  "   http://dege.freeweb.hu/\n\n" +
                                  "- Logos and Icon by Hipnosis\n" +
                                  "   https://deviantart.com/Hipnosis183";

            FlexibleMessageBox.Show(Parent, AboutMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.None, Parent.Width, 330, 14);
        }
    }
}
