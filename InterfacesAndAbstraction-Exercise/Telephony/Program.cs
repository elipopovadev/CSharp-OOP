using System;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ");
            string[] allSites = Console.ReadLine().Split(" ");

            foreach ( var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        ICallable smartphone = new Smartphone();
                        smartphone.CallOtherPhone(number);
                    }

                    else if (number.Length == 7)
                    {
                        ICallable stationaryPhone = new StationaryPhone();
                        stationaryPhone.CallOtherPhone(number);
                    }

                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            foreach ( var URL in allSites)
            {
                try
                {

                    IBrowsable smartphone = new Smartphone();
                    smartphone.BrowseInWeb(URL);
                }

                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }            
        }
    }
}
