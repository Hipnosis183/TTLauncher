using System;
using System.IO;
using System.Windows.Forms;

namespace TTLauncher.Classes
{
    class Patches
    {
        public static void PatcherBlanker(string FileNameInput, int Offset, int Lenght)
        {
            BinaryWriter BinWrite = new BinaryWriter(File.Open(FileNameInput, FileMode.Open, FileAccess.ReadWrite));

            BinWrite.BaseStream.Position = Offset;
            for (int i = 0; i < Lenght; i++)
            {
                BinWrite.Write((byte)0x00);
            }            

            BinWrite.Close();
        }
        
        public static void PatcherPortable(string FileNameInput, int Address1, int Address2, int Address3, int Address4, int Address5)
        {
            byte[] ConfigurationPath = SetConfiguration(2);

            BinaryWriter BinWrite = new BinaryWriter(File.Open(FileNameInput, FileMode.Open, FileAccess.ReadWrite));

            BinWrite.BaseStream.Position = Address1;
            BinWrite.Write(VideosPath);
            BinWrite.BaseStream.Position = Address2;
            BinWrite.Write(ConfigurationFile);
            BinWrite.BaseStream.Position = Address3;
            BinWrite.Write(ConfigurationPathProtected1);
            BinWrite.BaseStream.Position = Address4;
            BinWrite.Write(ConfigurationPathProtected1);
            BinWrite.BaseStream.Position = Address5;
            BinWrite.Write(ConfigurationPath);

            BinWrite.Close();
        }

        public static void PatcherSetup(string FileNameInput, int Address1, int Address2, int Address3)
        {
            byte[] ConfigurationPath = SetConfiguration(1);

            BinaryWriter BinWrite = new BinaryWriter(File.Open(FileNameInput, FileMode.Open, FileAccess.ReadWrite));

            BinWrite.BaseStream.Position = Address1;
            BinWrite.Write(ConfigurationFile);
            BinWrite.BaseStream.Position = Address2;
            BinWrite.Write(ConfigurationPath);
            BinWrite.BaseStream.Position = Address3;
            BinWrite.Write(ConfigurationPath);

            BinWrite.Close();
        }

        private static byte[] VideosPath = new byte[] { 0x56, 0x69, 0x64, 0x65, 0x6F, 0x73, 0x00, 0x00 };
        private static byte[] ConfigurationFile = new byte[] { 0x2E, 0x69, 0x6E, 0x69, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        private static byte[] ConfigurationPathProtected1 = new byte[] { 0x66, 0xC7, 0x00, 0x2E, 0x00, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
        private static byte[] ConfigurationPathProtected2 = new byte[] { 0x8D, 0x84, 0x24, 0x00, 0x01, 0x00, 0x00, 0x53, 0x56, 0x57, 0x66, 0xC7,
                                                                         0x00, 0x2E, 0x00, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0xBF, 0x80,
                                                                         0x83, 0x4D, 0x00, 0x83, 0xC9, 0xFF, 0x33, 0xC0 };

        private static byte[] ConfigurationPathUnProtected1 = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x8D, 0x85, 0xFC, 0xFD, 0xFF, 0xFF, 0x66,
                                                                           0xC7, 0x00, 0x2E, 0x00, 0x90, 0x90 };
        private static byte[] ConfigurationPathUnProtected2 = new byte[] { 0x8D, 0x84, 0x24, 0x00, 0x01, 0x00, 0x00, 0x53, 0x56, 0x57, 0x66, 0xC7,
                                                                           0x00, 0x2E, 0x00, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0xBF, 0x80,
                                                                           0x73, 0x4D, 0x00, 0x83, 0xC9, 0xFF, 0x33, 0xC0 };

        public static void PatcherWidescreen(string FileNameInput, int Address1, int Address2, int Address3)
        {
            BinaryWriter BinWrite = new BinaryWriter(File.Open(FileNameInput, FileMode.Open, FileAccess.ReadWrite));

            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Patches the resolution to stretch the vertical image (Ver-).
            BinWrite.BaseStream.Position = Address1;
            BinWrite.Write(BitConverter.GetBytes(ScreenWidth));
            BinWrite.BaseStream.Position = Address2;
            BinWrite.Write(BitConverter.GetBytes(ScreenHeight));

            double FovHorizontal = Math.Round((2 * Math.Atan(((double)ScreenWidth / ScreenHeight) / ((double)4 / 3) * Math.Tan((double)1 / 2 * (Math.PI / 180)))) * (180 / Math.PI) * Math.Pow(10, 2)) / Math.Pow(10, 2);
            double FovVertical = Math.Round((2 * Math.Atan(Math.Tan((FovHorizontal * (Math.PI / 180)) / 2) * ((double)ScreenHeight / ScreenWidth))) * (180 / Math.PI) * Math.Pow(10, 2)) / Math.Pow(10, 2);

            // Patches the FOV for a proper horizontal wide image (Hor+).
            BinWrite.BaseStream.Position = Address3;
            BinWrite.Write(BitConverter.GetBytes((float)FovVertical));

            BinWrite.Close();
        }

        // Set the correct patch to apply depending on the protection level.
        private static byte[] SetConfiguration(int Configuration)
        {
            if (Launcher.IsProtected())
            {
                if (Configuration == 1)
                {
                    return ConfigurationPathProtected1;
                }

                else
                {
                    return ConfigurationPathProtected2;
                }
            }

            else
            {
                if (Configuration == 1)
                {
                    return ConfigurationPathUnProtected1;
                }

                else
                {
                    return ConfigurationPathUnProtected2;
                }
            }
        }
    }
}
