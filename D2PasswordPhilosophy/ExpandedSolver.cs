using System.Collections.Generic;
using System.Linq;

namespace PasswordPhilosophy
{
    public class ExpandedSolver : BaseSolver
    {
        private readonly IStrategy _strategy;

        public ExpandedSolver(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public int CountValidForRule(IEnumerable<string> strings)
        {
            var lines = new List<Line>();
            foreach (var s in strings)
            {
                var (password, letter, n1, n2) = ParseString(s);
                lines.Add(new Line(password, letter, n1, n2));
            }

            return lines.Count(x => _strategy.IsValid(x));
        }
    }
}