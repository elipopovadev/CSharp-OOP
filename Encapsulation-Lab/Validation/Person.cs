using System;

namespace Validation
{ 
    public class Person
    {
        private const decimal MinSalary = 460;
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if (value.Length < 3 || value == null)
                {
                    throw new ArgumentOutOfRangeException("First name cannot contain fewer than 3 symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (value.Length < 3 || value == null)
                {
                    throw new ArgumentOutOfRangeException("Last name cannot contain fewer than 3 symbols!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary
        {
            get => this.salary;
            private set
            {
                if (value < MinSalary)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be less than 460 leva!");
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal parcentage)
        {
            if (this.Age < 30)
            {
                this.Salary += parcentage / 100 / 2 * this.Salary;
            }
            else
            {
                this.Salary += parcentage / 100 * this.Salary;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} gets {this.Salary:F2} leva.";
        }
    }
}
