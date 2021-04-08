using MilitaryElite.IO.Contracts;
using System;

namespace MilitaryElite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
