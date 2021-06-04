using System.Reflection;
using System.Linq;
using System;

namespace CodingTracker
{
    public class Tracker
    {
        public void PrintMethodsByAuthor(string author)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes(); // types
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Instance
                                             | BindingFlags.Public | BindingFlags.NonPublic); // methods

                foreach (var method in methods)
                {
                    var atributes = method.GetCustomAttributes<AuthorAttribute>(); // atributes
                    if (atributes.Any(m => m.Name == author))
                    {
                        Console.WriteLine(method);
                    }
                }
            }
        }
    }
}
