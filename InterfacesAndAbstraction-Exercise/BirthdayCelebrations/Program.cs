using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            var all = new Dictionary<DateTime, IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArray = input.Split();              
                if (inputArray.Contains("Citizen"))
                {
                    string name = inputArray[1];
                    int age = int.Parse(inputArray[2]);
                    string id = inputArray[3];
                    DateTime birthday = DateTime.Parse(inputArray[4]);
                    IBirthable newCitizen = new Citizen(name, age, id, birthday);
                    all.Add(newCitizen.Birthdate, newCitizen);
                }

                else if (inputArray.Contains("Pet"))
                {
                    string name = inputArray[1];
                    DateTime birthday = DateTime.Parse(inputArray[2]);
                    IBirthable newPet = new Pet(name, birthday);
                    all.Add(newPet.Birthdate, newPet);
                }
            }

            int specificYear = int.Parse(Console.ReadLine());
            var listIBirthableWithSpecificDate = all.Where(x => x.Key.Year == specificYear)
                                                    .Select(x => x.Value.Birthdate)
                                                    .ToList();

            if(listIBirthableWithSpecificDate.Count == 0)
            {
                Console.WriteLine("<empty output>");
            }

            foreach (var birthdayDate in listIBirthableWithSpecificDate)
            {
                Console.WriteLine(birthdayDate.ToString("dd\\/MM\\/yyyy"));
            }
        }
    }
}
