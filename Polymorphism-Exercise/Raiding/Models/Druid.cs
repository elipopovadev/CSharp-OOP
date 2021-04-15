using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int PowerDruid = 80;
        public Druid(string name) : base(name)
        {
        }

        public override int Power => PowerDruid;

        public override string CastAbility()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - {base.Name} healed for {this.Power}");
            return sb.ToString().TrimEnd();
        }
    }
}
