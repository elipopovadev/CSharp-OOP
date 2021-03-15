using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    public class Department
    {

        private const int maxRoomCapacity = 3;
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
            this.InitializeRooms();
        }

        public string Name { get; set; }
        public List<Room> Rooms { get; }

        public int Count { get; private set; }

        private void InitializeRooms()
        {
            for (byte i = 0; i < 20; i++)
            {
                Room newRoom = new Room(i);
                this.Rooms.Add(newRoom);
            }
        }

        public void AddPatient(Patient patient)
        {
            for (byte i = 0; i < 20; i++)
            {
                this.Rooms[i].Add(patient);
                this.Count++;
                if (this.Rooms.Any(r => r.Patients.Contains(patient)))
                {
                    break;
                }
            }
        }

        public void PrintPatients()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.AppendLine(string.Join('\n',this.Rooms[i].Patients));
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
