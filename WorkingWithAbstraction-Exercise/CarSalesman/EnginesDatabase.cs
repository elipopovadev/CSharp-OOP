using System.Collections.Generic;

namespace CarSalesman
{
    public class EnginesDatabase
    {
        public EnginesDatabase()
        {
            this.Collection = new Dictionary<string, Engine>();
        }

        private Dictionary<string, Engine> Collection { get; set; }

        public void AddEngine(Engine engine)
        {
            this.Collection[engine.Model] = engine;
        }

        public Engine FindEngine(string engineModel)
        {
            if (this.Collection.ContainsKey(engineModel))
            {
                Engine foundedEngine = this.Collection[engineModel];
                return foundedEngine;
            }

            return null;
        }
    }
}

