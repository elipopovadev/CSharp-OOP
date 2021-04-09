using System;

namespace Telephony.Exceptions
{
   public class InvalidURLException : Exception
    {
        private const string DEF_MSG_EXS = "Invalid URL!";
        public InvalidURLException() : base(DEF_MSG_EXS)
        {
        }

        public InvalidURLException(string message) : base(message)
        {
        }

        public InvalidURLException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
