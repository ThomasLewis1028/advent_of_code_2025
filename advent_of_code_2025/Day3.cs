using System.Text.RegularExpressions;

namespace advent_of_code_2025;

public static class Day3
{
    public static void Run()
    {
        Console.WriteLine("--- Day 3: Lobby ---");

        var input = File.ReadAllText("input/day3.txt").Trim();

        List<string> banks =
            input
                .Split("\n")
                .ToList();

        Console.WriteLine("\tPart 1: " + Part1(banks));
        Console.WriteLine("\tPart 2: " + Part2(banks));
    }

    private static Int128 Part1(List<string> banks)
    {
        Int128 total = 0;

        foreach (var bank in banks)
        {
            List<int> batteries = bank.Select(b => b - '0').ToList();

            var first = 0;
            var second = 0;
            var firstIndex = 0;

            for (int i = 0; i < batteries.Count - 1; i++)
            {
                if (batteries[i] > first)
                {
                    first = batteries[i];
                    firstIndex = i;
                }
            }

            for (int i = firstIndex + 1; i < batteries.Count; i++)
            {
                if (batteries[i] > second)
                {
                    second = batteries[i];
                }
            }

            total += Int128.Parse(first + second.ToString());
        }

        return total;
    }

    private static Int128 Part2(List<string> banks)
    {
        Int128 total = 0;
        List<Int128> matches = new List<Int128>();

        foreach (var bank in banks)
        {
            List<int> batteries = bank.Select(b => b - '0').ToList();

            List<int> batArray = new List<int>();
            var index = 0;

            for (int i = 0; i < 12; i++)
            {
                batArray.Add(0);

                for (int j = index; j < batteries.Count - 12 + batArray.Count; j++)
                {
                    if (batteries[j] > batArray[i])
                    {
                        batArray[i] = batteries[j];

                        index = j+1;
                    }
                }
            }

            total += Int128.Parse(batArray.Aggregate("", (a, b) => a + b));
            matches.Add(Int128.Parse(batArray.Aggregate("", (a, b) => a + b)));
        }

        return total;
    }
}