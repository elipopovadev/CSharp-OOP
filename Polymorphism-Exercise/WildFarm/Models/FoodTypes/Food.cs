using WildFarm.Interfaces;

namespace WildFarm.Models
{
    public abstract class Food : IFood
    {
        protected Food( int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
