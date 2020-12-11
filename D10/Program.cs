using System;
using System.IO;

namespace D10AdapterArray
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);
            var solver = new Solver(strings);


            var numbersOfOneAndThreeGaps = solver.GetNumbersOfOneAndThreeGaps();
            Console.WriteLine(numbersOfOneAndThreeGaps.x * numbersOfOneAndThreeGaps.y);

            Console.WriteLine(solver.GetNumberOfPathFromOutletToDevice());

            Console.ReadKey();
        }
    }
}