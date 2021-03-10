using System;
using System.Collections.Generic;

namespace StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> repository;
        public StudentSystem()
        {
            this.repository = new Dictionary<string, Student>();
        }

        public void ParseCommand()
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
                Exit();
            }
        }

        private void Create(string name, int age, double grade)
        {
            if (!this.repository.ContainsKey(name))
            {
                Student newStudent = new Student(name, age, grade);
                this.repository[name] = newStudent;
            }
        }

        private void Show(string name)
        {
            if (this.repository.ContainsKey(name))
            {
                Student foundedStudent = this.repository[name]; 
                Console.WriteLine(foundedStudent.ToString());
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}



