using System.Linq;
using FluentValidation;

namespace D4PassportProcessing
{
    public class CustomerValidator : AbstractValidator<Passeport>
    {
        public const string Cm = "cm";
        public const string In = "in";

        public CustomerValidator()
        {
            RuleFor(passeport => passeport.Byr).InclusiveBetween(1920, 2002);
            RuleFor(passeport => passeport.IyrValue).InclusiveBetween(2010, 2020);
            RuleFor(passeport => passeport.EyrValue).InclusiveBetween(2020, 2030);
            RuleFor(passeport => passeport.HgtUnit).NotNull().Must(x => x == Cm || x == In);
            RuleFor(passeport => passeport.HgtValue).InclusiveBetween(150, 193).When(passeport => passeport.HgtUnit == Cm);
            RuleFor(passeport => passeport.HgtValue).InclusiveBetween(59, 76).When(passeport => passeport.HgtUnit == In);
            RuleFor(passeport => passeport.Hcl).NotNull().Matches("^#[0-9abcdef]{6}$");
            RuleFor(passeport => passeport.Ecl).NotNull().Must(e => Passeport.AcceptedEyeColors.Contains(e));
            RuleFor(passeport => passeport.Pid).NotNull().Matches("^[0-9]{9}$");
        }
    }
}