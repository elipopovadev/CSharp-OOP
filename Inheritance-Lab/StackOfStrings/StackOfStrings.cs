using System.Collections.Generic;

namespace CustomStack
{
    class StackOfStrings<T> : Stack<T>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }

            return false;
        }

        public void AddRange(IEnumerable<T> strings)
        {
            foreach (var item in strings)
            {
                this.Push(item);
            }
        }
    }
}

