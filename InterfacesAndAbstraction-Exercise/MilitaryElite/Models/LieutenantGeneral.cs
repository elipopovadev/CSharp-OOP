using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<IPrivate> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
                                : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();            
        }

        public IReadOnlyCollection<IPrivate> Privates => (IReadOnlyCollection < IPrivate >) privates;

        public void AddPrivate(IPrivate @private)
        {
           this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {base.Salary:F2}");
            sb.AppendLine("Privates:");
            foreach (var currentPrivate in Privates)
            {
                sb.AppendLine($"  Name: {currentPrivate.FirstName} {currentPrivate.LastName} Id: {currentPrivate.Id} Salary: {currentPrivate.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
