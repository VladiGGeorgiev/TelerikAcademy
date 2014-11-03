using Supermarket.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReportGenerator
{
    public class Generator
    {
        public string ZipFilePath { get; private set; }

        public string FolderRoot { get; private set; }

        public Generator(string zipFilePath, string folderRoot)
        {
            this.ZipFilePath = zipFilePath;
            this.FolderRoot = folderRoot;
        }

        public ICollection<DailyReport> Generate()
        {
            ICollection<DailyReport> entries = new List<DailyReport>();

            var zipReader = new ZipReader(this.ZipFilePath, this.FolderRoot);
            zipReader.ExtractToTemporaryLocation();


            var tempFolder = zipReader.TempFolderName;
            var excelFiles = Directory.GetFileSystemEntries(tempFolder, "*.xls", SearchOption.AllDirectories);

            foreach (var file in excelFiles)
            {
                var excelReader = new ExcelReader(file);
                var row = excelReader.GetAllEntriesReader();

                bool isHeader = true;
                string marketName = string.Empty;
                string reportDate = this.GetDateFromFileName(file);
                using (excelReader)
                {
                    while (row.Read())
                    {
                        if (isHeader)
                        {
                            marketName = (string)row[0];
                            isHeader = false;
                            continue;
                        }
                        var productIdStr = string.Empty;
                        var priceStr = string.Empty;
                        var quantityStr = string.Empty;
                        if (row[0] != DBNull.Value && row[1] != DBNull.Value && row[2] != DBNull.Value)
                        {
                            productIdStr = row[0].ToString();
                            quantityStr = row[1].ToString();
                            priceStr = row[2].ToString();

                        }
                        var newSale = DailyReport.TryParse(marketName, productIdStr, quantityStr, priceStr, reportDate);

                        if (newSale != null)
                        {
                            entries.Add(newSale);
                        }
                    }
                }
            }

            zipReader.DeleteTemporaryFolder();
            return entries;
        }

        private string GetDateFromFileName(string filename)
        {
            string directory = Path.GetDirectoryName(filename);

            var index = directory.LastIndexOf('\\') + 1;
            var date = directory.Substring(index);
            return date;
        }
    }
}
