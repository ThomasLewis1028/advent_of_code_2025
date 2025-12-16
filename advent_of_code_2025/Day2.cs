using System.Text.RegularExpressions;

namespace advent_of_code_2025;

public static class Day2
{
    public static void Run()
    {
        Console.WriteLine("--- Day 2: Gift Shop ---");

        var input = File.ReadAllText("input/day2.txt").Trim();

        List<(Int64 first, Int64 last)> ranges =
            input
                .Replace("\n", "")
                .Split(",")
                .Select(x => { return (Int64.Parse(x.Split("-")[0]), Int64.Parse(x.Split("-")[1])); })
                .ToList();

        Console.WriteLine("\tPart 1: " + Part1(ranges));
        Console.WriteLine("\tPart 2: " + Part2(ranges));
    }

    private static Int64 Part1(List<(Int64 first, Int64 last)> ranges)
    {
        Int64 tally = 0;

        foreach (var range in ranges)
        {
            for (Int64 i = range.first; i <= range.last; i++)
            {
                var val = i.ToString();

                if (val.Length % 2 != 0)
                    continue;

                var val1 = val.Substring(0, val.Length / 2);
                var val2 = val.Substring(val.Length / 2);

                if (val1 == val2)
                {
                    tally += i;
                }
            }
        }

        return tally;
    }

    private static Int64 Part2(List<(Int64 first, Int64 last)> ranges)
    {
        Int64 tally = 0;
        List<Int64> matches = new List<Int64>();

        foreach (var range in ranges)
        {
            for (Int64 i = range.first; i <= range.last; i++)
            {
                var val = i.ToString();

                for (int chunk = 1; chunk < val.Length; chunk++)
                {
                    if (val.Length % chunk != 0)
                        continue;
                    
                    List<string> chunks = new List<string>();
                    
                    for (int j = 0; j < val.Length; j+=chunk)
                    {
                        chunks.Add(val.Substring(j, chunk));
                    }

                    if (chunks.All(c => c == chunks[0]))
                    {
                        tally += i;
                        break;
                    }
                }
            }
        }

        return tally;
    }
}