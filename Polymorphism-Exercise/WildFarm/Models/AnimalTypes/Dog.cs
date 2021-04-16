using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Exceptions;

namespace WildFarm.Models.AnimalTypes
{
   public class Dog : Mammal
    {
        private const double IncrementIncreaseWeight = 0.40;
        private ICollection<Type> foodTypes = new List<Type> { typeof(Meat) };
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public IReadOnlyCollection<Type> FoodTypes => (IReadOnlyCollection<Type>)foodTypes;

        public override void FeedIt(Food food)
        {
            if (!foodTypes.Any(f => f.Name == food.GetType().Name))
            {
                string exceptionMessages = String.Format(ExceptionMessages.InvalidFoodException, this.GetType().Name, food.GetType().Name);
                throw new ArgumentException(exceptionMessages);
            }

            int quantity = food.Quantity;
            for (int i = 0; i < quantity; i++)
            {
                base.Weight += IncrementIncreaseWeight;
            }

            base.FoodEaten += quantity;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{base.Weight}, {this.LivingRegion}, {base.FoodEaten}]");
            return $"{base.ToString()} {sb}";
        }
    }
}
