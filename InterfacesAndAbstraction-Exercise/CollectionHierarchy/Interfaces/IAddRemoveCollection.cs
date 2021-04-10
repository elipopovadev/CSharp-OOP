namespace CollectionHierarchy.Interfaces
{
   public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        public T Remove();
    }
}
