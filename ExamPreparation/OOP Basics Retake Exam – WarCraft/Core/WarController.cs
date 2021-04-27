using System;
using System.Linq;
using System.Collections.Generic;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using WarCroft.Factory;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> CharacterParty;
		private Stack<Item> ItemPool;
		public WarController()
		{
			this.CharacterParty = new List<Character>();
			this.ItemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];
			Character character = CharacterFactory.Create(characterType, name);
			this.CharacterParty.Add(character);
			return $"{string.Format(SuccessMessages.JoinParty, name)}";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item= ItemsFactory.Create(itemName);
			this.ItemPool.Push(item);
			return $"{string.Format(SuccessMessages.AddItemToPool, item.GetType().Name)}";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = this.CharacterParty.FirstOrDefault(c => c.Name == characterName);
			if(character == null)
            {
				throw new InvalidOperationException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			if(this.ItemPool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item lastItem = this.ItemPool.Pop();
			character.Bag.AddItem(lastItem);
			return $"{string.Format(SuccessMessages.PickUpItem, characterName, lastItem.GetType().Name)}";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			Character character = this.CharacterParty.FirstOrDefault(c => c.Name == characterName);
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
			throw new NotImplementedException();
		}

		public string Attack(string[] args)
		{
			throw new NotImplementedException();
		}

		public string Heal(string[] args)
		{
			throw new NotImplementedException();
		}
	}
}
