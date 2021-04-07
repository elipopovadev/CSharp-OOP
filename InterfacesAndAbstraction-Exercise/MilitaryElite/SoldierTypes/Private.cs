using System;
using System.Text;
namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            decimal roundedSalary = Math.Round(this.Salary, 2);
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {roundedSalary}");
            return sb.ToString().TrimEnd();
        }
    }
}
