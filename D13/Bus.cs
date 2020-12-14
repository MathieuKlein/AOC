namespace D13ShuttleSearch
{
    public class Bus
    {
        public Bus(string busString)
        {
            Frequency = long.Parse(busString);
        }

        public long Frequency { get; }

        public long NextIn(long timeStamp)
        {
            return Frequency - timeStamp % Frequency;
        }
    }
}