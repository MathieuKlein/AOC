using System;
using System.Collections.Generic;
using System.Linq;

namespace D15RambunctiousRecitation
{
    public class Program
    {
        public const string Input = "18,8,0,5,4,1,20";

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var numbers = Input.Split(',');


            Console.WriteLine(GetValueAtN(numbers, 2020));
            Console.WriteLine(GetValueAtN(numbers, 30000000));
            Console.ReadKey();
        }

        public static int GetValueAtN(string[] input, int n)
        {
            var inputNumbers = input.Select(int.Parse).ToList();
            var valueLastIndexDict = new Dictionary<int, int>();
            for (var index = 0; index < inputNumbers.Count - 1; index++)
                valueLastIndexDict[inputNumbers[index]] = index;

            var lastAdded = inputNumbers[^1];
            for (var i = inputNumbers.Count; i < n; i++)
                if (!valueLastIndexDict.ContainsKey(lastAdded))
                {
                    valueLastIndexDict[lastAdded] = i - 1;
                    lastAdded = 0;
                }
                else
                {
                    var calc = i - 1 - valueLastIndexDict[lastAdded];
                    valueLastIndexDict[lastAdded] = i - 1;
                    lastAdded = calc;
                }

            return lastAdded;
        }
    }
}