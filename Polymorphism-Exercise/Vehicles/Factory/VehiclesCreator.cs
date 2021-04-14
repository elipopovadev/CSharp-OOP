using System;
using Vehicles.Exceptions;
using Vehicles.Models;

namespace Vehicles.Factory
{
   public class VehiclesCreator
    {
        public Vehicle Create(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle = null;
            if(type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }

            else if(type == "Truck")
            {
                vehicle = new Truck (fuelQuantity, fuelConsumption);
            }
           
            else if (vehicle == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidVehicleTypeMessage);
            }

            return vehicle;
        }
    }
}
