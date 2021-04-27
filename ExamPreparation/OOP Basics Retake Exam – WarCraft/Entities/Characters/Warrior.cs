using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Bags;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double BaseHealthWarrior = 100;
        private const double BaseArmorWarrior = 50;
        private const double AbilityPointsWarrior = 40;
        protected Warrior(string name) : base(name, BaseHealthWarrior, BaseArmorWarrior, AbilityPointsWarrior, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (base.IsAlive && character.IsAlive)
            {
                if (this.Equals(character))
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }

                character.TakeDamage(AbilityPointsWarrior);
            }
        }
    }
}
