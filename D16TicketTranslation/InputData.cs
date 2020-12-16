using System.Collections.Generic;

namespace D16TicketTranslation
{
    public class InputData
    {
        private readonly List<Ticket> _nearbyTickets = new List<Ticket>();
        private readonly List<Rule> _rules = new List<Rule>();

        public InputData(IReadOnlyList<string> strings)
        {
            var i = 0;
            while (strings[i].Length > 0)
            {
                var rule = new Rule(strings[i]);
                _rules.Add(rule);
                i++;
            }

            i += 2;

            MyTicket = new Ticket(strings[i]);

            i += 3;

            for (var j = i; j < strings.Count; j++)
                _nearbyTickets.Add(new Ticket(strings[j]));
        }

        public IReadOnlyList<Rule> Rules => _rules;

        public Ticket MyTicket { get; }

        public IReadOnlyList<Ticket> NearbyTickets => _nearbyTickets;
    }
}