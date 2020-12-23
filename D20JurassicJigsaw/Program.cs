using System;
using System.IO;
using System.Linq;

namespace D20JurassicJigsaw
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);


            var jigsawSolver = new JigsawSolver(strings);
            var corners = jigsawSolver.GetCorners();
            Console.WriteLine(corners.Aggregate((x, y) => x * y));
            var solved = jigsawSolver.Solve();
            Console.WriteLine(jigsawSolver.CountMonsters(solved));

            Console.ReadKey();
        }
    }
}