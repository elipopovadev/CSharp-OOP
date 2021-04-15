using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PowerPaladin = 100;
        public Paladin(string name) : base(name)
        {
        }

        public override int Power => PowerPaladin;

        public override string CastAbility()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - {base.Name} healed for {this.Power}");
            return sb.ToString().TrimEnd();
        }
    }
}
