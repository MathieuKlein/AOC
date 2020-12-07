using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D6CustomCustoms
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);
            var groups = GetGroup(strings);

            Console.WriteLine(groups.Select(x => x.LettersOnceYes.Count).Sum());
            Console.WriteLine(groups.Select(x => x.GetAllQuestionsAnsweredYes().Count()).Sum());

            Console.ReadKey();
        }

        public static IList<Group> GetGroup(IEnumerable<string> strings)
        {
            var groups = new List<Group>();
            var linesOfAGroup = new List<string>();

            foreach (var s in strings)
                if (s.Length == 0)
                {
                    groups.Add(new Group(linesOfAGroup));
                    linesOfAGroup.Clear();
                }
                else
                {
                    linesOfAGroup.Add(s);
                }

            groups.Add(new Group(linesOfAGroup));
            linesOfAGroup.Clear();
            return groups;
        }
    }
}