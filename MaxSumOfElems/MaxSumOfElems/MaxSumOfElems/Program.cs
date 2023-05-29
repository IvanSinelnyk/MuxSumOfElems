using MaxSumOfElems;
using System.Globalization;

string? path;
do
{
    Console.WriteLine("Enter full path to file:");
    path = Console.ReadLine();
    if (path == "x")
    {
        Environment.Exit(0);
    }
    if (!File.Exists(path))
    {
        Console.WriteLine("Wrong path was enter.\nTo exit enter 'x'.");
    }
} while (!File.Exists(path));

FileProcessor fp = new(path);
int lineNumberWithMaxSum = fp.LineNumberWithMaxSumOfElems();
Console.WriteLine("Number of line with maximum sum of numeric elements:");
Console.WriteLine(lineNumberWithMaxSum);
int[] brokenLines = fp.BrokenLines;
Console.WriteLine("Numbers of lines with non numeric elements:");
foreach (int num in brokenLines)
{
    Console.Write(num + " ");
}