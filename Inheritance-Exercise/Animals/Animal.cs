using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value >= 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new InvalidOperationException("Invalid input!");
                }
            }
        }
        public string Gender
        {
            get 
            {
                return this.gender;
            }
            set
            {
                if(value == "Male" || value == "Female")
                {
                    this.gender = value;
                }

                else
                {
                    throw new InvalidOperationException("Invalid input!");
                }
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}
