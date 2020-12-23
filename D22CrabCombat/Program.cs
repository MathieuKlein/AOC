using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D22CrabCombat
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);

            var players = CreatePlayers(strings).ToList();

            var winner = GameOne(players[0], players[1]);
            Console.WriteLine(winner.CalculateScore());

            foreach (var player in players)
                player.Reset();

            winner = GameTwo(players[0], players[1]);
            Console.WriteLine(winner.CalculateScore());
            Console.ReadKey();
        }

        private static IEnumerable<Player> CreatePlayers(IEnumerable<string> strings)
        {
            var stringsPlayer = new List<string>();

            foreach (var s in strings)
                if (s.Length == 0)
                {
                    yield return new Player(stringsPlayer);
                    stringsPlayer = new List<string>();
                }
                else
                {
                    stringsPlayer.Add(s);
                }

            yield return new Player(stringsPlayer);
        }

        private static Player GameTwo(Player playerOne, Player playerTwo)
        {
            var deckHistoryPlayerOne = new HashSet<string>();
            var deckHistoryPlayerTwo = new HashSet<string>();
            while (playerOne.Deck.Any() && playerTwo.Deck.Any())
            {
                var card1 = playerOne.Deck.First();
                var card2 = playerTwo.Deck.First();
                if (deckHistoryPlayerOne.Contains(playerOne.PrintDeck()) || deckHistoryPlayerTwo.Contains(playerTwo.PrintDeck()))
                    return playerOne;

                deckHistoryPlayerOne.Add(playerOne.PrintDeck());
                deckHistoryPlayerTwo.Add(playerTwo.PrintDeck());

                var winner = playerOne.Deck.Count <= card1 || playerTwo.Deck.Count <= card2
                    ? card1 > card2 ? playerOne.Name : playerTwo.Name
                    : GameTwo(CreateSubPlayer(playerOne, card1), CreateSubPlayer(playerTwo, card2)).Name;

                playerTwo.Deck.RemoveAt(0);
                playerOne.Deck.RemoveAt(0);

                if (winner == playerOne.Name)
                    MoveCardsToBottomOfPlayer(playerOne, card1, card2);
                else
                    MoveCardsToBottomOfPlayer(playerTwo, card2, card1);
            }

            return playerOne.Deck.Any() ? playerOne : playerTwo;
        }

        private static Player CreateSubPlayer(Player player, int cards)
        {
            return new(player.Name, player.Deck.Skip(1).Take(cards));
        }

        private static void MoveCardsToBottomOfPlayer(Player player, int card1, int card2)
        {
            player.Deck.Add(card1);
            player.Deck.Add(card2);
        }

        private static Player GameOne(Player playerOne, Player playerTwo)
        {
            while (playerOne.Deck.Any() && playerTwo.Deck.Any())
            {
                var card1 = playerOne.Deck.First();
                var card2 = playerTwo.Deck.First();
                playerOne.Deck.RemoveAt(0);
                playerTwo.Deck.RemoveAt(0);

                if (card1 > card2)
                    MoveCardsToBottomOfPlayer(playerOne, card1, card2);
                else
                    MoveCardsToBottomOfPlayer(playerTwo, card2, card1);
            }

            return playerOne.Deck.Any() ? playerOne : playerTwo;
        }
    }
}