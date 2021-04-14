using System;
using Vehicles.Exceptions;
using Vehicles.Models;
using VehiclesExtension.Models;

namespace Vehicles.Factory
{
   public class VehiclesCreator
    {
        public Vehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;
            if(type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }

            else if(type == "Truck")
            {
                vehicle = new Truck (fuelQuantity, fuelConsumption, tankCapacity);
            }

            else if(type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
           
            else if (vehicle == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidVehicleTypeMessage);
            }

            return vehicle;
        }
    }
}
