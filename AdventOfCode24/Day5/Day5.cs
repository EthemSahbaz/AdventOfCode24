using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24.Day5;
internal static class Day5
{
    public static void Part1()
    {

        var input = File.ReadLines("Day5/Day5.txt").ToList();

        int sum = 0;

        var emptyLineIndex = input.IndexOf("");

        List<List<string>> rules = new List<List<string>>();
        List<List<string>> updates = new List<List<string>>();
        // Get Rules
        for (int i = 0; i < emptyLineIndex; i++)
        {
            var line = input[i];

            rules.Add(line.Split('|').ToList());
        }

        // Get Updates
        emptyLineIndex++;

        for (int i = emptyLineIndex; i < input.Count; i++)
        {
            var line = input[i];
            var update = line.Split(",").ToList();

            if (!BreaksAnyRule(rules, update))
            {
                var arrayLenght = update.Count;
                var middleIndex = arrayLenght / 2;

                var value = int.Parse(update[middleIndex]);

                sum += value;
            }
        }


        Console.WriteLine(sum);
    }


    private static bool BreaksAnyRule(List<List<string>> rules, List<string> update)
    {
        foreach (var rule in rules)
        {
            var x = rule[0];
            var y = rule[1];

            if (update.Contains(x) && update.Contains(y))
            {
                var indexOfX = update.IndexOf(x);
                var indexOfY = update.IndexOf(y);

                if (indexOfX > indexOfY)
                {
                    return true;
                }

            }

        }

        return false;
    }
}
