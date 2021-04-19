namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double IncrementIncreasingFuelConsumption = 0.9;
        private double fuelConsumption;
        public Car(double fuelQuantity, double fuelConsumption)
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
    }
}
