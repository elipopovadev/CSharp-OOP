using System.Linq;
using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        private IList<T> collection;
        public MyList()
        {
            this.collection = new List<T>();
        }

        public int Used => this.collection.Count;

        public override int Add(T item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public override T Remove()
        {
            if (this.collection.Count != 0)
            {
                T firstElement = this.collection.First();
                this.collection.RemoveAt(0);
                return firstElement;
            }

            return default;           
        }
    }
}
