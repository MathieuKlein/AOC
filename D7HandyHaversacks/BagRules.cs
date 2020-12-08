using System.Collections.Generic;
using System.Linq;

namespace D7HandyHaversacks
{
    public class BagRules
    {
        private readonly Dictionary<string, BagRule> _rules = new Dictionary<string, BagRule>();

        public BagRules(IEnumerable<string> strings)
        {
            foreach (var s in strings)
            {
                var bagRule = new BagRule(s);
                _rules.Add(bagRule.MainBagColor, bagRule);
            }
        }

        public HashSet<string> GetBagThatCanContain(string color)
        {
            var bagRulesContainingColor = _rules.Values.Where(x => x.ContainsBag(color));
            var toExplore = bagRulesContainingColor.ToList();
            var bags = new HashSet<string>();

            while (toExplore.Count != 0)
            {
                var bagRule = toExplore[0];
                bags.Add(bagRule.MainBagColor);
                toExplore.AddRange(_rules.Values.Where(x => x.ContainsBag(bagRule.MainBagColor)));
                toExplore.RemoveAt(0);
            }

            return bags;
        }

        public int CountBagsInside(string shinyGold)
        {
            return _rules[shinyGold].ContainedBags.Sum(x => x.Value + x.Value * CountBagsInside(x.Key));
        }
    }
}