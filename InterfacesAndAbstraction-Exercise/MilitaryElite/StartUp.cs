using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var totalSoldiers = new List<Soldier>();
            var onlyAllPrivates = new Dictionary<int, Private>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string militaryType = inputArray[0];
                if (militaryType == "Private")
                {
                    int id = int.Parse(inputArray[1]);
                    string firstName = inputArray[2];
                    string lastName = inputArray[3];
                    decimal salary = decimal.Parse(inputArray[4]);
                    Private newPrivate = new Private(id, firstName, lastName, salary);
                    onlyAllPrivates.Add(id, newPrivate);
                    totalSoldiers.Add(newPrivate);
                }

                else if (militaryType == "Spy")
                {
                    string firstName = inputArray[1];
                    string lastName = inputArray[2];
                    int id = int.Parse(inputArray[3]);
                    int codeNumber = int.Parse(inputArray[4]);
                    Soldier newSpy = new Spy(id, firstName, lastName, codeNumber);
                    totalSoldiers.Add(newSpy);
                }

                else if (militaryType == "LieutenantGeneral")
                {
                    int id = int.Parse(inputArray[1]);
                    string firstName = inputArray[2];
                    string lastName = inputArray[3];
                    decimal salary = decimal.Parse(inputArray[4]);
                    var privatesForCurrentLieutenant = new List<Private>();
                    for (int i = 5; i < inputArray.Length; i++)
                    {
                        int idCurrentPrivate = int.Parse(inputArray[i]);
                        Private foundedPrivate = onlyAllPrivates.FirstOrDefault(p => p.Key == idCurrentPrivate).Value;
                        privatesForCurrentLieutenant.Add(foundedPrivate); 
                    }

                    Soldier newLieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privatesForCurrentLieutenant);
                    totalSoldiers.Add(newLieutenantGeneral);
                }

                else if (militaryType == "Engineer")
                {

                    int id = int.Parse(inputArray[1]);
                    string firstName = inputArray[2];
                    string lastName = inputArray[3];
                    decimal salary = decimal.Parse(inputArray[4]);
                    string corps = inputArray[5];
                    var repairsForCurrentEngineer = new List<Repair>();
                    for (int i = 6; i < inputArray.Length; i += 2)
                    {
                        string part = inputArray[i];
                        int hours = int.Parse(inputArray[i + 1]);
                        try
                        {
                            Repair newrepair = new Repair(part, hours);
                            repairsForCurrentEngineer.Add(newrepair);
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                        Soldier newEngineer = new Engineer(id, firstName, lastName, salary, corps, repairsForCurrentEngineer);
                        totalSoldiers.Add(newEngineer);                   
                }

                else if (militaryType == "Commando")
                {

                    int id = int.Parse(inputArray[1]);
                    string firstName = inputArray[2];
                    string lastName = inputArray[3];
                    decimal salary = decimal.Parse(inputArray[4]);
                    string corps = inputArray[5];
                    var missionsForCurrentCommando = new List<Mission>();
                    for (int i = 6; i < inputArray.Length; i += 2)
                    {
                        try
                        {
                            string codeName = inputArray[i];
                            string state = inputArray[i + 1];
                            Mission newMission = new Mission(codeName, state);
                            missionsForCurrentCommando.Add(newMission);
                        }

                        catch (Exception ex)
                        {

                        }
                    }

                    Soldier newCommando = new Commando(id, firstName, lastName, salary, corps, missionsForCurrentCommando);
                    totalSoldiers.Add(newCommando);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, totalSoldiers));
        }
    }
}
