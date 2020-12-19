using System.Collections.Generic;
using System.Linq;

namespace D19MonsterMessages
{
    public class MessageValidator
    {
        private const string RuleA = "\"a\"";
        private const string RuleB = "\"b\"";
        private const string RuleZero = "0";
        private readonly int _maxLength;
        private readonly Dictionary<string, Rule> _rules = new();
        private Dictionary<string, List<string>>? _cache;

        public MessageValidator(IEnumerable<string> rulesString, int maxLength = int.MaxValue)
        {
            _maxLength = maxLength;
            foreach (var s in rulesString)
            {
                var split = s.Split(':');
                _rules.Add(split[0], new Rule(split[1]));
            }
        }

        public IEnumerable<string> GetValidMessages(List<string> messages)
        {
            _cache = new Dictionary<string, List<string>>();
            var allPossibleMessages = BuildAllPossibleMessages(RuleZero);
            _cache.Clear();
            return messages.Where(x => allPossibleMessages.Contains(x));
        }

        private List<string> BuildAllPossibleMessages(string ruleNumber)
        {
            if (_cache != null && _cache.ContainsKey(ruleNumber))
                return _cache[ruleNumber];
            switch (ruleNumber)
            {
                case RuleA:
                    return new List<string> { "a" };
                case RuleB:
                    return new List<string> { "b" };
            }

            var rule = _rules[ruleNumber];

            var leftRules = BuildAllPossibleMessages(rule.Rule1).Where(item => item.Length <= _maxLength).ToList();
            _cache?.TryAdd(rule.Rule1, leftRules);
            if (rule.Rule2 != null)
            {
                var list = new List<string>();
                var rule2 = BuildAllPossibleMessages(rule.Rule2);
                _cache?.TryAdd(rule.Rule2, rule2);
                foreach (var a in leftRules)
                foreach (var b in rule2)
                    if (a.Length + b.Length <= _maxLength)
                        list.Add(a + b);

                leftRules = list;
            }

            if (rule.Rule3 == null)
                return leftRules;

            var rightRules = BuildAllPossibleMessages(rule.Rule3).Where(item => item.Length <= _maxLength).ToList();
            _cache?.TryAdd(rule.Rule3, rightRules);

            if (rule.Rule4 != null)
            {
                var list = new List<string>();
                var ruleD = BuildAllPossibleMessages(rule.Rule4).Where(item => item.Length <= _maxLength).ToList();
                _cache?.TryAdd(rule.Rule4, ruleD);

                foreach (var a in rightRules)
                foreach (var b in ruleD)
                    if (a.Length + b.Length <= _maxLength)
                        list.Add(a + b);

                rightRules = list;
            }

            return leftRules.Concat(rightRules).ToList();
        }

        public IEnumerable<string> GetValidMessages2(List<string> inputs)
        {
            _rules["8"] = new Rule("42 | 42 8");
            _rules["11"] = new Rule("42 31 | 42 11 31");
            foreach (var input in inputs)
            {
                var verifyInput = VerifyInput(input, new List<string> { RuleZero });
                if (verifyInput)
                    yield return input;
            }
        }

        private bool VerifyInput(string input, IReadOnlyCollection<string> rules)
        {
            if (input.Length > 1 && !rules.Any())
                return false;

            var nextRules = rules.Skip(1).ToList();

            switch (rules.First())
            {
                case RuleA:
                    return input.StartsWith("a") && (input.Length == 1 && rules.Count == 1 || VerifyInput(input.Substring(1), nextRules));
                case RuleB:
                    return input.StartsWith("b") && (input.Length == 1 && rules.Count == 1 || VerifyInput(input.Substring(1), nextRules));
            }

            var rule = _rules[rules.First()];

            var leftRules = new List<string> { rule.Rule1 };
            if (rule.Rule2 != null)
                leftRules.Add(rule.Rule2);
            leftRules.AddRange(nextRules);

            if (rule.Rule3 == null)
                return VerifyInput(input, leftRules);

            var rightRules = new List<string> { rule.Rule3 };
            if (rule.Rule4 != null)
                rightRules.Add(rule.Rule4);
            if (rule.Rule5 != null)
                rightRules.Add(rule.Rule5);
            rightRules.AddRange(nextRules);

            return VerifyInput(input, leftRules) || VerifyInput(input, rightRules);
        }
    }
}