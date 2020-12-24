using System;
using System.IO;

namespace D24LobbyLayout
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);

            var tileFloor = new TileFloor();

            foreach (var s in strings)
                tileFloor.FlipTile(s);

            Console.WriteLine(tileFloor.NumberOfBlackTiles);
            tileFloor.CompleteFloor();
            for (var i = 0; i < 100; i++)
            {
                tileFloor.DailyFlip();
                tileFloor.CompleteFloor();
                Console.WriteLine($"Day {i + 1}: {tileFloor.NumberOfBlackTiles}");
            }

            Console.ReadKey();
        }
    }
}