using WarCroft.Entities.Inventory.Bags;

namespace WarCroft.Entities.Characters.Contracts
{
   public class Priest : Character, IHealer
    {
       const double BaseHealthPriest = 50;
       const double BaseArmorPriest = 25;
       const double AbilityPointsPriest = 40;
        public Priest(string name) : base(name, BaseHealthPriest, BaseArmorPriest, AbilityPointsPriest, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if(this.IsAlive && character.IsAlive)
            {
                character.Health += base.AbilityPoints;
            }
        }
    }
}
