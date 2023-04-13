using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class HashtableArray<K, V> : HashtableInterface<K, V>
    {
        private const float LoadFactorThreshhold = 0.7f;

        private KeyValuePair<K, V>[] _hashtable;

        private int _count = 0;
        private int _capacity = 8;
        private bool[] _isOccupied;


        public HashtableArray() 
        {
            _hashtable = new KeyValuePair<K, V>[_capacity];
            _isOccupied = new bool[_capacity];
        }

        public bool Add(K key, V value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(K key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(V value)
        {
            throw new NotImplementedException();
        }

        public V Get(K key)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public bool Remove(K key)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}
