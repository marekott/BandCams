using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebUI.Library.Validators.Files
{
    public class FileValidator : IFileValidator
    {
        private const long MaxFileSize = 2097152;
        public string GetMaxFileSizeInMb => "2MB";
        private static readonly string[] PermittedExtensions = { ".jpeg", ".jpg", ".png" };
        public string GetPermittedExtensions => String.Join(", ", PermittedExtensions);
        private static readonly Dictionary<string, List<byte[]>> FileSignature =
            new Dictionary<string, List<byte[]>>
            {
                { 
                    ".jpeg", new List<byte[]>
                    {
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                    }
                },
                { 
                    ".jpg", new List<byte[]>
                    {
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                        new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                    }
                },
                { 
                    ".png", new List<byte[]>
                    {
                        new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }
                    }
                }
            };

        public bool ValidateExtension(string fileName)
        {
            var ext = Path.GetExtension(fileName)?.ToLowerInvariant();

            return !string.IsNullOrEmpty(ext) && PermittedExtensions.Contains(ext);
        }

        public bool ValidateSignature(string fileName, byte[] binaryFile)
        {
            var ext = Path.GetExtension(fileName)?.ToLowerInvariant();
            if (ext == null)
            {
                return false;
            }

            var signatures = FileSignature[ext];
            var headerBytes = binaryFile.Take(signatures.Max(m => m.Length));

            return signatures.Any(s => headerBytes.Take(s.Length).SequenceEqual(s));
        }

        public bool ValidateSize(long fileSizeInBytes)
        {
            return fileSizeInBytes < MaxFileSize;
        }
    }
}
