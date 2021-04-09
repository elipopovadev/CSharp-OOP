using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string DEF_EXC_MSG = "Invalid mission state!";
        public InvalidMissionStateException() : base(DEF_EXC_MSG)
        {
        }

        protected InvalidMissionStateException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public InvalidMissionStateException(string message) : base(message)
        {
        }

        public InvalidMissionStateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
