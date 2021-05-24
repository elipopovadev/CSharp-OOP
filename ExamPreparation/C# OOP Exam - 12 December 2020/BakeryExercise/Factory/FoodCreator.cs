using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Factory
{
    public static class FoodCreator
    {
        public static IBakedFood CreateFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == nameof(Bread))
            {
                food = new Bread(name, price);
            }
            else if (type == nameof(Cake))
            {
                food = new Cake(name, price);
            }
            if (food != null)
            {
                return food;
            }

            return null; // this is the requirement, but bad practice
        }
    }
}
