using Vehicles.Core;
using Vehicles.IO;

namespace Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();           
            IEngine engine = new Engine(reader,writer);
            engine.Run();
        }
    }
}
