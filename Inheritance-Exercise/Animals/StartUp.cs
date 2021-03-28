using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string animalType = input;
                string[] animalAttribute = Console.ReadLine().Split();
                string name = animalAttribute[0];
                int age = int.Parse(animalAttribute[1]);
                string gender = animalAttribute[2];

                try
                {
                    if (animalType == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                    }

                    else if (animalType == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                    }

                    else if (animalType == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                    }

                    else if (animalType == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(kitten);
                    }

                    else if (animalType == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(tomcat);
                    }

                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }

                catch (ArgumentOutOfRangeException exeption)
                {
                    Console.WriteLine(exeption);
                }
            }
        }
    }
}
