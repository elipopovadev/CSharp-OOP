using Salary;
using System;
using System.Collections.Generic;

namespace PersonsInfo
{
   public class StartUp
    {
            static void Main(string[] args)
            {
                int lines = int.Parse(Console.ReadLine());
                var listWithPeople = new List<Person>();
                for (int i = 0; i < lines; i++)
                {
                    string[] input = Console.ReadLine().Split();
                    string firstName = input[0];
                    string lastName = input[1];
                    int age = int.Parse(input[2]);
                    decimal salary = decimal.Parse(input[3]);
                    var newPerson = new Person(firstName, lastName, age, salary);
                    listWithPeople.Add(newPerson);
                }

                decimal parcentage = decimal.Parse(Console.ReadLine());
                foreach (var person in listWithPeople)
                {
                   person.IncreaseSalary(parcentage);
                   Console.WriteLine(person);
                }
            }
        }
    }

