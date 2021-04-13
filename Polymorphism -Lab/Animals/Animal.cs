using System.Text;

namespace Animals
{
   public abstract class Animal
    {
        protected Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public string Name { get;}
        public string FavouriteFood { get;}

        public virtual string ExplainSelf()
        {
            var sb = new StringBuilder();
            sb.Append($"I am {this.Name} and my favourite food is {this.FavouriteFood}");
            return sb.ToString().TrimEnd();
        }
    }
}
