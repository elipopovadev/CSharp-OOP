using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasingFuelConsumption = 1.6;
        private const double PercentageRefuel = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption; 
            protected set => base.FuelConsumption = value + IncreasingFuelConsumption; 
        }

        public override void Refuel(double amountOfFuel)
        {
            base.Refuel(amountOfFuel * PercentageRefuel);
        }
    }
}
