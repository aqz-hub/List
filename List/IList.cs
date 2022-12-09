using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public interface IList<T>
    {
        void AddAfter(Item<T> newItem, Item<T> item);
        void AddBefore(Item<T> newItem, Item<T> item);
        void AddFirst(T item);
        void AddLast(T item);
        void RemoveHead();
        void RemoveTail();
        void Remove(T item);
    }
}
