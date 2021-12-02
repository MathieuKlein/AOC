// See https://aka.ms/new-console-template for more information
internal class Sonar
{
    private List<int> _input;

    public Sonar(string input)
    {
        _input = File.ReadLines(input).Select(x=> int.Parse(x)).ToList();
    }

    internal int CountNumberOfIncreases()
    {
        var previousInput = int.MaxValue;
        int count = 0;

        foreach (var input in _input)
        {
            if (input > previousInput)
            {
                count++;
            }
            previousInput = input;
        }
        return count;
    }

    internal int CountNumberOfIncreasesOfSumOf3()
    {
        var previousInput = int.MaxValue;
        int count = 0;

        for (int i = 0; i < _input.Count; i++)
        {
            int input = _input.Skip(i).Take(3).Sum();
            if (input > previousInput)
            {
                count++;
            }
            previousInput = input;
        }
        return count;
    }
}