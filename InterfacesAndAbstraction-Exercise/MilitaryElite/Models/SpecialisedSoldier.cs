using MilitaryElite.Exceptions;
using System;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
                                 : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        public Corps TryParseCorps(string corpsStr)
        {
            bool parsed = Enum.TryParse<Corps>(corpsStr, out Corps corps);
            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }
    }
}
