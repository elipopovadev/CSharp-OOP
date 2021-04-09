using System;
using System.Linq;
using Telephony.Exceptions;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string CallOtherPhone(string Number)
        {
            if (!Number.All(ch => char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {Number}";
        }

        public string BrowseInWeb(string URL)
        {
            if (URL.Any(ch => char.IsDigit(ch)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {URL}!";
        }
    }
}
