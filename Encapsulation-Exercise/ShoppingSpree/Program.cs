using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
   public class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            string[] secondLine = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> allPeople = new Dictionary<string, Person>();
            Dictionary<string, Product> allProducts = new Dictionary<string, Product>();

            try
            {
                for (int i = 0; i < firstLine.Count(); i++)
                {
                    string[] person = firstLine[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = person[0];
                    decimal money = decimal.Parse(person[1]);
                    Person newPerson = new Person(name, money);
                    if (!allPeople.ContainsKey(newPerson.Name))
                    {
                        allPeople.Add(newPerson.Name, newPerson);
                    }
                }

                for (int i = 0; i < secondLine.Count(); i++)
                {
                    string[] product = secondLine[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string productName = product[0];
                    decimal productCost = decimal.Parse(product[1]);
                    Product newProduct = new Product(productName, productCost);
                    if (!allProducts.ContainsKey(newProduct.Name))
                    {
                        allProducts.Add(newProduct.Name, newProduct);
                    }
                }

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = inputArray[0];
                    string productName = inputArray[1];
                    Person findedPerson = allPeople.FirstOrDefault(person => person.Key == personName).Value;
                    Product findedProduct = allProducts.FirstOrDefault(product => product.Key == productName).Value;
                    findedPerson.AddProduct(findedProduct);
                }

                foreach (var (stringName, person) in allPeople)
                {
                    Console.WriteLine(person.ToString());
                }
            }

            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }
        }
    }
}
