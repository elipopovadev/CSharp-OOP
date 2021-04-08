using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get;}

        public void AddRepair(IRepair repair);
    }
}
