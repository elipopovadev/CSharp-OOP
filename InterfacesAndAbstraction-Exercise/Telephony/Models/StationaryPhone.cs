using System;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string CallOtherPhone(string Number)
        {
            if (!Number.All(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {Number}";
        }
    }
}
