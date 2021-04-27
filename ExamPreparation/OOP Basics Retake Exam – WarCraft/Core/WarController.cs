using System;
using System.Linq;
using System.Collections.Generic;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using WarCroft.Factory;
using System.Text;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characterParty;
        private Stack<Item> itemPool;
        public WarController()
        {
            this.characterParty = new List<Character>();
            this.itemPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character = CharacterFactory.Create(characterType, name);
            this.characterParty.Add(character);
            return $"{string.Format(SuccessMessages.JoinParty, name)}";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = ItemsFactory.Create(itemName);
            this.itemPool.Push(item);
            return $"{string.Format(SuccessMessages.AddItemToPool, item.GetType().Name)}";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.characterParty.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item lastItem = this.itemPool.Pop();
            character.Bag.AddItem(lastItem);
            return $"{string.Format(SuccessMessages.PickUpItem, characterName, lastItem.GetType().Name)}";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = this.characterParty.FirstOrDefault(c => c.Name == characterName);
            if (character == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item currentItem = character.Bag.GetItem(itemName);
            currentItem.AffectCharacter(character);
            return $"{string.Format(SuccessMessages.UsedItem, characterName, currentItem.GetType().Name)}";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in characterParty.OrderByDescending(c => c.IsAlive).ThenBy(c => c.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            Character attackerCharacter = this.characterParty.FirstOrDefault(c => c.Name == attackerName);
            if (attackerCharacter == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
            }

            Character receiverCharacter = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiverCharacter == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
            }

            if (!(attackerCharacter is IAttacker attacker))
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
            }

            attacker.Attack(receiverCharacter);
            var sb = new StringBuilder();
            sb.AppendFormat(SuccessMessages.AttackCharacter, attackerName, receiverName,
                attackerCharacter.AbilityPoints, receiverName, receiverCharacter.Health, receiverCharacter.BaseHealth,
                receiverCharacter.Armor, receiverCharacter.BaseArmor);
            if (!receiverCharacter.IsAlive)
            {
                sb.AppendFormat(SuccessMessages.AttackKillsCharacter, receiverName);
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
