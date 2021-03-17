using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{
    public class PersonalBag
    {
        private long totalSumGem;
        private long totalSumCash;

        public PersonalBag(long capacity)
        {
            this.CountTotalItems = 0;
            this.Capacity = capacity;
            this.GoldQuantity = 0;
            this.GemQuantity = new List<Gem>();
            this.CashQuantity = new List<Cash>();
        }

        private long CountTotalItems { get; set; }
        public long Capacity { get; private set; }
        public long GoldQuantity { get; private set; }
        public List<Gem> GemQuantity { get; private set; }
        public List<Cash> CashQuantity { get; private set; }
        private long CheckTotalSumCash()
        {
            totalSumCash = 0;
            foreach (var currency in this.CashQuantity)
            {
                totalSumCash += currency.Quantity;
            }

            return totalSumCash;
        }

        private long CheckTotalSumGem()
        {
            totalSumGem = 0;
            foreach (Gem currentGem in this.GemQuantity)
            {
                totalSumGem += currentGem.Quantity;
            }

            return totalSumGem;
        }
        public void AddGold(Gold gold)
        {
            if (this.CountTotalItems + gold.Quantity <= this.Capacity)
            {
                this.GoldQuantity += gold.Quantity;
                this.CountTotalItems += gold.Quantity;
            }
        }

        public void AddGem(Gem gem)
        {
            if (this.CountTotalItems + gem.Quantity <= this.Capacity)
            {
                totalSumGem = CheckTotalSumGem();
                totalSumCash = CheckTotalSumCash();
                if ((totalSumGem + gem.Quantity <= this.GoldQuantity) && (totalSumGem + gem.Quantity >= totalSumCash))
                {
                    if (this.GemQuantity.Any(g => g.Name == gem.Name))
                    {
                        Gem foundedGem = this.GemQuantity.Where(g => g.Name == gem.Name).First();
                        foundedGem.Quantity += gem.Quantity;
                        totalSumGem += gem.Quantity;
                    }
                    else
                    {
                        this.GemQuantity.Add(gem);
                        totalSumGem += gem.Quantity;
                    }

                    this.CountTotalItems += gem.Quantity;
                }
            }
        }

        public void AddCash(Cash cash)
        {
            if (this.CountTotalItems + cash.Quantity <= this.Capacity)
            {
                totalSumGem = CheckTotalSumGem();
                totalSumCash = CheckTotalSumCash();
                if (totalSumCash + cash.Quantity <= totalSumGem)
                {
                    if (this.CashQuantity.Any(c => c.Currency == cash.Currency))
                    {
                        Cash foundCurrency = this.CashQuantity.Where(c => c.Currency == cash.Currency).First();
                        foundCurrency.Quantity += cash.Quantity;
                        totalSumCash += cash.Quantity;
                    }

                    else
                    {
                        this.CashQuantity.Add(cash);
                        totalSumCash += cash.Quantity;
                    }

                    this.CountTotalItems += cash.Quantity;
                }
            }
        }

        public void PrintTotalAmount()
        {
            if (this.GoldQuantity > 0)
            {
                Console.WriteLine($"<Gold> ${this.GoldQuantity}");
                Console.WriteLine($"##Gold - {this.GoldQuantity}");
            }        

            if (this.GemQuantity.Count > 0)
            {
                Console.WriteLine($"<Gem> ${totalSumGem}");
                foreach (var gem in this.GemQuantity.OrderByDescending(g => g.Name).ThenBy(g => g.Quantity))
                {
                    Console.WriteLine($"##{gem.Name} - {gem.Quantity}");
                }
            }

            if (this.CashQuantity.Count > 0)
            {
                Console.WriteLine($"<Cash> ${totalSumCash}");
                foreach (var cash in this.CashQuantity.OrderByDescending(c => c.Currency).ThenBy(c => c.Quantity))
                {
                    Console.WriteLine($"##{cash.Currency} - {cash.Quantity}");
                }
            }
        }
    }
}
