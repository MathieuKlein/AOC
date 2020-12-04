namespace PasswordPhilosophy
{
    public readonly struct Line
    {
        public Line(string password, in char letter, in int n1, in int n2)
        {
            Password = password;
            Letter = letter;
            N1 = n1;
            N2 = n2;
        }

        public string Password { get; }
        public char Letter { get; }
        public int N1 { get; }
        public int N2 { get; }
    }
}