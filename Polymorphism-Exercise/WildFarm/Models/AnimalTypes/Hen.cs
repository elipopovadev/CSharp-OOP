
namespace WildFarm.Models.AnimalTypes
{
   public class Hen : Bird
    {
        private const double IncrementIncreaseWeight = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void FeedIt(Food food)
        {
            int quantity = food.Quantity;
            for (int i = 0; i < quantity; i++)
            {
                base.Weight += IncrementIncreaseWeight;
            }

            base.FoodEaten += quantity;
        }
    }
}
