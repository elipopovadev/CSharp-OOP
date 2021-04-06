using System;

namespace BirthdayCelebrations
{
    public class Citizen : INameable, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = birthdate;
        }
        
        public string Name { get; }
        public int Age { get; }
        public string ID { get;}
        public DateTime Birthdate { get; }
    }
}
