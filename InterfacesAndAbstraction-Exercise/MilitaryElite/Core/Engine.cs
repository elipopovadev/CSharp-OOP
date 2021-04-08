using MilitaryElite.Exceptions;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] commandArguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string soldierType = commandArguments[0];
                int id = int.Parse(commandArguments[1]);
                string firstName = commandArguments[2];
                string lastName = commandArguments[3];

                ISoldier soldier = null;
                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(commandArguments[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }

                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(commandArguments[4]);
                    ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach (var privateId in commandArguments.Skip(5))
                    {
                        ISoldier foundedPrivateToAdd = this.soldiers.First(s => s.Id == int.Parse(privateId));
                        general.AddPrivate((IPrivate)foundedPrivateToAdd);
                    }

                    soldier = general;
                }

                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(commandArguments[4]);
                    string corps = commandArguments[5];
                    try
                    {
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                        string[] repairsArguments = commandArguments.Skip(6).ToArray();
                        for (int i = 0; i < repairsArguments.Length; i += 2)
                        {
                            string partName = repairsArguments[i];
                            int hoursWorked = int.Parse(repairsArguments[i + 1]);
                            IRepair repair = new Repair(partName, hoursWorked);
                            engineer.AddRepair(repair);
                        }

                        soldier = engineer;
                    }

                    catch (InvalidCorpsException)
                    {
                        continue;
                    }
                }

                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(commandArguments[4]);
                    string corps = commandArguments[5];
                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                        string[] missionArguments = commandArguments.Skip(6).ToArray();
                        for (int i = 0; i < missionArguments.Length; i += 2)
                        {
                            try
                            {
                                string missionCodeName = missionArguments[i];
                                string missionState = missionArguments[i + 1];
                                IMission mission = new Mission(missionCodeName, missionState);
                                commando.AddMission(mission);
                            }

                            catch (InvalidMissionStateException)
                            {
                                continue;
                            }
                        }

                        soldier = commando;
                    }

                    catch (InvalidCorpsException)
                    {

                        continue;
                    }
                }

                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(commandArguments[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }
    }
}
