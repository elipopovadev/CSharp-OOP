using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private Dictionary<string, Player> teamPlayers;
        private string teamName;
        public Team(string teamName)
        {
            this.TeamName = teamName;
            teamPlayers = new Dictionary<string, Player>();
        }

        public string TeamName
        {
            get => teamName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                teamName = value;
            }
        }

        public int NumberOfPlayers => teamPlayers.Count;

        public int Rating => this.CalculateTeamRating();

        private int CalculateTeamRating()
        {
            if (this.teamPlayers.Count > 0)
            {
                double result = this.teamPlayers.Select(p => p.Value.PlayerSkills).Average();
                return (int)Math.Round(result);
            }

            else
            {
                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            if (!teamPlayers.ContainsKey(player.Name))
            {
                teamPlayers.Add(player.Name, player);
            }
        }

        public void RemovePlayer(string playerName)
        {
            if (!teamPlayers.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.TeamName} team.");
            }

            teamPlayers.Remove(playerName);
        }
    }
}
