using System.Numerics;
using System.Text.RegularExpressions;

namespace advent_of_code_2025;

public static class Day4
{
    public static void Run()
    {
        Console.WriteLine("--- Day 4: Printing Department ---");

        var input = File.ReadAllText("input/day4.txt").Trim().Split("\n");

        Dictionary<Vector2, char> grid = new Dictionary<Vector2, char>();
        
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                grid.Add(new Vector2(i, j), input[i][j]);
            }
        }



        Console.WriteLine("\tPart 1: " + Part1(grid));
        Console.WriteLine("\tPart 2: " + Part2(grid));
    }

    private static int Part1(Dictionary<Vector2, char> grid)
    {
        int total = 0;

        foreach (var spot in grid)
        {
            if (spot.Value == '@' && GetSurroundingCount(grid, spot.Key) < 4)
            {
                total++;
            }
        }

        return total;
    }
    
    private static int Part2(Dictionary<Vector2, char> grid)
    {
        int total = 0;
        bool removed = true;

        while(removed)
        {
            removed = false;
            
            foreach (var spot in grid)
            {
                
                if (spot.Value == '@' && GetSurroundingCount(grid, spot.Key) < 4)
                {
                    total++;
                    grid[spot.Key] = 'x';
                    removed = true;
                }
            }
        }

        return total;
    }

    private static int GetSurroundingCount(Dictionary<Vector2, char> grid, Vector2 spot)
    {
        var tally = 0;

        List<Vector2> cardinals = new List<Vector2>
        {
            new (spot.X - 1, spot.Y - 1),
            new (spot.X - 1, spot.Y),
            new (spot.X - 1, spot.Y + 1),
            new (spot.X, spot.Y - 1),
            new (spot.X, spot.Y + 1),
            new (spot.X + 1, spot.Y - 1),
            new (spot.X + 1, spot.Y),
            new (spot.X + 1, spot.Y + 1)
        };

        foreach (var cardinal in cardinals)
        {
            if (grid.ContainsKey(cardinal) && grid[cardinal] == '@')
                tally++;
        }

        return tally;
    }
}