using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D22CrabCombat
{
    public class Player
    {
        private readonly IReadOnlyList<int> _initialDeck;

        public Player(IReadOnlyCollection<string> stringsPlayer)
        {
            Name = stringsPlayer.First();

            var cards = stringsPlayer.Skip(1).Select(int.Parse).ToList();

            Deck = cards;
            _initialDeck = cards.ToList();
        }

        public Player(string name, IEnumerable<int> stringsPlayer)
        {
            Deck = stringsPlayer.ToList();
            Name = name;
        }

        public IList<int> Deck { get; private set; }

        public string Name { get; }

        public void Reset()
        {
            Deck = _initialDeck.ToList();
        }

        public int CalculateScore()
        {
            var sum = 0;
            for (var index = 1; index <= Deck.Count; index++)
                sum += Deck[index - 1] * (Deck.Count - index + 1);
            return sum;
        }

        public string PrintDeck()
        {
            var sb = new StringBuilder();
            foreach (var i in Deck)
                sb.Append(i);

            return sb.ToString();
        }
    }
}