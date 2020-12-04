using System;
using System.IO;
using System.Linq;

namespace PasswordPhilosophy
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        private static void Main()
        {
            var strings = File.ReadLines(InputTxt).ToList();

            var naiveSolver = new NaiveSolver(strings);
            Console.WriteLine($"Total :{naiveSolver.CheckMinMax()}");
            Console.WriteLine($"Total :{naiveSolver.CheckPosition()}");

            Console.WriteLine(new ExpandedSolver(new IsBetweenMinAndMaxStrategy()).CountValidForRule(strings));
            Console.WriteLine(new ExpandedSolver(new IsInPosition1XOrPosition2Strategy()).CountValidForRule(strings));

            Console.ReadKey();
        }
    }
}