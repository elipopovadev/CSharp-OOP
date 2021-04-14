using System;
using Vehicles.Exceptions;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IFuel, IDriveable, IRefuelable
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; protected set; }
        public virtual double FuelConsumption { get; protected set; }
        public double TankCapacity { get;}

        public string Drive(double distance)
        {
            double needFuel = this.FuelConsumption * distance;
            if (this.FuelQuantity >= needFuel)
            {
                this.FuelQuantity -= needFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            else
            {
                string exceptionMessage = String.Format(ExceptionMessages.NotEnoughFuelMessage, this.GetType().Name);
                throw new InvalidOperationException(exceptionMessage);
            }
        }

        public virtual string DriveWithAirConditioner(double distance)
        {
            return null;
        }

        public virtual void Refuel(double amountOfFuel)
        {
            if(amountOfFuel <= 0)
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

            this.FuelQuantity += amountOfFuel;
        }
    }
}
