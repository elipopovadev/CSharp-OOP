using System;
using Vehicles.Interfaces;
using Vehicles.IO;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public void Run()
        {
            string[] input = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            IVehicle car = new Car(fuelQuantity, fuelConsumption);
            string[] secondInput = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IVehicle truck = new Truck(double.Parse(secondInput[1]), double.Parse(secondInput[2]));

            int numberOfCommand = int.Parse(reader.ReadLine());
            for (int i = 0; i < numberOfCommand; i++)
            {
                string[] commandArray = reader.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = commandArray[0];
                string typeVehicle = commandArray[1];
                if(typeCommand == "Drive")
                {
                    double distance = double.Parse(commandArray[2]);
                    if(typeVehicle == "Car")
                    {
                       writer.WriteLine(car.Drive(distance));
                    }

                    else if(typeVehicle == "Truck")
                    {
                        writer.WriteLine(truck.Drive(distance));
                    }
                }

                else if(typeCommand == "Refuel")
                {
                    double fuelForRefuel = double.Parse(commandArray[2]);
                    if(typeVehicle == "Car")
                    {
                        car.Refuel(fuelForRefuel);
                    }

                    else if(typeVehicle == "Truck")
                    {
                        truck.Refuel(fuelForRefuel);
                    }
                }
            }

            writer.WriteLine($"Car: {car.FuelQuantity:F2}");
            writer.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
