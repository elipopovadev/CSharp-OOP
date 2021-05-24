using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Factory
{
   public static class CharacterFactory
    {
        public static Character Create (string characterType, string name)
        {
            if(characterType == nameof(Warrior))
            {
                Character warrior = new Warrior(name);
                return warrior;            
            }

            else if(characterType == nameof(Priest))
            {
                Character priest = new Priest(name);
                return priest;              
            }

            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCharacterType, characterType);
            }
        }
    }
}
