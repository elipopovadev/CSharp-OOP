using System;
using System.Linq;
using System.Collections.Generic;

namespace Hospital
{
    public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patients = new List<Patient>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        private List<Patient> Patients { get; set; }

        public void AddPatient(Patient patient)
        {        
            this.Patients.Add(patient);
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
