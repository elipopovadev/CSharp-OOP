namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
                                 : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => corps;
            private set
            {
                if(value == "Airforces" || value == "Marines")
                {
                    corps = value;
                }
            }
        }
    }
}
