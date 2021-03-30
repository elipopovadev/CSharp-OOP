using Persons;
using System.Collections.Generic;

namespace Teams
{
    public class Team
    {
        private string teamName;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public Team(string teamName)
        {
            this.teamName = teamName;
            this.firstTeam = new List<Person>(); // private field
            this.reserveTeam = new List<Person>(); // private field
        }

        public IReadOnlyCollection<Person> FirstTeam // public property without setter
        {
            get => this.firstTeam.AsReadOnly();
        }

        public IReadOnlyCollection<Person> ReserveTeam // public property without setter
        {
            get => this.reserveTeam.AsReadOnly();
        }

        public void AddPlayer(Person person)
        {
            if(person.Age < 40)
            {
                this.firstTeam.Add(person); // private field
            }

            else
            {
                this.reserveTeam.Add(person); // private field
            }
        }
    }
}
