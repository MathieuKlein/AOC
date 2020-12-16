using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace D16TicketTranslation
{
    public class Rule
    {
        private static readonly Regex RegexRule = new Regex("([\\w\\s]+): ([\\d]+)-([\\d]+) or ([\\d]+)-([\\d]+)");

        public Rule(string s)
        {
            var split = RegexRule.Split(s);
            Name = split[1];
            Range1From = int.Parse(split[2]);
            Range1To = int.Parse(split[3]);
            Range2From = int.Parse(split[4]);
            Range2To = int.Parse(split[5]);
        }

        public int Range2To { get; set; }

        public int Range2From { get; set; }

        public int Range1To { get; set; }

        public int Range1From { get; set; }

        public string Name { get; }

        public List<int> Indexes { get; set; } = new List<int>();

        public override string ToString()
        {
            return $"{Name} {Range1From} {Range1To} {Range2From} {Range2To}";
        }

        public bool IsInRange1(int val)
        {
            return val >= Range1From && val <= Range1To;
        }

        public bool IsInRange2(int val)
        {
            return val >= Range2From && val <= Range2To;
        }
    }
}