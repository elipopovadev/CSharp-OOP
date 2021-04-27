using System;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory.Bags;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => health;
            set
            {
                if (health <= this.BaseHealth && health >= 0)
                {
                    health = value;
                }
            }
        }

        public double BaseArmor { get; }
        public double Armor
        {
            get => armor;
            set
            {
                if (armor <= this.Armor && armor >= 0)
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; }
        public Bag Bag { get; set; }
        public bool IsAlive { get; set; } = true;
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            if (this.Armor - hitPoints >= 0)
            {
                this.Armor -= hitPoints;
            }

            else
            {
                double hitpointsForReducedArmor = this.Armor;
                this.Armor -= hitpointsForReducedArmor;
                double leftHitPointsForReducedHealth = hitPoints - hitpointsForReducedArmor;
                this.Health -= leftHitPointsForReducedHealth;
                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }

        public override string ToString()
        {
            string characterStatus = null;
            if (this.IsAlive)
            {
                characterStatus = "Alive";
            }

            else
            {
                characterStatus = "Dead";
            }

            StringBuilder sb = new StringBuilder();
            string value = $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {characterStatus}";
            sb.AppendLine(value);
            return sb.ToString().TrimEnd();
        }
    }
}