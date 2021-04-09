using Telephony.Exceptions;
using Telephony.IO;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader; // private reader;
        private IWriter writer; // private writer

        private StationaryPhone stationaryPhone;
        private Smartphone smartphone;
        private Engine() // private constructor 
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) // public constructor with reader and writer
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split(" ");
            string[] allSites = reader.ReadLine().Split(" ");

            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        writer.WriteLine(smartphone.CallOtherPhone(number));
                    }

                    else if (number.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.CallOtherPhone(number));
                    }
                }

                catch (InvalidNumberException exception)
                {
                    writer.WriteLine(exception.Message);
                }
            }

            foreach (var URL in allSites)
            {
                try
                {
                    writer.WriteLine(smartphone.BrowseInWeb(URL));
                }

                catch (InvalidURLException exception)
                {
                    writer.WriteLine(exception.Message);
                }
            }
        }
    }
}

