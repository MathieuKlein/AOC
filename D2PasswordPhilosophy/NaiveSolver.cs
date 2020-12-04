using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PasswordPhilosophy
{
    public class NaiveSolver : BaseSolver
    {
        private readonly List<string> _strings;

        public NaiveSolver(List<string> strings)
        {
            _strings = strings;
        }

        public int CheckPosition()
        {
            var total = 0;
            foreach (var s in _strings)
            {
                var (password, letter, p1, p2) = ParseString(s);

                if (!IsInP1XOrP2(password, letter, p1, p2)) continue;
                Debug.WriteLine($"P1 : {p1} P2 : {p2} Letter : {letter} String : {password}");
                total++;
            }

            return total;
        }

        public static bool IsInP1XOrP2(string toTest, char letter, int p1, int p2)
        {
            return (toTest[p2 - 1] == letter || toTest[p1 - 1] == letter) && toTest[p1 - 1] != toTest[p2 - 1];
        }

        public int CheckMinMax()
        {
            var total = 0;
            foreach (var s in _strings)
            {
                var (password, letter, min, max) = ParseString(s);

                if (!IsInMinMax(password.Count(c => c == letter), min, max)) continue;
                Debug.WriteLine($"Min : {min} Max : {max} Letter : {letter} String : {password}");
                total++;
            }

            return total;
        }

        private static bool IsInMinMax(int count, int min, int max)
        {
            return count >= min && count <= max;
        }
    }
}