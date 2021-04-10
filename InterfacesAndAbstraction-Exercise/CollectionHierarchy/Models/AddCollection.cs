using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddCollection<T> : IAddCollection<T>
    {
        private IList<T> collection;
        public AddCollection()
        {
            this.collection = new List<T>();
        }

        public virtual int Add(T element)
        {
            int index = this.collection.Count;
            this.collection.Add(element);
            return index;
        }       
    }
}
