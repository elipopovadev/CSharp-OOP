using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void CallOtherPhone(string Number)
        {
            if (!Number.All(Char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {Number}");
        }

        public void BrowseInWeb(string URL)
        {
            if (URL.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {URL}!");
        }
    }
}
