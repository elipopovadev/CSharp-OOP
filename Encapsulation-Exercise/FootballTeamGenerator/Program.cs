using System;
using System.Linq;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commandArray = command.Split(";");
                    if (commandArray.Contains("Team"))
                    {
                        string teamName = commandArray[1];
                        Team newTeam = new Team(teamName);
                        teams.Add(teamName, newTeam);
                    }

                    else if (commandArray.Contains("Add"))
                    {
                        string teamName = commandArray[1];
                        string playerName = commandArray[2];
                        int endurance = int.Parse(commandArray[3]);
                        int sprint = int.Parse(commandArray[4]);
                        int dribble = int.Parse(commandArray[5]);
                        int passing = int.Parse(commandArray[6]);
                        int shooting = int.Parse(commandArray[7]);
                        Player newPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        Team foundedTeam = teams.FirstOrDefault(t => t.Key == teamName).Value;
                        if (foundedTeam == default)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }

                        else
                        {
                            foundedTeam.AddPlayer(newPlayer);
                        }
                    }

                    else if (commandArray.Contains("Remove"))
                    {
                        string teamName = commandArray[1];
                        string playerName = commandArray[2];
                        Team foundedTeam = teams.FirstOrDefault(t => t.Key == teamName).Value;
                        if (foundedTeam == default)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }

                        else
                        {
                            foundedTeam.RemovePlayer(playerName);
                        }
                    }

                    else if (commandArray.Contains("Rating"))
                    {
                        string teamName = commandArray[1];
                        Team foundedTeam = teams.FirstOrDefault(t => t.Key == teamName).Value;
                        if (foundedTeam == default)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }

                        else
                        {
                            Console.WriteLine($"{foundedTeam.TeamName} - {foundedTeam.Rating}");
                        }
                    }
                }

                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
