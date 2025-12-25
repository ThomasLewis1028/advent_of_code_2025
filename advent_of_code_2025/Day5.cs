using System.Numerics;
using System.Text.RegularExpressions;

namespace advent_of_code_2025;

public static class Day5
{
    public static void Run()
    {
        Console.WriteLine("--- Day 5: Cafeteria ---");

        var input = File.ReadAllText("input/day5.txt").Trim().Split("\n\n");

        List<(Int128 low, Int128 high)> ranges = input[0].Split("\n")
            .Select(x => (Int128
                .Parse(x.Split('-')[0]), Int128.Parse(x.Split('-')[1])))
            .ToList();

        List<Int128> ingredients = input[1].Split("\n").Select(x => { return Int128.Parse(x); }).ToList();

        Console.WriteLine("\tPart 1: " + Part1(ranges, ingredients));
        Console.WriteLine("\tPart 2: " + Part2(ranges));
    }

    private static int Part1(List<(Int128 low, Int128 high)> ranges, List<Int128> ingredients)
    {
        int tally = 0;

        foreach (var ingredient in ingredients)
        {
            foreach (var range in ranges)
            {
                if (ingredient >= range.low && ingredient <= range.high)
                {
                    tally++;
                    break;
                }
            }
        }

        return tally;
    }
    
    private static Int128 Part2(List<(Int128 low, Int128 high)> ranges)
    {
        var index = 0;
        var aggregrated = true;
    
        while (aggregrated)
        {
            aggregrated = false;
    
            for (var i = 0; i < ranges.Count; i++)
            {
                var range = ranges[i];
    
                foreach (var range2 in ranges.Skip(i + 1))
                {
                    (Int128 low, Int128 high) tempRange = new();
    
                    // Range is the original, Range2 is the future
                    
                    // Low in
                    if (range2.low >= range.low && range2.low <= range.high)
                    {
                        // High out
                        if (range2.high >= range.high)
                        {
                            tempRange = (range.low, range2.high);
                            ranges.Add(tempRange);
                        }
    
                        ranges.Remove(range2);
                        aggregrated = true;
                    }
                    // High in
                    else if (range2.high <= range.high && range2.high >= range.low)
                    {
                        // Low out
                        if (range2.low <= range.low)
                        {
                            tempRange = (range2.low, range.high);
                            ranges.Add(tempRange);
                        }
    
                        ranges.Remove(range2);
                        aggregrated = true;
                    }
                    // High out, low out, encompassing
                    else if (range2.high >= range.high && range2.low <= range.low)
                    {
                        ranges.Remove(range);
                        aggregrated = true;
                    }
                    // High out, low out, non-encompassing
                    else
                    {
                        aggregrated = false;
                    }
                }
            }
        }
    
        Int128 sum = 0;
    
        foreach (var range in ranges)
        {
            sum += (range.high) - (range.low) + 1;
        }
    
        return sum;
    }
}