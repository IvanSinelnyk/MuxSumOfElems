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
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                decimal tempMaxSum = 0m;
                string[] numbers = lines[i].Split(',');
                foreach (string number in numbers)
                {
                    if (decimal.TryParse(number, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal temp))
                    {
                        tempMaxSum += temp;
                    }
                    else
                    {
                        brokenLines.Add(i + 1);
                        tempMaxSum = 0m;
                        break;
                    }
                }
                if (tempMaxSum > maxSum)
                {
                    maxSum = tempMaxSum;
                    numberMaxSumLine = i + 1;
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
