using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;
            
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)repairs;

        public void AddRepair(IRepair repair)
        {
          this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {base.Salary:F2}");
            sb.AppendLine($"Corps: {base.Corps.ToString()}");
            sb.AppendLine("Repairs:");
            foreach (var currentRepair in this.Repairs)
            {
                sb.AppendLine($"  Part Name: {currentRepair.PartName} Hours Worked: {currentRepair.HoursWorked}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
