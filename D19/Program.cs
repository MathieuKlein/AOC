using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D19MonsterMessages
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt).ToList();

            var rulesString = new List<string>();
            var i = 0;
            while (strings[i].Length > 0)
            {
                rulesString.Add(strings[i]);
                i++;
            }

            i++;
            var inputs = new List<string>();
            while (i < strings.Count && strings[i].Length > 0)
            {
                inputs.Add(strings[i]);
                i++;
            }

            var messageValidator = new MessageValidator(rulesString, inputs.Max(x => x.Length));
            Console.WriteLine(messageValidator.GetValidMessages(inputs).Count());
            Console.WriteLine(messageValidator.GetValidMessages2(inputs).Count());

            Console.ReadKey();
        }
    }
}