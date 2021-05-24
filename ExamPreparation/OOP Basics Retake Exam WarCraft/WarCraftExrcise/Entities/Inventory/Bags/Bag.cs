using System.Collections.Generic;
using WarCroft.Entities.Items;
using System.Linq;
using System;
using WarCroft.Constants;

namespace WarCroft.Entities.Inventory.Bags
{
    public abstract class Bag : IBag
    {
        private const int CapacityDefaultValue = 100;
        private  List<Item> items = new List<Item>();
        protected Bag(int capacity = CapacityDefaultValue)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if(items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item findedItem = items.FirstOrDefault(i => i.GetType().Name == name);
            if(findedItem == null)
            {
                throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag, name);
            }

            items.Remove(findedItem);
            return findedItem;
        }
    }
}
