using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLab1
{
    internal interface ListInterface<T>
    {
        // Specified the datatypes and data for all operations
        public void Add(T data);
        public void Add(T data, int index);
        public void Remove(int index);
        public void Clear();
        public T? GetValueAtIndex(int index);
        public bool IsEmpty();
        public int Length();
    }
}
