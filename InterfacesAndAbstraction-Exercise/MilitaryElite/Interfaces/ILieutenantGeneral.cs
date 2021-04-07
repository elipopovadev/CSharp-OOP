using System.Collections.Generic;

namespace MilitaryElite
{
   public interface ILieutenantGeneral
    {
        public IReadOnlyCollection<Private> Privates { get;}
    }
}
