using System.Collections.Generic;

namespace MilitaryElite
{
    interface ILieutenantGeneral
    {
        public IReadOnlyCollection<Private> Privates { get;}
    }
}
