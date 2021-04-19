namespace Vehicles.Models
{
    public class Truck : Vehicle
    {      
        private const double IncrementIncreasingFuelConsumption = 1.6;
        private const double IncrementForFuelConsumption = 0.95;
        private double fuelConsumption;
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public override double FuelConsumption
        {
            get => fuelConsumption;
            protected set
            {
                this.fuelConsumption = value + IncrementIncreasingFuelConsumption;
            }
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * IncrementForFuelConsumption;
        }
    }
}
