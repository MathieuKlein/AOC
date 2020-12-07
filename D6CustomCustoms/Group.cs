using System.Collections.Generic;
using System.Linq;

namespace D6CustomCustoms
{
    public class Group
    {
        private readonly Dictionary<char, int> _dictAnswers = new Dictionary<char, int>();

        public IReadOnlyDictionary<char, int> DictAnswers => _dictAnswers;

        public HashSet<int> LettersOnceYes { get; } = new HashSet<int>();

        public int NumberOfPeople { get; private set; }

        public Group(ICollection<string> linesOfAGroup)
        {
            foreach (var lineOfGroup in linesOfAGroup) AddLine(lineOfGroup);
            NumberOfPeople = linesOfAGroup.Count;
        }

        private void AddLine(string s)
        {
            foreach (var c in s)
            {
                if (DictAnswers.ContainsKey(c))
                    _dictAnswers[c]++;
                else
                    _dictAnswers[c] = 1;
                LettersOnceYes.Add(c);
            }

            NumberOfPeople++;
        }

        public IEnumerable<char> GetAllQuestionsAnsweredYes()
        {
            return _dictAnswers.Where(x => x.Value == NumberOfPeople).Select(x => x.Key);
        }
    }
}