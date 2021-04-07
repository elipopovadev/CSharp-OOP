namespace MilitaryElite
{
    public class Repair
    {
        public Repair(string part, int hours)
        {
            this.PartName = part;
            this.HoursWorked = hours;
        }

        string PartName { get; }
        int HoursWorked { get; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: { this.HoursWorked}";
        }
    }
}
