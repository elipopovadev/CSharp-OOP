using System;
using System.Collections.Generic;

namespace CarSalesman
{
    class CarsDatabase
    {
        public CarsDatabase()
        {
            this.Collection = new List<Car>();
        }

        private List<Car> Collection { get; set; }

        public void AddCar(Car car)
        {
            this.Collection.Add(car);
        }

        public void PrintAllCars()
        {
            foreach (var car in this.Collection)
            {
                Console.WriteLine(car);
            }
        }
    }
}


