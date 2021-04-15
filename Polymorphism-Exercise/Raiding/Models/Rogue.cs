using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int PowerRogue = 80;
        public Rogue(string name) : base(name)
        {
        }

        public override int Power => PowerRogue;

        public override string CastAbility()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - {base.Name} hit for {this.Power} damage");
            return sb.ToString().TrimEnd();
        }
    }
}
