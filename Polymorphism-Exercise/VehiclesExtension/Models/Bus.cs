using System;
using Vehicles.Exceptions;
using Vehicles.Models;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double IncreasingFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string DriveWithAirConditioner(double distance)
        {
            double fuelConsumptionWithAirConditioner = base.FuelConsumption + IncreasingFuelConsumption;
            double needFuel = fuelConsumptionWithAirConditioner * distance;
            if (this.FuelQuantity >= needFuel)
            {
                base.FuelQuantity -= needFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            else
            {
                string exceptionMessage = String.Format(ExceptionMessages.NotEnoughFuelMessage, this.GetType().Name);
                throw new InvalidOperationException(exceptionMessage);
            }
        }      
    }
}
