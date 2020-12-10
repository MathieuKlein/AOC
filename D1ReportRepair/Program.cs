using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReportRepair
{
    public class Program
    {
        public const int SumToFind = 2020;
        public const string InputTxt = "input.txt";

        private static void Main(string[] args)
        {
            var numbers = ReadInput(InputTxt);

            var naiveSolver = new NaiveSolver(numbers);

            var (n1, n2) = naiveSolver.Get2NumbersWithSumEqualTo(SumToFind);
            Console.WriteLine($"{n1} + {n2} = {n1 + n2} ; {n1} * {n2} = {n1 * n2}");

            var (nb1, nb2, nb3) = naiveSolver.Get3NumbersWithSumEqualTo(SumToFind);
            Console.WriteLine($"{nb1} + {nb2} + {nb3} = {nb1 + nb2 + nb3} ; {nb1} * {nb2} * {nb3} = {nb1 * nb2 * nb3}");

            var expandedSolver = new ExpandedSolver(numbers);

            Console.WriteLine(expandedSolver.GetNNumbersWithSumEqualTo(2, SumToFind));
            Console.WriteLine(expandedSolver.GetNNumbersWithSumEqualTo(3, SumToFind));

            Console.ReadKey();
        }


        public static IReadOnlyList<long> ReadInput(string inputTxt)
        {
            var strings = File.ReadLines(inputTxt);
            return strings.Select(long.Parse).OrderBy(x => x).ToList();
        }
    }
}