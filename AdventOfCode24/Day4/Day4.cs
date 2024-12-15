using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24.Day4;
internal static class Day4
{

    public static void Part1()
    {
        var input = File.ReadLines("Day4/Day4.txt");

        var x = input.First().Length;
        var y = input.Count();
        string[,] chars = new string[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                var line = input.ElementAt(i);
                chars[i, j] = line[j].ToString();
            }
        }

        List<string> result = new List<string>();
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                string leftRight = string.Empty;
                string rightLeft = string.Empty;
                string upDown = string.Empty;
                string downUp = string.Empty;
                string diagonalUpLeft = string.Empty;
                string diagonalDownRight = string.Empty;
                string diagonalUpRight = string.Empty;
                string diagonalDownLeft = string.Empty;


                // LeftRight & RightLeft
                for (int k = 0; k < 4; k++)
                {
                    int iterator = k + j;
                    if (iterator == 140)
                        break;

                    leftRight += chars[i, iterator];
                }
                result.Add(leftRight);

                var t = leftRight.Reverse();

                foreach (var line in t)
                {
                    rightLeft += line.ToString();
                }

                result.Add(rightLeft);

                // UpDown & DownUp
                for (int k = 0; k < 4; k++)
                {
                    int iterator = k + j;

                    if (iterator == 140)
                        break;

                    upDown += chars[iterator, i];
                }
                result.Add(upDown);

                var u = upDown.Reverse();

                foreach (var line in u)
                {
                    downUp += line.ToString();
                }

                result.Add(downUp);

                //diagonal down right & upleft
                for (int k = 0; k < 4; k++)
                {
                    int iteratorRight = k + j;
                    int iteratorDown = k + i;

                    if (iteratorRight == 140 || iteratorDown == 140)
                        break;


                    diagonalDownRight += chars[iteratorDown, iteratorRight];
                }

                result.Add(diagonalDownRight);

                var d = diagonalDownRight.Reverse();

                foreach (var line in d)
                {
                    diagonalUpLeft += line.ToString();
                }

                result.Add(diagonalUpLeft);

                // Diagonal down left & up right

                for (int k = 0; k < 4; k++)
                {
                    int iteratorleft = j - k;
                    int iteratorDown = k + i;

                    if (iteratorleft == -1 || iteratorDown == 140)
                        break;


                    diagonalDownLeft += chars[iteratorDown, iteratorleft];
                }

                result.Add(diagonalDownLeft);

                var dl = diagonalDownLeft.Reverse();

                foreach (var line in dl)
                {
                    diagonalUpRight += line.ToString();
                }

                result.Add(diagonalUpRight);
            }
        }

        var xmasCount = result.Count(x => x == "XMAS");
        //2662
        Console.ReadLine();


    }
}
