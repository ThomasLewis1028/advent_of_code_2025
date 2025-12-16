using System.Text.RegularExpressions;

namespace advent_of_code_2025;

public static class Day3
{
    public static void Run()
    {
        Console.WriteLine("--- Day 3: Lobby ---");

        var input = File.ReadAllText("input/day3.txt").Trim();

        List<int> banks =
            input
                .Split("\n")
                .Select(x => { return (int.Parse(x)); })
                .ToList();

        Console.WriteLine("\tPart 1: " + Part1(banks));
        // Console.WriteLine("\tPart 2: " + Part2(ranges));
    }

    private static Int64 Part1(List<int> banks)
    {
        int total = 0;

        foreach (var bank in banks)
        {
            List<int> batteries = bank.ToString().Select(b => b - '0').ToList();

            var first = 0;
            var second = 0;
            var firstIndex = 0;
                
            for(int i = 0; i < batteries.Count-1; i++)
            {
                if (batteries[i] > first)
                {
                    first = batteries[i];
                    firstIndex = i;
                }
            }
            
            
            
        }
        

        return total;
    }
}