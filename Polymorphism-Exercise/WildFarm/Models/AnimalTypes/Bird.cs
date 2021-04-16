using System.Text;
using WildFarm.Interfaces;

namespace WildFarm.Models.AnimalTypes
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.WingSize}, {base.Weight}, {base.FoodEaten}]");
            return $"{base.ToString()} {sb}"; 
        }
    }
}
