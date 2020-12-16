using System.Collections.Generic;

namespace D16TicketTranslation
{
    public class Ticket
    {
        private readonly List<int> _values = new List<int>();

        public Ticket(string s)
        {
            var split = s.Split(',');
            foreach (var s1 in split)
                _values.Add(int.Parse(s1));
        }

        public IReadOnlyList<int> Values => _values;
    }
}