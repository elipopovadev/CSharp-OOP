namespace AnimalFarm.Models
{
    using System;

    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;
        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
                }

                this.age = value;
            }
        }

        public double ProductPerDay => this.CalculateProductPerDay();

        private double CalculateProductPerDay()
        {
            if (this.Age <= 3)
            {
                return 1.5;
            }

            else if (this.Age >= 4 && this.Age <= 7)
            {
                return 2;
            }

            else if (this.Age >= 8 && this.Age <= 11)
            {
                return 1;
            }

            else
            {
                return 0.75;
            }
        }
    }
}
