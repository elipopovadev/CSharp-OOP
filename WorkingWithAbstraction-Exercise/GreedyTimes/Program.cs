using System;

namespace GreedyTimes
{
   public class Program
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            PersonalBag personalBag = new PersonalBag(capacity);
            string[] inputInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputInfo.Length ; i+=2)
            {
                string item = inputInfo[i];
                string itemToLower = item.ToLower();
                long quantity = long.Parse(inputInfo[i+1]);
                if(itemToLower == "gold")
                {
                    Gold gold = new Gold(quantity);
                    personalBag.AddGold(gold);
                }

                else if(item.Length == 3)
                {
                    string currency = item;
                    Cash cash = new Cash(currency, quantity);
                    personalBag.AddCash(cash);
                }

                else if(itemToLower.EndsWith("gem") && item.Length >= 4)
                {
                    string gemName = item;
                    Gem gem = new Gem(gemName, quantity);
                    personalBag.AddGem(gem);
                }
            }

            personalBag.PrintTotalAmount();
        }
    }
}
