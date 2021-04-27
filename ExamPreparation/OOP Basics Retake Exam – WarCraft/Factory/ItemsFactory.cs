using System;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Factory
{
   public static class ItemsFactory
    {
        public static Item Create(string ItemName)
        {
            if(ItemName == nameof(HealthPotion))
            {
                Item item = new HealthPotion();
                return item;
            }

            else if(ItemName == nameof(FirePotion))
            {
                Item item = new FirePotion();
                return item;
            }

            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidItem);
            }
        }
    }
}
