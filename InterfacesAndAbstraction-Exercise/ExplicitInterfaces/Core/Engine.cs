using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.IO;
using ExplicitInterfaces.Models;
using System.Collections.Generic;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private List<Citizen> citizens;

        private Engine()
        {
            this.citizens = new List<Citizen>();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;
            while((input = reader.ReadLine()) != "End")
            {
                string[] citizen = input.Split();
                string name = citizen[0];
                string country = citizen[1];
                int age = int.Parse(citizen[2]);
                Citizen newCitizen = new Citizen(name, country, age);
                citizens.Add(newCitizen);
            }

            foreach ( Citizen citizen in citizens)
            {
                writer.WriteLine(((IPerson)citizen).GetName());
                writer.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
