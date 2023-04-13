using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal interface HashtableInterface<K, V>
    {
        public bool Add(K key, V value);
        public V Get(K key);
        public bool Remove(K key);
        public void Clear();
        public bool ContainsValue(V value);
        public bool ContainsKey(K key);
        public bool IsEmpty();
        public int Size();
    }
}
