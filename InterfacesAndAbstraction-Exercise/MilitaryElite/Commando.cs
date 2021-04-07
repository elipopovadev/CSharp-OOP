using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {this.Salary:f2}");
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

