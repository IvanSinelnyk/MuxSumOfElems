using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumOfElems
{
    internal class FileProcessor
    {
        private readonly string path;

        public FileProcessor(string? path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            this.path = path;
        }

        public int LineNumberWithMaxSumOfElems()
        {
            int numberMaxSumLine = 0;
            decimal maxSum = 0m;
            using (FileStream fileStream = new(path, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new(fileStream))
            {
                int currentLine = 0;
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    ++currentLine;
                    decimal tempMaxSum = 0m;
                    string[] numbers = line.Split(',');
                    foreach (string number in numbers)
                    {
                        if (decimal.TryParse(number, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal temp))
                        {
                            tempMaxSum += temp;
                        }
                        else
                        {
                            tempMaxSum = 0m;
                            break;
                        }
                    }
                    if (tempMaxSum > maxSum)
                    {
                        maxSum = tempMaxSum;
                        numberMaxSumLine = currentLine;
                    }
                }
            }
            return numberMaxSumLine;
        }

        public int[] GetListOfBrokenLines()
        {
            var list = new List<int>();
            using (FileStream fileStream = new(path, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new(fileStream))
            {
                int currentLine = 0;
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    ++currentLine;
                    string[] numbers = line.Split(',');
                    foreach (string number in numbers)
                    {
                        if (!decimal.TryParse(number, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal _))
                        {
                            list.Add(currentLine);
                        }
                    }
                }
            }
            var array = list.ToArray();
            return array;
        }

        public void GetTxtFileWithBrokenLines()
        {
            using (StreamWriter writer = new(@"..\..\..\..\BrokenLinesList.txt"))
            {
                int[] result = GetListOfBrokenLines();
                foreach (int number in result)
                {
                    writer.Write(number + " ");
                }
            }
        }
    }
}
