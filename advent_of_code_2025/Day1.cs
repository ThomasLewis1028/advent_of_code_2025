using System.Text.RegularExpressions;

namespace advent_of_code_2025;

public static class Day1
{
    public static void Run()
    {
        Console.WriteLine("--- Day 1: Secret Entrance ---");

        var input = File.ReadAllText("input/day1.txt").Trim();

        List<(char dir, int val)> rotations =
            input
                .Split("\n")
                .Select(x =>
                {
                    var sub = int.Parse(x.Substring(1));
                    var val = x[0];
                    return (val, sub);
                })
                .ToList();


        Console.WriteLine("\tPart 1: " + Part1(rotations));
        Console.WriteLine("\tPart 2: " + Part2(rotations));
    }

    private static int Part1(List<(char dir, int val)> rotations)
    {
        var dial = 50;
        var tally = 0;

        foreach (var rotation in rotations)
        {
            var spin = 0;
            
            switch (rotation.dir)
            {
                case 'L':

                    while (spin < rotation.val)
                    {
                        spin++;

                        if (dial > 0)
                            dial--;
                        else
                            dial = 99;
                    }

                    break;
                case 'R':

                    while (spin < rotation.val)
                    {
                        spin++;

                        if (dial < 99)
                            dial++;
                        else
                            dial = 0;
                    }

                    break;
            }

            if (dial > 99 || dial < 0)
                throw new Exception("Out of range");

            if (dial == 0)
                tally++;
        }

        return tally;
    }
    
    private static int Part2(List<(char dir, int val)> rotations)
    {
        var dial = 50;
        var tally = 0;

        foreach (var rotation in rotations)
        {
            var spin = 0;
            
            switch (rotation.dir)
            {
                case 'L':

                    while (spin < rotation.val)
                    {
                        spin++;

                        if (dial > 0)
                            dial--;
                        else
                            dial = 99;

                        if (dial == 0)
                            tally++;
                    }

                    break;
                case 'R':

                    while (spin < rotation.val)
                    {
                        spin++;

                        if (dial < 99)
                            dial++;
                        else
                            dial = 0;
                        
                        
                        if (dial == 0)
                            tally++;
                    }

                    break;
            }

            if (dial > 99 || dial < 0)
                throw new Exception("Out of range");
        }

        return tally;
    }
}