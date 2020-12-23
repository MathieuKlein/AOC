using System;
using System.Collections.Generic;
using System.Linq;

namespace D23CrabCups
{
    public class Program
    {
        public const string InputTxt = "789465123";
        public const string InputTxt2 = "389125467";

        public static void Main(string[] args)
        {
            var input = InputTxt.Select(x => long.Parse(x.ToString())).ToList();

            var numberOfMoves = 100;
            //GameOne(numberOfMoves, input);
            var linkedList = new LinkedList<long>(input);
            GameTwo(numberOfMoves, linkedList);


            var finalList = linkedList.ToList();
            var indexOf1 = finalList.IndexOf(1);
            var result = finalList.Skip(indexOf1 + 1);
            Console.WriteLine(string.Join("", result.Concat(finalList.Take(indexOf1))));

            for (var i = input.Max(); i < 1000000; i++)
                input.Add(i + 1);
            linkedList = new LinkedList<long>(input);

            GameTwo(10000000, linkedList);
            finalList = linkedList.ToList();
            indexOf1 = finalList.IndexOf(1);
            result = finalList.Skip(indexOf1 + 1).Take(2);
            Console.WriteLine(string.Join(" ", result.Aggregate((x, y) => x * y)));

            Console.ReadKey();
        }

        private static void GameOne(int numberOfMoves, List<long> input)
        {
            var currentCup = input.First();

            for (var i = 0; i < numberOfMoves; i++)
            {
                var indexOfCurrentCup = input.IndexOf(currentCup);

#if DEBUG
                Console.WriteLine($"-- move {i + 1} --");
                Console.WriteLine("cups: " + string.Join(' ', input) + " (" + currentCup + ")");
#endif

                var nextThree = PickUpThree(input, indexOfCurrentCup);
                var destination = GetDestination(input, currentCup);
#if DEBUG
                Console.WriteLine("destination: " + (destination + 1));
#endif

                input.InsertRange(destination + 1, nextThree);
                currentCup = input[(input.IndexOf(currentCup) + 1) % input.Count];

#if DEBUG
                Console.WriteLine();
#endif
            }
        }

        private static void GameTwo(int numberOfMoves, LinkedList<long> input)
        {
            var cupsNodeByValue = new Dictionary<long, LinkedListNode<long>>();
            var node = input.First;

            if (node == null)
                throw new InvalidOperationException();
            do
            {
                cupsNodeByValue.Add(node.Value, node);
                node = node.Next;
            } while (node != null);


            var currentCup = input.First;

            for (var i = 0; i < numberOfMoves; i++)
            {
                var nextThree = PickUpThree2(input, currentCup, cupsNodeByValue);
                var destination = GetDestination2(input, currentCup, cupsNodeByValue);

                foreach (var n in nextThree)
                {
                    var added = destination.List.AddAfter(destination, n.Value);
                    cupsNodeByValue.Add(added.Value, added);
                    destination = added;
                }

                currentCup = currentCup.Next ?? input.First;
            }
        }

        private static IEnumerable<LinkedListNode<long>> PickUpThree2(LinkedList<long> input, LinkedListNode<long> currentCup, Dictionary<long, LinkedListNode<long>> dictionary)
        {
            var result = new List<LinkedListNode<long>>();
            for (var i = 1; i <= 3; i++)
            {
                var remove = currentCup.Next ?? input.First;
                result.Add(remove);
                input.Remove(remove);
                dictionary.Remove(remove.Value);
            }

            return result;
        }

        private static IEnumerable<long> PickUpThree(IList<long> input, int indexOfCurrentCup)
        {
            var result = new List<long>();
            for (var i = 1; i <= 3; i++)
            {
                var removeAt = indexOfCurrentCup + 1 < input.Count ? indexOfCurrentCup + 1 : 0;
                result.Add(input[removeAt]);
                input.RemoveAt(removeAt);
            }

#if DEBUG
            Console.WriteLine("pick up: " + string.Join(' ', result));
#endif
            return result;
        }

        private static int GetDestination(IList<long> input, long currentCup)
        {
            var destination = -1;

            while (destination == -1)
            {
                destination = input.IndexOf(currentCup - 1);

                currentCup--;
                if (currentCup < 1)
                    currentCup = input.Max() + 1;
            }

            return destination;
        }


        private static LinkedListNode<long> GetDestination2(LinkedList<long> input, LinkedListNode<long> currentCup, Dictionary<long, LinkedListNode<long>> cupsNodeByValue)
        {
            var destination = currentCup.Value - 1;

            while (!cupsNodeByValue.ContainsKey(destination))
            {
                destination--;

                if (destination < 1)
                    destination = input.Max() + 1;
            }

            return cupsNodeByValue[destination];
        }
    }
}