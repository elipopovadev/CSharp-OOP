using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var all = new Dictionary<string, IBuyer>();
            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthday = input[3];
                    Citizen newCitizen = new Citizen(name, age, id, birthday);
                    all.Add(name, newCitizen);
                }

                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    Rebel newRebel = new Rebel(name, age, group);
                    all.Add(name, newRebel);
                }
            }

            string secondInput;
            while ((secondInput = Console.ReadLine()) != "End")
            {
                string name = secondInput;
                IBuyer foundedBuyer = all.FirstOrDefault(b => b.Key == name).Value;
                if(foundedBuyer != default)
                {
                    foundedBuyer.BuyFood();
                }
            }

            Console.WriteLine(all.Select(x=>x.Value.Food).Sum());
        }
    }
}
