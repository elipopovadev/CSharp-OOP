using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class CarsDatabase
    {
        public CarsDatabase()
        {
            this.Repository = new Dictionary<string, List<Car>>();
        }
        private Dictionary<string, List<Car>> Repository { get; set; }

        public  void AddCar(Car newCar)
        {
            if (newCar.Cargo.CargoType == "fragile" && !this.Repository.ContainsKey("fragile"))
            {
                this.Repository["fragile"] = new List<Car>();
                this.Repository["fragile"].Add(newCar);              
            }

            else if (newCar.Cargo.CargoType == "fragile" && this.Repository.ContainsKey("fragile"))
            {
                this.Repository["fragile"].Add(newCar);
            }

           else if (newCar.Cargo.CargoType == "flamable" && !this.Repository.ContainsKey("flamable"))
            {
                this.Repository["flamable"] = new List<Car>();
                this.Repository["flamable"].Add(newCar);
            }

            else if (newCar.Cargo.CargoType == "flamable" && this.Repository.ContainsKey("flamable"))
            {
                this.Repository["flamable"].Add(newCar);
            }
        }

        public List<Car> FindCarsAccordingToCargo(string cargo)
        {
            List<Car> cars = new List<Car>();
            foreach (var (cargoType, listOfCars) in this.Repository)
            {
                if(cargoType == "fragile" && cargo == "fragile") 
                {
                    foreach (var car in listOfCars)
                    {
                        if(car.Tires.Any(t=> t.Pressure < 1))
                        {
                            cars.Add(car);
                        }
                    }
                }

                else if(cargoType == "flamable" && cargo == "flamable") 
                {
                    foreach (var car in listOfCars)
                    {
                        if (car.Engine.EnginePower > 250)
                        {
                            cars.Add(car);
                        }
                    }
                }              
            }

            return cars;
        }
    }
}
