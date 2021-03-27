namespace Animals
{
   public class Kitten : Cat
    {
        private const string kittenGender = "female";
        public Kitten(string name, int age) : base(name, age, kittenGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
