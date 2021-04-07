using System.Collections.Generic;
using System.Text;
using System;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps, List<Mission> missions)
                       : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public List<Mission> Missions { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            decimal roundedSalary = Math.Round(base.Salary, 2);
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {roundedSalary}");
            sb.AppendLine($"Corps: {base.Corps}");
            sb.AppendLine("Missions:");
            foreach (var currentMission in this.Missions)
            {
                sb.AppendLine(currentMission.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

