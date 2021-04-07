using System.Collections.Generic;

namespace MilitaryElite
{
    interface IEngineer
    {
        public ICollection<Repair> Repairs { get;}
    }
}
