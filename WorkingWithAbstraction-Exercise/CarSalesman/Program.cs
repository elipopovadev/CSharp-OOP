using System;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            EnginesDatabase enginesDatabase = new EnginesDatabase();
            CarsDatabase carsDatabase = new CarsDatabase();
            int enginesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesNumber; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if(engineInfo.Length == 2)
                {
                    string model = engineInfo[0];
                    string power = engineInfo[1];
                    Engine newEngine = new Engine(model, power);
                    enginesDatabase.AddEngine(newEngine);
                }

                else if(engineInfo.Length == 3)
                {
                    string model = engineInfo[0];
                    string power = engineInfo[1];
                    if(int.TryParse(engineInfo[2], out int displacement))
                    {
                        Engine newEngine = new Engine(model, power, displacement);
                        enginesDatabase.AddEngine(newEngine);
                    }

                    else
                    {
                        string efficiency = engineInfo[2];
                        Engine newEngine = new Engine(model, power, efficiency);
                        enginesDatabase.AddEngine(newEngine);
                    }
                }

                else if(engineInfo.Length == 4)
                {
                    string model = engineInfo[0];
                    string power = engineInfo[1];
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];
                    Engine newEngine = new Engine(model, power, displacement, efficiency);
                    enginesDatabase.AddEngine(newEngine);
                }
            }

            int carsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsNumber; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (carInfo.Length == 2)
                {
                    string model = carInfo[0];
                    string engineModel = carInfo[1];
                    Engine foundedEngine = enginesDatabase.FindEngine(engineModel);
                    Car newCar = new Car(model, foundedEngine);
                    carsDatabase.AddCar(newCar);                                      
                }

                else if(carInfo.Length == 3)
                {
                    string model = carInfo[0];
                    string engineModel = carInfo[1];
                    Engine foundedEngine = enginesDatabase.FindEngine(engineModel);
                    if(int.TryParse(carInfo[2], out int weight))
                    {
                        Car newCar = new Car(model, foundedEngine, weight);
                        carsDatabase.AddCar(newCar);
                    }

                    else
                    {
                        string color = carInfo[2];
                        Car newCar = new Car(model, foundedEngine, color);
                        carsDatabase.AddCar(newCar);
                    }
                }

                else if (carInfo.Length == 4)
                {
                    string model = carInfo[0];
                    string engineModel = carInfo[1];
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];
                    Engine foundedEngine = enginesDatabase.FindEngine(engineModel);                    
                    Car newCar = new Car(model, foundedEngine, weight, color);
                    carsDatabase.AddCar(newCar);
                }
            }

            carsDatabase.PrintAllCars();
        }
    }
}

