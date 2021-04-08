using MilitaryElite.Enums;
using MilitaryElite.Exceptions;
using System;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParse(state);

        }
        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
           if(this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }

            this.State = State.Finished;
        }

        private State TryParse(string stateStr)
        {
            bool parsed = Enum.TryParse(stateStr, out State state);
            if (!parsed)
            {
                throw new InvalidMissionStateException();
            }

            return state;
        }
    }
}
