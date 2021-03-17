
namespace GreedyTimes
{
   public class Gem
    {
        public Gem(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; set; }
        public long Quantity { get; set; }
    }
}
