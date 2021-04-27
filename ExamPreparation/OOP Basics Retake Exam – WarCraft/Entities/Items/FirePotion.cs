using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
   public class FirePotion : Item
    {
        private const int FirePotionWeight = 5;
        private const double CharacterHealthDecrease = 20;
        public FirePotion() : base(FirePotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= CharacterHealthDecrease;
            if(character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
