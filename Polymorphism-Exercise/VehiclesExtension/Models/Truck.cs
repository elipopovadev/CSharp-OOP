using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasingFuelConsumption = 1.6;
        private const double PercentageRefuel = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption; 
            protected set => base.FuelConsumption = value + IncreasingFuelConsumption; 
        }

        public override void Refuel(double amountOfFuel)
        {
            if (amountOfFuel <= 0)
            {
                string exceptionMessage = string.Format(ExceptionMessages.NegativOrZeroFuelMessage);
                throw new InvalidOperationException(exceptionMessage);
            }

            double checkFuelAfterRefueld = this.FuelQuantity + amountOfFuel;
            if (checkFuelAfterRefueld > this.TankCapacity)
            {
                string exceptionMessage = string.Format(ExceptionMessages.InvalidRefuelAmount, amountOfFuel);
                throw new InvalidOperationException(exceptionMessage);
            }

            this.FuelQuantity += amountOfFuel * PercentageRefuel;
        }
    }
}
