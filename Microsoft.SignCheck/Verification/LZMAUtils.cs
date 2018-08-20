﻿using System;
using System.IO;
using SevenZip.Compression.LZMA;

namespace Microsoft.SignCheck.Verification
{
    public class LZMAUtils
    {
        public static void Decompress(string sourceFile, string destinationFile)
        {
            string destinationDir = Path.GetDirectoryName(destinationFile);

            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            using (FileStream inFile = new FileStream(sourceFile, FileMode.Open))
            using (FileStream outFile = new FileStream(destinationFile, FileMode.Create))
            {
                Decoder decoder = new Decoder();
                byte[] properties = new byte[5];
                byte[] fileLengthBytes = new byte[8];

                inFile.Read(properties, 0, 5);
                inFile.Read(fileLengthBytes, 0, 8);

                long fileLength = BitConverter.ToInt64(fileLengthBytes, 0);
                decoder.SetDecoderProperties(properties);

                decoder.Code(inFile, outFile, inFile.Length, fileLength, null);
            }
        }
    }
}
