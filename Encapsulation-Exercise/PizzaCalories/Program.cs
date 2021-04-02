using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] firstLine = Console.ReadLine().Split(" ");
                string pizzaName = firstLine[1];

                string[] secondLine = Console.ReadLine().Split(" ");
                string doughType = secondLine[1];
                string bakingTechnique = secondLine[2];
                int weigh = int.Parse(secondLine[3]);
                Dough newDought = new Dough(doughType, bakingTechnique, weigh);

                Pizza newPizza = new Pizza(pizzaName, newDought);

                string nextInput;
                while ((nextInput = Console.ReadLine()) != "END")
                {
                    string[] toppingLine = nextInput.Split(" ");
                    string toppingType = toppingLine[1];
                    int weighTopping = int.Parse(toppingLine[2]);
                    Topping newTopping = new Topping(toppingType, weighTopping);
                    newPizza.AddTopping(newTopping);
                }

                Console.WriteLine($"{newPizza.Name} - {newPizza.TotalCalories:f2} Calories.");
            }

            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message); 
            }           
        }
    }
}
