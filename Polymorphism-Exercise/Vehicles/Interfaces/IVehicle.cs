namespace Vehicles.Interfaces
{
    public interface IVehicle : IDrivable, IRefuelable
    {
        public  double FuelQuantity { get;}
        public double FuelConsumption { get;}
    }
}
