using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D16TicketTranslation
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt).ToList();

            var inputData = new InputData(strings);

            var wrongTickets = GetWrongTickets(inputData);

            Console.WriteLine(wrongTickets.Sum(x => x.WrongValue));

            var myValues = GetValueOfMyTicketStartingBy(inputData, "departure");

            Console.WriteLine(myValues.Aggregate((x, y) => x * y));
        }

        public static IEnumerable<WrongTicket> GetWrongTickets(InputData inputData)
        {
            foreach (var ticket in inputData.NearbyTickets)
            foreach (var value in ticket.Values)
            {
                var meetAnyRule = inputData.Rules.Any(rule => rule.IsInRange1(value) || rule.IsInRange2(value));

                if (!meetAnyRule)
                    yield return new WrongTicket(ticket, value);
            }
        }

        public static IEnumerable<long> GetValueOfMyTicketStartingBy(InputData inputData, string startOfRuleName)
        {
            var validTickets = inputData.NearbyTickets.Except(GetWrongTickets(inputData).Select(x => x.Ticket)).ToList();

            var possiblesIndexesByRule = GetPossiblesIndexesByRule(inputData.Rules, validTickets);

            var rulesOrderedByNumberOfPossibleIndex = possiblesIndexesByRule.OrderBy(x => x.Value.Count).Select(x => x.Key).ToList();

            for (var i = 0; i < rulesOrderedByNumberOfPossibleIndex.Count; i++)
            for (var j = i + 1; j < rulesOrderedByNumberOfPossibleIndex.Count; j++)
                possiblesIndexesByRule[rulesOrderedByNumberOfPossibleIndex[j]] = possiblesIndexesByRule[rulesOrderedByNumberOfPossibleIndex[j]]
                                                                                 .Except(possiblesIndexesByRule[rulesOrderedByNumberOfPossibleIndex[i]]).ToList();

            return rulesOrderedByNumberOfPossibleIndex.Where(x => x.Name.StartsWith(startOfRuleName)).Select(rule => (long) inputData.MyTicket.Values[possiblesIndexesByRule[rule].Single()]);
        }

        private static Dictionary<Rule, List<int>> GetPossiblesIndexesByRule(IReadOnlyCollection<Rule> rules, IReadOnlyCollection<Ticket> tickets)
        {
            var rulesPossibleIndexes = new Dictionary<Rule, List<int>>();
            foreach (var rule in rules)
            {
                rulesPossibleIndexes[rule] = new List<int>();
                for (var j = 0; j < rules.Count; j++)
                {
                    var meetAllRules = tickets.Select(x => x.Values[j]).All(value => rule.IsInRange1(value) || rule.IsInRange2(value));

                    if (meetAllRules)
                        rulesPossibleIndexes[rule].Add(j);
                }
            }

            return rulesPossibleIndexes;
        }
    }
}