using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps, ICollection<Repair> repairs)
                       : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public ICollection<Repair> Repairs { get;}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            decimal roundedSalary = Math.Round(base.Salary, 2);
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {roundedSalary}");
            sb.AppendLine($"Corps: {base.Corps}");
            sb.AppendLine("Repairs:");
            foreach (var currentRepair in this.Repairs)
            {
                sb.AppendLine(currentRepair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
