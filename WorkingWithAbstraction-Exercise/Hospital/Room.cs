using System;
using System.Linq;
using System.Collections.Generic;

namespace Hospital
{
    public class Room
    {
        private const int maxCapacity = 3;
        public Room(byte number)
        {
            this.Number = number;
            this.Patients = new List<Patient>();
        }

        public byte Number { get; }
        public int Count => this.Patients.Count;

        public List<Patient> Patients { get;}

        public void Add( Patient patient)
        {
            if (this.Count < maxCapacity)
            {
                this.Patients.Add(patient);
            }
        }

        public void PrintPatients()
        {
            foreach (var patient in this.Patients.OrderBy(p=>p.Name))
            {
                Console.WriteLine(patient);
            }
        }
    }
}
