using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection <IMission>) missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {base.Salary:F2}");
            sb.AppendLine($"Corps: {base.Corps.ToString()}");
            sb.AppendLine("Missions:");
            foreach (var currentMission in this.Missions)
            {
                sb.AppendLine($"  Code Name: {currentMission.CodeName} State: {currentMission.State.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

