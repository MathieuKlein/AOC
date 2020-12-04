using System.Linq;

namespace PasswordPhilosophy
{
    public class IsBetweenMinAndMaxStrategy : IStrategy
    {
        public bool IsValid(Line line)
        {
            var nbOccurrences = line.Password.Count(x => x == line.Letter);

            return IsBetweenMinAndMax(nbOccurrences, line.N1, line.N2);
        }

        private bool IsBetweenMinAndMax(int count, int min, int max)
        {
            return count >= min && count <= max;
        }
    }
}