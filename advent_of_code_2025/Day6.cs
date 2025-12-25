using System.Text.RegularExpressions;

namespace advent_of_code_2025;

public static class Day6
{
    public static void Run()
    {
        Console.WriteLine("--- Day 6: Trash Compactor ---");

        var input = File.ReadAllText("input/day6.txt")
            .Trim()
            .Split("\n")
            .ToList()
            .Select(x => x.Trim())
            .Select(x => Regex.Split(x, " +")
                .ToList())
            .ToList();

        Dictionary<int, (List<long> numbers, char operand)> columns = new();

        foreach (var row in input.Take(input.Count - 1))
        {
            for (var i = 0; i < row.Count; i++)
            {
                if (!columns.ContainsKey(i))
                {
                    columns.Add(i, new ValueTuple<List<long>, char>([], Char.Parse(input.Last()[i])));
                }
        
                columns[i].numbers.Add(long.Parse(row[i]));
            }
        }
        
        Console.WriteLine("\tPart 1: " + Part1(columns));
        // Console.WriteLine("\tPart 2: " + Part2(ranges));
    }

    private static Int128 Part1(Dictionary<int, (List<long> numbers, char operand)> columns)
    {
        long grandTotal = 0;

        foreach (var column in columns)
        {
            if (column.Value.operand == '+')
            {
                grandTotal += column.Value.numbers.Sum(x => x);
            }else if (column.Value.operand == '*')
            {
                grandTotal += column.Value.numbers.Aggregate((x, y) => x * y);
            }
        }


        return grandTotal;
    }
}