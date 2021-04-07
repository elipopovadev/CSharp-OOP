using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, List<Private> privates)
                                : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;            
        }

        public IReadOnlyCollection<Private> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            decimal roundedSalary = Math.Round(base.Salary, 2);
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {roundedSalary:f2}");
            sb.AppendLine("Privates:");
            foreach (var currentPrivate in Privates)
            {
                sb.AppendLine($" {currentPrivate.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
