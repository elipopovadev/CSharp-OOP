using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Hospital
    {
        public Hospital()
        {
            this.Departments = new List<Department>();
            this.Doctors = new List<Doctor>();
        }

        public List<Department> Departments { get; set; }
        public List<Doctor> Doctors { get; set; }

        public void AddDepartment(Department department)
        {
            this.Departments.Add(department);          
        }

        public void AddDoctor(Doctor doctor)
        {
            if (!this.Doctors.Any(d => d.FirstName == doctor.FirstName && d.LastName == doctor.LastName))
            {
                this.Doctors.Add(doctor);
            }

            else
            {
                Doctor foundedDoctor = this.Doctors.Where(d => d.FirstName == doctor.FirstName && d.LastName == doctor.LastName).First();
                doctor = foundedDoctor;
            }
        }
    }
}
