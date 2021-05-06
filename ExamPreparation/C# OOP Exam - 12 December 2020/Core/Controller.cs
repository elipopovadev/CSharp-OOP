using Bakery.Core.Contracts;
using Bakery.Factory;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> allOfferedFood;
        private readonly List<IDrink> allOfferedDrink;
        private readonly List<ITable> allOfferedTable;
        private decimal totalIncome;

        public Controller()
        {
            this.allOfferedFood = new List<IBakedFood>();
            this.allOfferedDrink = new List<IDrink>();
            this.allOfferedTable = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = DrinkCreator.CreateDrink(type, name, portion, brand);
            if (drink != null)
            {
                allOfferedDrink.Add(drink);
                return string.Format(OutputMessages.DrinkAdded, name, brand);
            }

            return null;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = FoodCreator.CreateFood(type, name, price);
            if (food != null)
            {
                allOfferedFood.Add(food);
                return string.Format(OutputMessages.FoodAdded, type, name);
            }

            return null; // bad practice, but requirement
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = TableCreator.CreateTable(type, tableNumber, capacity);
            if (table != null)
            {
                allOfferedTable.Add(table);
                return string.Format(OutputMessages.TableAdded, tableNumber);
            }

            return null;
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> listWithFreeTables = allOfferedTable.Where(t => !t.IsReserved).ToList();
            var sb = new StringBuilder();
            foreach (var table in listWithFreeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {         
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable foundedTable = this.allOfferedTable.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (foundedTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var sb = new StringBuilder();
            totalIncome += foundedTable.GetBill();
            sb.AppendLine($"Table : {tableNumber}");
            sb.AppendLine($"Bill:  {foundedTable.GetBill():f2}");
            foundedTable.Clear();
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable foundedTable = allOfferedTable.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = allOfferedDrink.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (foundedTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            foundedTable.OrderDrink(drink);
            return string.Format(OutputMessages.DrinkAdded, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable foundedTable = allOfferedTable.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = allOfferedFood.FirstOrDefault(f => f.Name == foodName);
            if (foundedTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            foundedTable.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable foundedTable = allOfferedTable.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);
            if (foundedTable != null)
            {
                foundedTable.Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, foundedTable.TableNumber, numberOfPeople);
            }

            return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
        }
    }
}
