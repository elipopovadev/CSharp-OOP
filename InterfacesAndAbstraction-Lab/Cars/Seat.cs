using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; }
        public string Color { get; }

        public string Start()
        {
           return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Seat {this.Model}");
            sb.AppendLine($"{ this.Start()}");
            sb.AppendLine($"{this.Stop()}");
            return sb.ToString().TrimEnd();
        }
    }
}
