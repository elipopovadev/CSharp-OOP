using System;
using Vehicles.Factory;
using Vehicles.IO;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private VehiclesCreator vehiclesCreator;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.vehiclesCreator = new VehiclesCreator();
        }

        public void Run()
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int numberCommands = int.Parse(reader.ReadLine());
            for (int i = 0; i < numberCommands; i++)
            {
                string[] input = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = input[0];
                string vehicleType = input[1];
                string thirdArgument = input[2];

                try
                {
                    if (commandType == "Drive")
                    {
                        double distance = double.Parse(thirdArgument);
                        if (vehicleType == "Car")
                        {
                            writer.WriteLine(car.Drive(distance));
                        }

                        else if (vehicleType == "Truck")
                        {
                            writer.WriteLine(truck.Drive(distance));
                        }

                        else if (vehicleType == "Bus")
                        {
                            writer.WriteLine(bus.DriveWithAirConditioner(distance));
                        }
                    }

                    else if(commandType == "DriveEmpty")
                    {
                        double distance = double.Parse(thirdArgument);
                        writer.WriteLine(bus.Drive(distance));
                    }

                    else if (commandType == "Refuel")
                    {
                        double fuel = double.Parse(thirdArgument);
                        if (vehicleType == "Car")
                        {
                            car.Refuel(fuel);
                        }

                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(fuel);
                        }

                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(fuel);
                        }
                    }
                }

                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            writer.WriteLine($"Car: {car.FuelQuantity:F2}");
            writer.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            writer.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }


        private Vehicle CreateVehicle()
        {
            string[] input = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = input[0];
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);
            Vehicle vehicle = vehiclesCreator.Create(type, fuelQuantity, fuelConsumption, tankCapacity);
            return vehicle;
        }
    }
}
