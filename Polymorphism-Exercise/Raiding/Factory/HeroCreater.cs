using Raiding.Exceptions;
using Raiding.Interfaces;
using Raiding.Models;
using System;

namespace Raiding.Factory
{
   public class HeroCreater
    {
        public IBaseHero Create(string name, string type)
        {
            IBaseHero hero = null;
            if(type == "Druid")
            {
                hero = new Druid(name);                   
            }

            else if(type == "Paladin")
            {
                hero = new Paladin(name);
            }

            else if(type == "Rogue")
            {
                hero = new Rogue(name);
            }

            else if(type == "Warrior")
            {
                hero = new Warrior(name);
            }

            else 
            {
                throw new ArgumentException(ExceptionsMessage.InvalidHero);
            }

            return hero;
        }
    }
}
