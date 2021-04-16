using WildFarm.Models;

namespace WildFarm.Interfaces
{
   public interface IAnimal
    {
        public string Name { get;}
        public double Weight { get; }
        public int FoodEaten { get;}
        public  void FeedIt(Food food);
        public string ProduceSound();
    }
}
