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
        private readonly List<Character> characterParty;
        private readonly Stack<Item> itemPool;
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
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
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
            foreach (var character in characterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
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
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            Character receiverCharacter = this.characterParty.FirstOrDefault(c => c.Name == receiverName);
            if (receiverCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (!(attackerCharacter is IAttacker attacker))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            attacker.Attack(receiverCharacter);
            var sb = new StringBuilder();
            string messageSuccessfullAtack = String.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attackerCharacter.AbilityPoints,
                receiverName, receiverCharacter.Health, receiverCharacter.BaseHealth, receiverCharacter.Armor, receiverCharacter.BaseArmor);
            sb.AppendLine(messageSuccessfullAtack);
            if (!receiverCharacter.IsAlive)
            {
                string messageForDead = String.Format(SuccessMessages.AttackKillsCharacter, receiverName);
                sb.AppendLine(messageForDead);
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            Character healerCharacter = this.characterParty.FirstOrDefault(c => c.Name == healerName);
            if (healerCharacter == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty);
            }

            Character healingReceiverCharacter = this.characterParty.FirstOrDefault(c => c.Name == healingReceiverName);
            if (healingReceiverCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty));
            }

            if (!(healerCharacter is IHealer healer))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            healer.Heal(healingReceiverCharacter);
            var sb = new StringBuilder();
            sb.AppendFormat(SuccessMessages.HealCharacter, healerName, healingReceiverName, healerCharacter.AbilityPoints,
                healingReceiverName, healingReceiverCharacter.Health);
            return sb.ToString();
        }
    }
}
