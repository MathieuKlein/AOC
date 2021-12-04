// See https://aka.ms/new-console-template for more information
internal class Day2
{
    private List<Command> _input;

    internal int Ex1()
    {
        var horizontalPosition = 0;
        var depth = 0;

        foreach (var line in _input)
        {
            switch (line.Type)
            {
                case Direction.up:
                    depth -= line.unit;
                    break;
                case Direction.down:
                    depth += line.unit;
                    break;
                case Direction.forward:
                    horizontalPosition += line.unit;
                    break;

            }
        }
        
        return depth * horizontalPosition;
    }

    internal int Ex2()
    {
        var horizontalPosition = 0;
        var depth = 0;
        var aim = 0;

        foreach (var line in _input)
        {
            switch (line.Type)
            {
                case Direction.up:
                    aim -= line.unit;
                    break;
                case Direction.down:
                    aim += line.unit;
                    break;
                case Direction.forward:
                    horizontalPosition += line.unit;
                    depth += aim * line.unit;
                    break;

            }
        }

        return depth * horizontalPosition;
    }

    public Day2(string input)
    {
        _input = File.ReadLines(input).Select(x => new Command(x)).ToList();
       
    }
}
