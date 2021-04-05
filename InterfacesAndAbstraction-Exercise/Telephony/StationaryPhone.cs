using System;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void CallOtherPhone(string Number)
        {
            if (!Number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Dialing... {Number}");
        }
    }
}
