using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car(300, 6);
            Console.WriteLine(car.Fuel); // 6
            car.Drive(100);
            Console.WriteLine(car.Fuel); // 3

            Car sportCar = new SportCar(500, 10);
            Console.WriteLine(sportCar.Fuel); // 10
            sportCar.Drive(100);
            Console.WriteLine(sportCar.Fuel); // 0    
            sportCar.Drive(10);
        }
    }
}
