using Persons;
using System;
using System.Collections.Generic;
using Teams;

namespace PersonsInfo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var newTeam = new Team("SoftUni");
            var listWithPeople = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                var newPerson = new Person(firstName, lastName, age);
                listWithPeople.Add(newPerson);
            }

            foreach (var person in listWithPeople)
            {
                newTeam.AddPlayer(person);
            }

            Console.WriteLine($"First team has {newTeam.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {newTeam.ReserveTeam.Count} players.");
        }
    }
}
