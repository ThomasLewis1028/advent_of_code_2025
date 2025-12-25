// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using advent_of_code_2025;

while (true)
{
    int day = 0;

    try
    {
        Console.Write("Select the day: ");
        day = Int32.Parse(Console.ReadLine() ?? string.Empty);
    }
    catch
    {
        Console.Clear();
        Console.WriteLine("Invalid day!\n");
        continue;
    }
    
    Console.Clear();

    var timer = Stopwatch.StartNew();
    
    switch(day)
    {
        case 1:
            Day1.Run();
            break;
        case 2:
            Day2.Run();
            break;
        case 3:
            Day3.Run();
            break;
        case 4:
            Day4.Run();
            break;
        case 5:
            Day5.Run();
            break;
        default:
            break;
    }
    
    Console.WriteLine("\nElapsed Time: " + timer.Elapsed + "\n");
}