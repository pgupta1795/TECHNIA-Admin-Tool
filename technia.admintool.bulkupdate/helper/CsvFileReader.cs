using System.Dynamic;
using technia.admintool.settings;

namespace technia.admintool.bulkupdate
{
    public class CsvFileReader
    {
        private string fileName = "";

        private string fileContent = "";

        public char delimiter = ';';

        public CsvFileReader()
        {
            Logger.Info("Reading CSV File ... ");
        }

        public bool TryGetFileContent()
        {
            using OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() != DialogResult.OK) return false;
            fileName = fileDialog.FileName;
            fileContent = File.ReadAllText(fileName);
            delimiter = DetectDelimiter(fileContent);
            return true;
        }

        public List<ExpandoObject> ReadCsvLines()
        {
            List<ExpandoObject> records = new();

            using (var reader = new StreamReader(fileName))
            {
                string[] headers = reader.ReadLine().Split(delimiter);

                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split(delimiter);
                    dynamic record = new ExpandoObject();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        var header = headers[i].ToLower();
                        var cell = data[i];
                        ((IDictionary<string, object>)record)[header] = cell;
                    }
                    records.Add(record);
                }
            }
            return records;
        }

        public string GetFileName()
        {
            Logger.Info("File Path: " + fileName);
            return fileName;
        }

        public string GetFileContent()
        {
            return fileContent;
        }

        private static char DetectDelimiter(string content)
        {
            int commaCount = content.FirstLine().Count(c => c == ',');
            int tabCount = content.FirstLine().Count(c => c == '\t');
            return commaCount > tabCount ? ',' : '\t';
        }
    }

    internal static class StringExtensions // Extension to get first line from a multi-line string
    {
        public static string FirstLine(this string str)
        {
            int index = str.IndexOf(Environment.NewLine);
            return index == -1 ? str : str.Substring(0, index);
        }
    }
}