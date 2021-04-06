using BirthdayCelebrations;
using System;
using System.Globalization;

namespace FoodShortage
{
    public class Citizen : INameable, IAgeable, IBuyer
    {
        public Citizen(string name, int age, string id, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }
        
        public string Name { get; }
        public int Age { get; }
        public string ID { get;}
        public DateTime Birthdate { get; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
