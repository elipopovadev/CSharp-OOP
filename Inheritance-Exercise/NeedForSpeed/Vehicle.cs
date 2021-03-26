using System;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuilConsumption { get => defaultFuelConsumption; }

        public void Drive(double kilometers)
        {
            if (this.FuilConsumption * kilometers / 100 <= this.Fuel)
            {
                this.Fuel -= this.FuilConsumption * kilometers / 100;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
