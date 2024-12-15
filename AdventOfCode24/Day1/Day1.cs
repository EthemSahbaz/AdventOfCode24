using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24.Day1;
internal static class Day1
{
    public static void Part1()
    {
        var lines = File.ReadLines("Day1.txt");
        var linesCount = lines.Count();

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        for (int i = 0; i < linesCount; i++)
        {
            var line = lines.ElementAt(i);
            var split = line.Split(new[] { "   " }, StringSplitOptions.None);

            left.Add(int.Parse(split[0]));
            right.Add(int.Parse(split[1]));
        }

        left.Sort();
        right.Sort();

        var totalDistance = 0;

        for (int i = 0; i < left.Count; i++)
        {
            var leftLine = left.ElementAt(i);
            var rightLine = right.ElementAt(i);

            if (leftLine > rightLine)
            {
                totalDistance += leftLine - rightLine;
            }

            if (rightLine > leftLine)
            {
                totalDistance += rightLine - leftLine;
            }
        }

        //Answer : 1388114
    }
}
