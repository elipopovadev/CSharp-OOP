using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;


namespace Bakery.Factory
{ 
    public static class DrinkCreator
    {
        public static IDrink CreateDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if(type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }
            else if(type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }
            if(drink != null)
            {
                return drink;
            }

            return null; 
        }
    }
}
