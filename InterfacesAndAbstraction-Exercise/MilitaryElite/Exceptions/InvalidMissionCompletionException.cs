using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string DEF_EXC_MSG = "Invalid completion mission exception";
        public InvalidMissionCompletionException() : base(DEF_EXC_MSG)
        {
        }

        protected InvalidMissionCompletionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public InvalidMissionCompletionException(string message) : base(message)
        {
        }

        public InvalidMissionCompletionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
