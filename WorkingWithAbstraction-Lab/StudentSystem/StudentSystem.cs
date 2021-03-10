using System;

namespace StudentSystem
{
    public class StudentSystem
    {
        private StudentDataBase studentDatabase;
        public StudentSystem()
        {
            this.studentDatabase = new StudentDataBase();
        }

        public void ParseCommands()
        {
            while (true)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];
                if (command == "Create")
                {
                    string name = commandArgs[1];
                    int age = int.Parse(commandArgs[2]);
                    double grade = double.Parse(commandArgs[3]);
                    Create(name, age, grade);
                }

                else if (command == "Show")
                {
                    string name = commandArgs[1];
                    Show(name);
                }

                else if (command == "Exit")
                {
                    return;
                }
            }
        }

        private void Create(string name, int age, double grade)
        {
            studentDatabase.Add(name, age, grade);
        }

        private void Show(string name)
        {
            Student student = studentDatabase.Find(name);
            if (student != null)
            {
                Console.WriteLine(student);
            }
        }
    }
}

