using System;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
     {     
        public double FuelQuantity { get; protected set; }

        public abstract double FuelConsumption { get; protected set; }

        public string Drive(double distance)
        {
            double checkerForFuel = this.FuelConsumption * distance;
            if(this.FuelQuantity >= checkerForFuel)
            {
                this.FuelQuantity -= checkerForFuel;
                return String.Format("{0} travelled {1} km", this.GetType().Name, distance);
            }

            else
            {
                return string.Format("{0} needs refueling", this.GetType().Name);
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
