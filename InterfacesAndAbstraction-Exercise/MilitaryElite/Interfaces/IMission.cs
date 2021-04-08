using MilitaryElite.Enums;

namespace MilitaryElite
{
   public interface IMission
    {
        public string CodeName { get; }
        public State State { get; }
        public void CompleteMission();
    }
}
