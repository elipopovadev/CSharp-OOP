using System;
using System.Linq;

namespace Hospital
{
    public class Program
    {
        static void Main(string[] args)
        {
            Hospital newHospital = new Hospital();
            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] hospitalInfo = input.Split();
                string departmentName = hospitalInfo[0];
                string doctorFirstName = hospitalInfo[1];
                string doctorLastName = hospitalInfo[2];
                string patientName = hospitalInfo[3];
                Patient newPatient = new Patient(patientName); // unique name with length 1 < n < 20

                if (!newHospital.Departments.Any(d => d.Name == departmentName))
                {
                    Department newDepartment = new Department(departmentName);
                    newHospital.AddDepartment(newDepartment);
                    newDepartment.AddPatient(newPatient);                   
                }

                else
                {
                    Department foundedDepartment = newHospital.Departments.Where(dep => dep.Name == departmentName).First();
                    foundedDepartment.AddPatient(newPatient);
                }

                if (!newHospital.Doctors.Any(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName))
                {
                    Doctor newDoctor = new Doctor(doctorFirstName, doctorLastName);
                    newHospital.AddDoctor(newDoctor);
                    if (newHospital.Departments.Any(r => r.Rooms.Any(r => r.Patients.Contains(newPatient))))
                    {
                        newDoctor.AddPatient(newPatient);
                    }
                }

                else
                {
                    Doctor foundedDoctor = newHospital.Doctors.Where(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName).First();
                    if (newHospital.Departments.Any(r => r.Rooms.Any(r => r.Patients.Contains(newPatient))))
                    {
                        foundedDoctor.AddPatient(newPatient);
                    }
                }              
            }
;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (commandArray.Length == 1)
                {
                    string departmentName = commandArray[0];
                    Department foundedDepartment = newHospital.Departments.Where(d => d.Name == departmentName).First();
                    foundedDepartment.PrintPatients();
                }

                else if (commandArray.Length == 2)
                {
                    if (byte.TryParse(commandArray[1], out byte roomNumber))
                    {
                        string departmentName = commandArray[0];
                        Department foundedDepartment = newHospital.Departments.Where(d => d.Name == departmentName).First();
                        foundedDepartment.Rooms[roomNumber - 1].PrintPatients();
                    }

                    else
                    {
                        string doctorFirstName = commandArray[0];
                        string doctorLastName = commandArray[1];
                        Doctor foundedDoctor = newHospital.Doctors.Where(d => d.FirstName == doctorFirstName && d.LastName == doctorLastName).First();
                        foundedDoctor.PrintPatients();
                    }
                }
            }
        }
    }
}
