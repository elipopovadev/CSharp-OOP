using CollectionHierarchy.Interfaces;
using CollectionHierarchy.IO;
using CollectionHierarchy.Models;
using System;

namespace CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        private IReader reader = new ConsoleReader();
        private IWriter writer = new ConsoleWriter();

        private IAddCollection<string> addCollection;
        private IAddRemoveCollection<string> addRemoveCollection;
        private IMyList<string> myList;

        private Engine()
        {
            this.addCollection = new AddCollection<string>();
            this.addRemoveCollection = new AddRemoveCollection<string>();
            this.myList = new MyList<string>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;

        }
        public void Run()
        {
            string[] input = reader.ReadLine().Split();
            foreach (var item in input)
            {
                writer.Write($"{addCollection.Add(item)} ");            
            }

            writer.WriteLine(Environment.NewLine);

            foreach (var item in input)
            {
                writer.Write($"{addRemoveCollection.Add(item)} ");
            }

            writer.WriteLine(Environment.NewLine);

            foreach (var item in input)
            {
                writer.Write($"{myList.Add(item)} ");
            }

            writer.WriteLine(Environment.NewLine);

            int numRemoveOperations = int.Parse(reader.ReadLine());
            for (int i = 0; i < numRemoveOperations; i++)
            {
                writer.Write($"{addRemoveCollection.Remove()} ");
            }

            writer.WriteLine(Environment.NewLine);

            for (int i = 0; i < numRemoveOperations; i++)
            {
                writer.Write($"{myList.Remove()} ");
            }

            writer.WriteLine(Environment.NewLine);
        }
    }
}
