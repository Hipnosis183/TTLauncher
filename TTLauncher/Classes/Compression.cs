using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace TTLauncher.Classes
{
    // Compression and decompression of folders and files using the Deflate algorithm.
    class Compression
    {
        public static void CompressFile(string InDirectory, string RelativePath, GZipStream CompressionStream)
        {
            char[] Chars = RelativePath.ToCharArray();

            CompressionStream.Write(BitConverter.GetBytes(Chars.Length), 0, sizeof(int));

            foreach (char Char in Chars)
            {
                CompressionStream.Write(BitConverter.GetBytes(Char), 0, sizeof(char));
            }

            byte[] Bytes = File.ReadAllBytes(Path.Combine(InDirectory, RelativePath));

            CompressionStream.Write(BitConverter.GetBytes(Bytes.Length), 0, sizeof(int));
            CompressionStream.Write(Bytes, 0, Bytes.Length);
        }

        public static void CompressDirectory(string InDirectory, string OutFile)
        {
            string[] Files = Directory.GetFiles(InDirectory, "*.*", SearchOption.AllDirectories);

            int InDirectoryLenght = InDirectory[InDirectory.Length - 1] == Path.DirectorySeparatorChar ? InDirectory.Length : InDirectory.Length;

            using (FileStream FilesStream = new FileStream(OutFile, FileMode.Create, FileAccess.Write, FileShare.None))
            using (GZipStream CompressionStream = new GZipStream(FilesStream, CompressionMode.Compress))
            {
                foreach (string File in Files)
                {
                    string RelativePath = File.Substring(InDirectoryLenght);

                    CompressFile(InDirectory, RelativePath, CompressionStream);
                }
            }
        }

        public static bool DecompressFile(string OutDirectory, GZipStream CompressionStream)
        {
            byte[] Bytes = new byte[sizeof(int)];
            int CompressedFile = CompressionStream.Read(Bytes, 0, sizeof(int));
            
            if (CompressedFile < sizeof(int))
            {
                return false;
            }

            int NameLenght = BitConverter.ToInt32(Bytes, 0);
            
            Bytes = new byte[sizeof(char)];
            
            StringBuilder StrBuilder = new StringBuilder();

            for (int i = 0; i < NameLenght; i++)
            {
                CompressionStream.Read(Bytes, 0, sizeof(char));

                char Char = BitConverter.ToChar(Bytes, 0);

                StrBuilder.Append(Char);
            }
            
            string FileName = StrBuilder.ToString();

            Bytes = new byte[sizeof(int)];
            CompressionStream.Read(Bytes, 0, sizeof(int));

            int FileLenght = BitConverter.ToInt32(Bytes, 0);

            Bytes = new byte[FileLenght];
            CompressionStream.Read(Bytes, 0, Bytes.Length);

            string FilePath = Path.Combine(OutDirectory, FileName);
            string FinalPath = Path.GetDirectoryName(FilePath);

            if (!Directory.Exists(FinalPath))
            {
                Directory.CreateDirectory(FinalPath);
            }

            using (FileStream OutFile = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                OutFile.Write(Bytes, 0, FileLenght);
            }   

            return true;
        }

        public static void DecompressToDirectory(string CompressedFile, string OutDirectory)
        {
            using (FileStream FilesStream = new FileStream(CompressedFile, FileMode.Open, FileAccess.Read, FileShare.None))
            using (GZipStream CompressionStream = new GZipStream(FilesStream, CompressionMode.Decompress, true))
            {
                while (DecompressFile(OutDirectory, CompressionStream));
            }
        }
    }
}
