using MaxSumOfElems;
using System.Globalization;

Console.WriteLine("Enter full path to file:");
string? path = Console.ReadLine();
//path = @"TestData.txt"; // Uncomment this line for testing from TestData.txt.
try
{
    FileProcessor fp = new(path);
    int lineNumberWithMaxSum = fp.LineNumberWithMaxSumOfElems();
    Console.WriteLine("Number of line with maximum sum of numeric elements:");
    Console.WriteLine(lineNumberWithMaxSum);
    int[] brokenLines = fp.GetListOfBrokenLines();
    Console.WriteLine("Numbers of lines with non numeric elements:");
    foreach (int num in brokenLines)
    {
        Console.Write(num + " ");
    }
    fp.GetTxtFileWithBrokenLines();
    Console.WriteLine();
    Console.WriteLine("You can find the list of \"broken\" lines in this file:");
    Console.WriteLine("BrokenLinesList.txt");
}
catch (ArgumentException)
{
    Console.WriteLine("No path was enter.");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Wrong path was enter.");
}

