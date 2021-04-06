using System;

namespace BirthdayCelebrations
{
    public class Pet : INameable,IBirthable
    {
        public Pet(string name, DateTime birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; }
        public DateTime Birthdate { get; }     
    }
}
