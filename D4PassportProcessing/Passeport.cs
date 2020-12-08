using System.Collections.Generic;
using System.Linq;

namespace D4PassportProcessing
{
    public class Passeport
    {
        private const string LabelByr = "byr";
        private const string LabelIyr = "iyr";
        private const string LabelEyr = "eyr";
        private const string LabelHgt = "hgt";
        private const string LabelHcl = "hcl";
        private const string LabelEcl = "ecl";
        private const string LabelPid = "pid";
        private static readonly string[] RequiredFields = { LabelByr, LabelIyr, LabelEyr, LabelHgt, LabelHcl, LabelEcl, LabelPid };
        private static readonly CustomerValidator CustomerValidator;

        private readonly IDictionary<string, string> _fieldDict = new Dictionary<string, string>();

        public static readonly string[] AcceptedEyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        static Passeport()
        {
            CustomerValidator = new CustomerValidator();
        }

        public Passeport(IEnumerable<string> linesOfPasseport)
        {
            foreach (var lineOfPasseport in linesOfPasseport)
                AddLine(lineOfPasseport);


            if (_fieldDict.ContainsKey(LabelByr)) Byr = int.Parse(_fieldDict[LabelByr]);
            if (_fieldDict.ContainsKey(LabelIyr)) IyrValue = int.Parse(_fieldDict[LabelIyr]);
            if (_fieldDict.ContainsKey(LabelEyr)) EyrValue = int.Parse(_fieldDict[LabelEyr]);
            if (_fieldDict.ContainsKey(LabelHgt)) HgtUnit = _fieldDict[LabelHgt].Substring(_fieldDict[LabelHgt].Length - 2);
            if (_fieldDict.ContainsKey(LabelHcl)) Hcl = _fieldDict[LabelHcl];
            if (_fieldDict.ContainsKey(LabelEcl)) Ecl = _fieldDict[LabelEcl];
            if (_fieldDict.ContainsKey(LabelPid)) Pid = _fieldDict[LabelPid];

            if (_fieldDict.ContainsKey(LabelHgt))
            {
                var substring = _fieldDict[LabelHgt].Substring(0, _fieldDict[LabelHgt].Length - 2);
                if (!string.IsNullOrWhiteSpace(substring))
                    HgtValue = int.Parse(substring);
            }
        }

        public int Byr { get; }

        public string? Ecl { get; }

        public string? Hcl { get; }

        public int HgtValue { get; }

        public string? HgtUnit { get; }

        public int EyrValue { get; }

        public int IyrValue { get; }

        public string? Pid { get; }

        public void AddLine(string s)
        {
            var fieldValues = s.Split(" ");
            foreach (var fieldValue in fieldValues)
            {
                var split = fieldValue.Split(":");
                _fieldDict[split[0]] = split[1];
            }
        }

        public bool ContainsRequiredFields()
        {
            return RequiredFields.All(requiredField => _fieldDict.Keys.Contains(requiredField));
        }

        public bool IsValid()
        {
            return CustomerValidator.Validate(this).IsValid;
        }
    }
}