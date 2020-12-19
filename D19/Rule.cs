using System;

namespace D19MonsterMessages
{
    public class Rule
    {
        public Rule(string s)
        {
            var split = s.Split("|", StringSplitOptions.RemoveEmptyEntries);
            var ruleA = split[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Rule1 = ruleA[0];


            if (ruleA.Length >= 2)
                Rule2 = ruleA[1];

            if (split.Length >= 2)
            {
                var ruleC = split[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Rule3 = ruleC[0];
                if (ruleC.Length >= 2)
                    Rule4 = ruleC[1];

                if (ruleC.Length >= 3)
                    Rule5 = ruleC[2];
            }
        }

        public string? Rule4 { get; set; }
        public string? Rule5 { get; set; }
        public string? Rule3 { get; set; }
        public string? Rule2 { get; set; }
        public string Rule1 { get; set; }
    }
}