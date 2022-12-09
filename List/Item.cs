using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class Item<T>
    {
        public Item(T _data)
        {
            Data = _data;
        }
        public T Data { get; set; }
        public Item<T> Next { get; set; }
        public Item<T> Previous { get; set; }
    }
}
