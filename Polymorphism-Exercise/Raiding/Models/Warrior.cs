using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int PowerWarrior = 100;
        public Warrior(string name) : base(name)
        {
        }

        public override int Power => PowerWarrior;

        public override string CastAbility()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - {base.Name} hit for {this.Power} damage");
            return sb.ToString().TrimEnd();
        }
    }
}
