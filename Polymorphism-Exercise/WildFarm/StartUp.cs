using WildFarm.Core;
using WildFarm.IO;

namespace WildFarm
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();       
        }
    }
}
