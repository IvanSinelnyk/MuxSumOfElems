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

        private readonly List<int> brokenLines = new();
        public int[] BrokenLines
        {
            get
            {
                if (brokenLines.Any())
                {
                    return brokenLines.ToArray();
                }
                else
                {
                    LineNumberWithMaxSumOfElems();
                    return brokenLines.ToArray();
                }
            }
        }

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
            brokenLines.Clear();
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
                            brokenLines.Add(currentLine);
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

        public void GetTxtFileWithBrokenLines()
        {
            using (StreamWriter writer = new(@"..\..\..\..\BrokenLinesList.txt"))
            {
                foreach (int number in BrokenLines)
                {
                    writer.Write(number + " ");
                }
            }
        }
    }
}
