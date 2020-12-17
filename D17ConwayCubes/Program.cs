using System;
using System.IO;
using System.Linq;

namespace D17ConwayCubes
{
    public class Program
    {
        public const string InputTxt = "input.txt";
        public const string Input2Txt = "input2.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt).ToList();

            var infiniteCube = new InfiniteCube();

            for (var i = 0; i < strings.Count; i++)
            for (var j = 0; j < strings[i].Length; j++)
                infiniteCube.Set(i, j, 0, strings[i][j]);

            for (var i = 0; i < 6; i++)
                infiniteCube.ApplyRules();

            Console.WriteLine(infiniteCube.GetNumberOfActiveCell());

            var infiniteHyperCube = new InfiniteHyperCube();

            for (var i = 0; i < strings.Count; i++)
            for (var j = 0; j < strings[i].Length; j++)
                infiniteHyperCube.Set(i, j, 0, 0, strings[i][j]);

            for (var i = 0; i < 6; i++)
                infiniteHyperCube.ApplyRules();

            Console.WriteLine(infiniteHyperCube.GetNumberOfActiveCell());

            Console.ReadKey();
        }
    }
}