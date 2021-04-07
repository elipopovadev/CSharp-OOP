using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer
    {
        public ICollection<Repair> Repairs { get;}
    }
}
