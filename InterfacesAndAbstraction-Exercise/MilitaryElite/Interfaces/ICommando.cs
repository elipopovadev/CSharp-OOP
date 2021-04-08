using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get;}
        public void AddMission(IMission mission);
    }
}
