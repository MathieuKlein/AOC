using System.Collections.Generic;
using System.Diagnostics;

namespace TobogganTrajectory
{
    public class TreeChecker
    {
        private readonly List<Row> _rows = new List<Row>();

        public TreeChecker(IEnumerable<string> lines)
        {
            foreach (var line in lines) _rows.Add(new Row(line));
        }

        public long CheckForSlope(int down, int right)
        {
            var position = 0;
            var nbTrees = 0;

            for (var i = 0; i < _rows.Count; i += down)
            {
                if (_rows[i].IsThereATreeAt(position))
                    nbTrees++;

                position += right;
            }

            return nbTrees;
        }

        private long CheckForSlopeVerbose(int down, int right)
        {
            var position = 0;
            var nbTrees = 0;
            for (var i = 0; i < _rows.Count; i += down)
            {
                Debug.Write($"{i} - ");

                _rows[i].PrintTreePositions();

                if (_rows[i].IsThereATreeAt(position))
                {
                    nbTrees++;
                    Debug.Write($"T : {nbTrees}");
                }

                position += right;
                Debug.WriteLine("");
            }

            return nbTrees;
        }
    }
}