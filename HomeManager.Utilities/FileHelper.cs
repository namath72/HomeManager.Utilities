using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Utilities
{
    public static class FileHelper
    {
        private const string originPath = @"C:\Users\Fernando.Fawcett\Downloads";
        private const string sourcePath = @"C:\Source code\Personal Projects\HomeManager\Docs";
        private const string targetPath = @"C:\Source code\Personal Projects\HomeManager\Docs\Processed";

        public static bool ProccessFiles()
        {
            var fileName = string.Empty;
            var destFile = string.Empty;
            if (Directory.Exists(originPath))
            {
                string[] fileEntries = Directory.GetFiles(originPath, "41207160_*");
                Directory.CreateDirectory(sourcePath);
                foreach (var file in fileEntries)
                {
                    fileName = Path.GetFileName(file);
                    destFile = Path.Combine(sourcePath, fileName);
                    File.Move(file, destFile);
                }
            }
            return false;
        }
        public static List<TransactionDto> FileReader()
        {
            List<TransactionDto> transactions = new List<TransactionDto>();
            string[] fileEntries = Directory.GetFiles(sourcePath, "41207160_*");
            var destFile = string.Empty;
            foreach (var fileName in fileEntries) {
                using (var reader = new StreamReader(fileName))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        if (!values[0].Contains("Transaction Date"))
                        {
                            transactions.Add(new TransactionDto
                            {
                                Date = DateTime.Parse(values[0]),
                                Description = values[4],
                                Amount = string.IsNullOrWhiteSpace(values[5]) ? float.Parse(values[6]) : float.Parse(values[5]),
                                Type = string.IsNullOrWhiteSpace(values[5]) ? "Credit" : "Debit"
                            });
                        }
                    }
                }
                destFile = Path.Combine(targetPath, fileName);
                File.Move(fileName, destFile);
            }
            return transactions;
        }
    }
}
