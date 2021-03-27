namespace Animals
{
    public class Tomcat : Cat
    {
        private const string tomcatGender = "male";
        public Tomcat(string name, int age) : base(name, age, tomcatGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
