using Bakery.Core.Contracts;
using Bakery.Factory;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> allOfferedFood;
        private readonly List<IDrink> allOfferedDrink;
        private readonly List<ITable> allOfferedTable;

        public Controller()
        {
            this.allOfferedFood = new List<IBakedFood>();
            this.allOfferedDrink = new List<IDrink>();
            this.allOfferedTable = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = DrinkCreator.CreateDrink(type, name, portion, brand);
            if(drink != null)
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
            if(table != null)
            {
                allOfferedTable.Add(table);
                return string.Format(OutputMessages.TableAdded, tableNumber);
            }

            return null;
        }

        public string GetFreeTablesInfo()
        {
            throw new System.NotImplementedException();
        }

        public string GetTotalIncome()
        {
            throw new System.NotImplementedException();
        }

        public string LeaveTable(int tableNumber)
        {
            throw new System.NotImplementedException();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable findedTable = allOfferedTable.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = allOfferedDrink.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if(findedTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if(drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            return string.Format(OutputMessages.NonExistentDrink);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable findedTable = allOfferedTable.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = allOfferedFood.FirstOrDefault(f => f.Name == foodName);
            if(findedTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if(food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable findedTable= allOfferedTable.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);
            if(findedTable!= null)
            {
                return string.Format(OutputMessages.TableReserved, numberOfPeople);
            }

            return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
        }
    }
}
