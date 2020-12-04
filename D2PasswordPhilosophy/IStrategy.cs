namespace PasswordPhilosophy
{
    public interface IStrategy
    {
        bool IsValid(Line line);
    }
}