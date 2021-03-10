using System.Collections.Generic;

namespace StudentSystem
{
   public class StudentDataBase
    {
        private Dictionary<string, Student> repository;
        public StudentDataBase()
        {
            this.repository = new Dictionary<string, Student>();
        }

        public void Add(string name, int age, double grade)
        {
            if (!this.repository.ContainsKey(name))
            {
                Student student = new Student(name, age, grade);
                this.repository[name]= student;
            }
        }

        public Student Find(string name)
        {
            if (this.repository.ContainsKey(name))
            {
                return this.repository[name];
            }

            return null;
        }
    }
}

