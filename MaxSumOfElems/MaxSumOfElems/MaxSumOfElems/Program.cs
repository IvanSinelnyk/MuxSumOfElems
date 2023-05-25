using MaxSumOfElems;
using System.Globalization;

string? path1;
do
{
    Console.WriteLine("Enter full path to file:");
    path1 = Console.ReadLine();
    path1 = @"TestData.txt"; // Uncomment this line for testing from TestData.txt.
    if (path1 == "x")
    {
        Environment.Exit(0);
    }
    if (!File.Exists(path1))
    {
        Console.WriteLine("Wrong path was enter.\nTo exit enter 'x'.");
    }    
} while (!File.Exists(path1));

FileProcessor fp = new(path1);
int lineNumberWithMaxSum = fp.LineNumberWithMaxSumOfElems();
Console.WriteLine("Number of line with maximum sum of numeric elements:");
Console.WriteLine(lineNumberWithMaxSum);
int[] brokenLines = fp.BrokenLines;
Console.WriteLine("Numbers of lines with non numeric elements:");
foreach (int num in brokenLines)
{
    Console.Write(num + " ");
}
fp.GetTxtFileWithBrokenLines();
Console.WriteLine();
Console.WriteLine("You can find the list of \"broken\" lines in this file:");
Console.WriteLine("BrokenLinesList.txt");


