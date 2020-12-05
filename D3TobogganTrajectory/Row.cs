using System.Collections.Generic;
using System.Diagnostics;

namespace TobogganTrajectory
{
    internal class Row
    {
        private const char TreeSymbol = '#';
        private readonly int _lineLength;
        private readonly List<int> _treePositions;

        public Row(string line)
        {
            _treePositions = AllIndexesOf(line, TreeSymbol);
            _lineLength = line.Length;
        }

        public bool IsThereATreeAt(int position)
        {
            return _treePositions.Contains(position % _lineLength);
        }

        public void PrintTreePositions()
        {
            foreach (var p in _treePositions) Debug.Write($"{p} ");
        }

        private static List<int> AllIndexesOf(string str, char value)
        {
            var indexes = new List<int>();
            for (var index = 0;; index++)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}