using System;

namespace Telephony.Exceptions
{
   public class InvalidNumberException : Exception
    {
        private const string DEF_MSG_EXS = "Invalid Number!";
        public InvalidNumberException() : base(DEF_MSG_EXS)
        {
        }

        protected InvalidNumberException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public InvalidNumberException(string message) : base(message)
        {
        }

        public InvalidNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
