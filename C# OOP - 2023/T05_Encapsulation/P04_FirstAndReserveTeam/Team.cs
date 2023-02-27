using System;
using PersonsInfo;

namespace P04_FirstAndReserveTeam
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new();
            this.reserveTeam = new();
        }

        public IReadOnlyCollection<Person> FirstTeam
        {
            get => this.firstTeam.AsReadOnly();
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get => this.reserveTeam.AsReadOnly();
        }


        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}