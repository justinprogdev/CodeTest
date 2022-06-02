using CommonLibrary.Extensions;

namespace CommonLibrary.Helpers
{
    public static class DataHelper
    {
        
        /// <summary>
        /// Read data file, return data object
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<string[]> GetData(string fileName)
        {
            //Read Data file by name in the Data directory
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileName);
            string[] lines = ReadFile(path);

            //Split out white space
            List<string[]> records = new List<string[]>();

            //Don't include header or footer
            for(var i = 1; i <lines.Length -1; i++)
            {
                records.Add(lines[i].Split(" ",StringSplitOptions.RemoveEmptyEntries));
            }

            return records;
        }

        /// <summary>
        /// Extention of data
        /// Parse data for the difference of two values
        /// return it as a dictionay to parse
        /// </summary>
        /// <param name="data"></param>
        /// <param name="columnA"></param>
        /// <param name="columnB"></param>
        /// <returns></returns>
        public static Dictionary<string, float> ParseData(this List<string[]> data, int columnA, int columnB, int printRecord)
        {
            //Parse by day and spread
            var parsedData = new Dictionary<string, float>();

            foreach (var record in data)
            {
                if (record.Length < 2) 
                    continue;

                var highNum = record[columnA];
                var lowNum = record[columnB];

                if (highNum.IsNumeric() && lowNum.IsNumeric())
                {
                    parsedData.Add(record[printRecord], highNum.ParseFloat() - lowNum.ParseFloat());
                }
            }

            return parsedData;
        }

        /// <summary>
        /// Get an item by the minium value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static dynamic GetItemByMinimumSpread(this Dictionary<string, float> data)
        {
            //get the smallest spread
            var spread = data.Min(x => Math.Abs(x.Value));

            //get the item by that value
            return data.Where(x => Math.Abs(x.Value).Equals(spread)).First();
        }

        /// <summary>
        /// Read file contents and return the string array
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string[] ReadFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
