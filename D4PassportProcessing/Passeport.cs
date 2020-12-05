using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace D4PassportProcessing
{
    public class Passeport
    {
        private const string Byr = "byr";
        private const string Iyr = "iyr";
        private const string Eyr = "eyr";
        private const string Hgt = "hgt";
        private const string Hcl = "hcl";
        private const string Ecl = "ecl";
        private const string Pid = "pid";
        private const string Cm = "cm";
        private const string In = "in";
        private readonly string[] _acceptedEyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        private readonly IDictionary<string, string> _fieldDict = new Dictionary<string, string>();
        private readonly string[] _requiredFields = { Byr, Iyr, Eyr, Hgt, Hcl, Ecl, Pid };

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
            return _requiredFields.All(requiredField => _fieldDict.Keys.Contains(requiredField));
        }

        public bool IsValid()
        {
            if (!ContainsRequiredFields())
                return false;

            var byrValue = int.Parse(_fieldDict[Byr]);
            if (byrValue < 1920 || byrValue > 2002)
                return false;

            var iyrValue = int.Parse(_fieldDict[Iyr]);
            if (iyrValue < 2010 || iyrValue > 2020)
                return false;

            var eyrValue = int.Parse(_fieldDict[Eyr]);
            if (eyrValue < 2020 || eyrValue > 2030)
                return false;

            var substring = _fieldDict[Hgt].Substring(0, _fieldDict[Hgt].Length - 2);
            if (string.IsNullOrWhiteSpace(substring))
                return false;

            var hgtUnit = _fieldDict[Hgt].Substring(_fieldDict[Hgt].Length - 2);

            if (hgtUnit != Cm && hgtUnit != In)
                return false;

            var hgtValue = int.Parse(substring);

            if (hgtUnit == Cm && (hgtValue < 150 || hgtValue > 193))
                return false;

            if (hgtUnit == In && (hgtValue < 59 || hgtValue > 76))
                return false;

            if (!Regex.IsMatch(_fieldDict[Hcl], "^#[0-9abcdef]{6}$"))
                return false;

            if (!_acceptedEyeColors.Contains(_fieldDict[Ecl]))
                return false;

            if (!Regex.IsMatch(_fieldDict[Pid], "^[0-9]{9}$"))
                return false;

            return true;
        }
    }
}