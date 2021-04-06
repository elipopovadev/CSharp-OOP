using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
   public class Program
    {
        static void Main(string[] args)
        {
            var all = new Dictionary<string, IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArray = input.Split();
                if (inputArray.Length == 2)
                {
                    string model = inputArray[0];
                    string id = inputArray[1];
                    Robot robot = new Robot(model, id);
                    all.Add(robot.ID, robot);
                }

                else if(inputArray.Length == 3)
                {
                    string name = inputArray[0];
                    int age = int.Parse(inputArray[1]);
                    string id = inputArray[2];
                    Citizen citizen = new Citizen(name, age, id);
                    all.Add(citizen.ID, citizen);
                }
            }

            string lastThreeDigitsOfFakeIDs = Console.ReadLine();
            var listWithFakeIDs = all.Where(x => x.Key.EndsWith(lastThreeDigitsOfFakeIDs))
                                  .Select(x => x.Value.ID).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, listWithFakeIDs));                    
        }
    }
}
