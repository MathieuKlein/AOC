using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TobogganTrajectory
{
    public class Program
    {
        public static readonly List<(int, int)> SlopesBonus = new List<(int, int)> { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) };
        public const string InputTxt = "input.txt";

        private static void Main(string[] args)
        {
            var lines = File.ReadLines(InputTxt).ToList();
            var slopes = new List<(int, int)> { (1, 3) };

            var treeChecker = new TreeChecker(lines);
            Console.WriteLine(slopes.Select(x => treeChecker.CheckForSlope(x.Item1, x.Item2)).Aggregate((x, y) => x * y));
            Console.WriteLine(SlopesBonus.Select(x => treeChecker.CheckForSlope(x.Item1, x.Item2)).Aggregate((x, y) => x * y));
            Console.ReadKey();
        }
    }
}