using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var (n1, n2) = Get2NumbersWithSumEqualTo(numbers, SumToFind);
            Console.WriteLine($"{n1} + {n2} = {n1 + n2} ; {n1} * {n2} = {n1 * n2}");


            var (nb1, nb2, nb3) = Get3NumbersWithSumEqualTo(numbers, SumToFind);

            Console.WriteLine($"{nb1} + {nb2} + {nb3} = {nb1 + nb2 + nb3} ; {nb1} * {nb2} * {nb3} = {nb1 * nb2 * nb3}");

            Console.ReadKey();
        }

        public static (int n1, int n2, int n3) Get3NumbersWithSumEqualTo(IReadOnlyList<int> numbers, int sumToFind)
        {
            for (var i = 0; i < numbers.Count; i++)
            {
                var n1 = numbers[i];
                for (var j = i; j < numbers.Count; j++)
                {
                    var n2 = numbers[j];
                    var sum = n2 + n1;
                    if (sum > sumToFind)
                        break;
                    for (var k = j; k < numbers.Count; k++)
                    {
                        Debug.WriteLine($"{i} {j} {k}");
                        var n3 = numbers[k];
                        sum = n1 + n2 + n3;
                        if (sum > sumToFind)
                            break;
                        Debug.WriteLine($"{n1} + {n2} + {n3} = {sum}");
                        if (sum != sumToFind)
                            continue;
                        return (n1, n2, n3);
                    }
                }
            }

            return default;
        }

        public static (int n1, int n2) Get2NumbersWithSumEqualTo(IReadOnlyList<int> numbers, int toFind)
        {
            var sumToFind = toFind;
            for (var index = 0; index < numbers.Count; index++)
            {
                var n1 = numbers[index];
                foreach (var n2 in numbers.Skip(index))
                {
                    var sum = n2 + n1;
                    if (sum > sumToFind)
                        break;
                    Debug.WriteLine($"{n1} + {n2} = {sum}");
                    if (sum != sumToFind)
                        continue;
                    return (n1, n2);
                }
            }

            return default;
        }

        public static IReadOnlyList<int> ReadInput(string inputTxt)
        {
            var strings = File.ReadLines(inputTxt);
            return strings.Select(int.Parse).OrderBy(x => x).ToList();
        }
    }
}