// See https://aka.ms/new-console-template for more information
internal class Command
{
    public readonly Direction Type;
    public readonly int unit;

    public Command(string commandString)
    {
        string[] split = commandString.Split(' ');
        Type = (Direction)Enum.Parse(typeof(Direction), split[0]);
        unit = int.Parse(split[1]);
    }
}
