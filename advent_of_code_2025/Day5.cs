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
        
        ranges = ranges.OrderBy(x => x.low).ToList();
    
        while (aggregrated)
        {
            aggregrated = false;
    
            for (var i = 0; i < ranges.Count; i++)
            {
                var range = ranges[i];

                for( var j = i + 1; j<ranges.Count; j++)
                {
                    var range2 = ranges[j];
                    (Int128 low, Int128 high) tempRange = new();
    
                    // Range is the original, Range2 is the future
                    
                    // Low in, high in (3-6, 4-5)
                    if (range2.low >= range.low  // Low in
                        && range2.high <= range.high) // High in
                    {
                        // Remove 4-5 in this case
                        ranges.Remove(range2);
                        j--;
                        aggregrated = true;
                    }
                    // Low in, high out (3-6, 4-10)
                    else if (range2.low >= range.low // Low in
                             && range2.low <= range.high+1 // Low in
                             && range2.high > range.high) // High out
                    {
                        // Create a new range with low from original, high from new
                        tempRange.low = range.low;
                        tempRange.high = range2.high;
                        
                        // Remove both ranges as they've been merged
                        ranges[i] = tempRange;
                        ranges.Remove(range2);
                        j--;
                        
                        range = tempRange;
                        aggregrated = true;
                    }
                    // Low out, high in (4-8, 2-5)
                    else if (range2.low <= range.low // Low out
                             && range2.high <= range.high // High in
                             && range2.high >= range.low-1) // High in
                    {
                        // Create a new range with high from original, low from new
                        tempRange.low = range2.low;
                        tempRange.high = range.high;
                        
                        ranges[i] = tempRange;
                        ranges.Remove(range2);
                        j--;
                        
                        range = tempRange;
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

        ranges = ranges.OrderBy(x => x.low).ToList();
    
        Int128 sum = 0;
    
        foreach (var range in ranges)
        {
            sum += (range.high) - (range.low) + 1;
        }
    
        return sum;
    }
}