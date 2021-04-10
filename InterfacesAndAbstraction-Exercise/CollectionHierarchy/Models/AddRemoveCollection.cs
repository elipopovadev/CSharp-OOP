using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
    {
        private IList<T> collection;
        public AddRemoveCollection()
        {
            this.collection = new List<T>();
        }

        public override int Add(T item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public virtual T Remove()
        {
            T lastElement;
            if(this.collection.Count != 0)
            {
                lastElement = this.collection[collection.Count - 1];
                this.collection.RemoveAt(this.collection.Count - 1);
                return lastElement;
            }

            return default;            
        }
    }
}
