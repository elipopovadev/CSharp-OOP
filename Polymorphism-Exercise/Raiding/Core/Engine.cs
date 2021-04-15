using Raiding.Factory;
using Raiding.Interfaces;
using Raiding.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<IBaseHero> listOfHeroes;
        private HeroCreater heroCreater;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.heroCreater = new HeroCreater();
            this.listOfHeroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int numberOfHeroes = int.Parse(reader.ReadLine());
            int countCreatedHero = 0;

            while (numberOfHeroes != countCreatedHero)
            {
                try
                {
                    string name = reader.ReadLine();
                    string type = reader.ReadLine();
                    IBaseHero hero = heroCreater.Create(name, type);
                    countCreatedHero++;
                    listOfHeroes.Add(hero);
                }

                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(reader.ReadLine());
            int totalHeroesPower = listOfHeroes.Select(h => h.Power).Sum();

            foreach (var hero in listOfHeroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            if (totalHeroesPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }

            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
