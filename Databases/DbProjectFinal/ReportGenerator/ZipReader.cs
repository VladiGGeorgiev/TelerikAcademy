using Ionic.Zip;
using System;
using System.IO;
using System.Linq;

namespace ReportGenerator
{
    public class ZipReader
    {
        public string FilePath { get; private set; }

        public string TempFolderRoot { get; private set; }

        public string TempFolderName { get; private set; }

        public ZipReader(string filePath, string tempFolderRoot)
        {
            this.TempFolderRoot = tempFolderRoot;
            this.FilePath = filePath;
            this.TempFolderName = this.GetTempFolderName();
        }

        public void ExtractToTemporaryLocation()
        {
             ZipFile archive = ZipFile.Read(this.FilePath);
            using (archive)
            {
                Directory.CreateDirectory(this.TempFolderName);
                foreach (var item in archive.Entries)
                {
                    var archiveFileName = System.IO.Path.GetFileName(item.ToString());
                    if (archiveFileName.Length != 0)
                    {
                        item.Extract(this.TempFolderName);
                    }
                }
            }
        }

        public void DeleteTemporaryFolder()
        {
            var currentTempDir = Directory.GetFileSystemEntries(this.TempFolderName, "*.xls", SearchOption.AllDirectories);

            foreach (var file in currentTempDir)
            {
                File.Delete(file);
            }

            Directory.Delete(this.TempFolderName, true);
        }

        private string GetTempFolderName()
        {
            return this.TempFolderRoot + "TemoraryFolder" + DateTime.Now.ToString("yyyymmhhmmss");
        }
    }
}
