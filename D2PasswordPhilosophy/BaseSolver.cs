using System.Linq;

namespace PasswordPhilosophy
{
    public abstract class BaseSolver
    {
        protected static (string password, char letter, int n1, int n2) ParseString(string s)
        {
            var split = s.Split('-', ' ', ':', ' ');
            var password = split[4];
            var letter = split[2].Single();
            var n1 = int.Parse(split[0]);
            var n2 = int.Parse(split[1]);
            return (password, letter, n1, n2);
        }
    }
}