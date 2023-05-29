using MaxSumOfElems;
using System;

namespace MaxSumElemsTests
{
    [TestClass]
    public class MaxSumTests
    {
        [DataTestMethod]
        [DataRow(@"..\..\..\TestFiles\TestData1.txt", 3)]
        [DataRow(@"..\..\..\TestFiles\TestData2.txt", 9)]
        [DataRow(@"..\..\..\TestFiles\TestData3.txt", 0)]
        public void LineNumberWithMaxSumOfElemsTest(string path, int expected)
        {
            FileProcessor target = new(path);
            int actual = target.LineNumberWithMaxSumOfElems();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(@"..\..\..\TestFiles\TestData1.txt", "1 2 4 8 11 12 13 15 ")]
        [DataRow(@"..\..\..\TestFiles\TestData2.txt", "1 4 8 11 12 13 15 ")]        
        [DataRow(@"..\..\..\TestFiles\TestData3.txt", "")]
        public void GetTxtFileWithBrokenLines(string path, string expected)
        {
            string brokenLineListPath = @"..\..\..\BrokenLinesList.txt";
            FileProcessor target = new(path);
            using (StreamWriter writer = new(brokenLineListPath))
            {
                foreach (int number in target.BrokenLines)
                {
                    writer.Write(number + " ");
                }
            }
            string[] actualList = File.ReadAllLines(brokenLineListPath);
            string actual = string.Join(" ", actualList);

            Assert.AreEqual(expected, actual);
        }
    }
}