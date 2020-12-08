using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D4PassportProcessing
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);
            var passeports = GetPasseports(strings).ToList();

            var validPasseports = passeports.Count(x => x.ContainsRequiredFields());
            Console.WriteLine(validPasseports);
            var valid2Passeports = passeports.Count(x => x.IsValid());
            Console.WriteLine(valid2Passeports);
            Console.ReadKey();
        }

        public static IEnumerable<Passeport> GetPasseports(IEnumerable<string> strings)
        {
            var linesOfPasseport = new List<string>();

            foreach (var s in strings)
                if (s.Length == 0)
                {
                    yield return new Passeport(linesOfPasseport);
                    linesOfPasseport.Clear();
                }
                else
                {
                    linesOfPasseport.Add(s);
                }

            yield return new Passeport(linesOfPasseport);
        }
    }
}