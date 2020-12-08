using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace D7HandyHaversacks
{
    public class BagRule
    {
        private const string MainColor = "MainColor";
        private const string Color = "Color";
        private const string Number = "Number";

        public BagRule(string s)
        {
            var regexpMainBag = Regex.Match(s, "^(?<MainColor>[a-z]+\\s[a-z]+)\\sbags\\s.*");
            MainBagColor = regexpMainBag.Groups[MainColor].Value;

            var regexBagsInside = Regex.Match(s, "(,?\\s(?<Number>[0-9])\\s(?<Color>[a-z]+\\s[a-z]+)\\sbags*)*\\.$");
            for (var i = 0; i < regexBagsInside.Groups[Color].Captures.Count; i++)
            {
                var capture = regexBagsInside.Groups[Color].Captures[i];
                ContainedBags[capture.Value] = int.Parse(regexBagsInside.Groups[Number].Captures[i].Value);
            }
        }

        public Dictionary<string, int> ContainedBags { get; } = new Dictionary<string, int>();

        public string MainBagColor { get; set; }

        public bool ContainsBag(string color)
        {
            return ContainedBags.ContainsKey(color);
        }
    }
}