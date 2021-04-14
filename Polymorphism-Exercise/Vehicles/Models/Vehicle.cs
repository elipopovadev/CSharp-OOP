using System;
using Vehicles.Exceptions;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IFuel, IDriveable, IRefuelable
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public virtual double  FuelConsumption { get; protected set; }

        public string Drive(double distance)
        {
            double needFuel = this.FuelConsumption * distance;
            if(this.FuelQuantity >= needFuel)
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

        public virtual void Refuel(double amountOfFuel)
        {
            this.FuelQuantity += amountOfFuel;
        }
    }
}
