namespace CollectionHierarchy.Interfaces
{
   public interface IMyList<T> : IAddRemoveCollection<T>
    {
        public int Used { get;}
    }
}
