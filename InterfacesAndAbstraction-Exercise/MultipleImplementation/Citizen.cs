using MultipleImplementation;

namespace DefineAnInterfaceIPerson
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthday;
        }

        public string Name { get;}
        public int Age { get;}
        public string Id { get; }
        public string Birthdate { get;}
    }
}
