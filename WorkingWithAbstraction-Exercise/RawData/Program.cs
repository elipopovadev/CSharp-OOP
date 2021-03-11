using System;
using System.Collections.Generic;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarsDatabase carsDatabase = new CarsDatabase();
            int inputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                Engine newEngine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Cargo newCargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4];
                int count = 0;
                for (int k = 5; k < 13; k+=2)
                {
                    double tirePressure = double.Parse(input[k]);
                    int tireAge = int.Parse(input[k+1]);
                    Tire newTire = new Tire(tirePressure, tireAge);
                    tires[count] = newTire;
                    count++;
                }

                Car newCar = new Car(model, newEngine, newCargo, tires);
                carsDatabase.AddCar(newCar);                           
            }

            string cargo = Console.ReadLine();
            List<Car> foundedCars = carsDatabase.FindCarsAccordingToCargo(cargo);
            foreach (Car car in foundedCars)
            {
                Console.WriteLine(car);
            }            
        }
    }
}
