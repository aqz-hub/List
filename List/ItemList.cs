using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ItemList<T> : IEnumerable<T>, IList<T>
    {
        public Item<T> Head { get; set; }
        public Item<T> Tail { get; set; }
        private int count;
        public int Count
        {
            get { return count; }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerable<T> BackEnumerator()
        {
            Item<T> current = Tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

        public bool Contains(T item)
        {
            var current = Head;
            while(current != null)
            {
                if(current.Data.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void AddAfter(Item<T> newItem, Item<T> item)
        {
            if(Equals(item, Head))
            {
                AddFirst(newItem.Data);
            }
            else if(Equals(item, Tail))
            {
                AddLast(newItem.Data);
            }
            else
            {
                var newItemNext = item.Next;
                item.Next.Previous = newItem;
                item.Next = newItem;
                newItem.Previous = item;
                newItem.Next = newItemNext;
                count++;
            }
        }

        public void AddBefore(Item<T> newItem, Item<T> item)
        {
            if (Equals(item, Head))
            {
                AddFirst(newItem.Data);
            }
            else if (Equals(item, Tail))
            {
                AddLast(newItem.Data);
            }
            else
            {
                var newItemPrevious = item.Previous;
                item.Previous.Next = newItem;
                item.Previous = newItem;
                newItem.Next = item;
                newItem.Previous = newItemPrevious;
                count++;
            }
        }

        public void AddFirst(T item)
        {
            Item<T> node = new Item<T>(item);
            Item<T> temp = Head;
            node.Next = temp;
            Head = node;
            if (count == 0)
                Tail = Head;
            else
                temp.Previous = node;
            count++;
        }

        public void AddLast(T item)
        {
            Item<T> node = new Item<T>(item);
            Item<T> temp = Tail;
            node.Previous = temp;
            Tail = node;
            if (count == 0)
                Head = Tail;
            else
                temp.Next = node;
            count++;
        }

        public void RemoveHead()
        {
            if(count > 1)
            {
                var next = Head.Next;
                next.Previous = null;
                Head = next;
                count--;
            }
            else
            {
                Head = null;
                Tail = null;
                count = 0;
            }
        }

        public void RemoveTail()
        {
            if(count > 1)
            {
                var previous = Tail.Previous;
                previous.Next = null;
                Tail = previous;
                count--;
            }
            else
            {
                Head = null;
                Tail = null;
                count = 0;
            }
        }

        public void Remove(T item)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    Tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    Head = current.Next;
                }
                count--;
            }
        }
    }
}
