using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PasswordPhilosophy
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        static void Main()
        {
            var strings = File.ReadLines(InputTxt).ToList();

            Console.WriteLine($"Total :{CheckMinMax(strings)}");
            Console.WriteLine($"Total :{CheckPosition(strings)}");

            Console.ReadKey();
        }

        public static int CheckPosition(IEnumerable<string> strings)
        {
            var total = 0;
            foreach (var s in strings)
            {
                var (password, letter, p1, p2) = ParseString(s);

                if (!IsInP1XOrP2(password, letter, p1, p2)) continue;
                Debug.WriteLine($"P1 : {p1} P2 : {p2} Letter : {letter} String : {password}");
                total++;
            }

            return total;
        }

        private static bool IsInP1XOrP2(string toTest, char letter, int p1, int p2)
        {
            return (toTest[p2 - 1] == letter || toTest[p1 - 1] == letter) && toTest[p1 - 1] != toTest[p2 - 1];
        }

        public static int CheckMinMax(IEnumerable<string> strings)
        {
            var total = 0;
            foreach (var s in strings)
            {
                var (password, letter, min, max) = ParseString(s);

                if (!IsInMinMax(password.Count(c => c == letter), min, max)) continue;
                Debug.WriteLine($"Min : {min} Max : {max} Letter : {letter} String : {password}");
                total++;
            }

            return total;
        }

        private static bool IsInMinMax(int count, int min, int max)
        {
            return count >= min && count <= max;
        }

        private static (string toTest, char letter, int min, int max) ParseString(string s)
        {
            var split = s.Split('-', ' ', ':', ' ');
            var password = split[4];
            var letter = split[2].Single();
            var n1 = int.Parse(split[0]);
            var n2 = int.Parse(split[1]);
            return (password, letter, n1, n2);
        }
    }
}
