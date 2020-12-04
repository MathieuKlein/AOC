namespace PasswordPhilosophy
{
    public class IsInPosition1XOrPosition2Strategy : IStrategy
    {
        public bool IsValid(Line line)
        {
            return (line.Password[line.N1 - 1] == line.Letter) ^ (line.Password[line.N2 - 1] == line.Letter);
        }
    }
}