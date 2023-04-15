using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class HashTableArray<K, V> : HashTableInterface<K, V>
    {
        private const int _defaultCapacity = 8;
        private const float _loadFactorThreshold = 0.7f;

        private KeyValuePair<K, V>[] _hashTable;
        private bool[] _isOccupied;

        private int _count = 0;
        private int _capacity = 8;
        
        public HashTableArray() 
        {
            _hashTable = new KeyValuePair<K, V>[_capacity];
            _isOccupied = new bool[_capacity];
        }

        public bool Add(K key, V value)
        {
            throw new NotImplementedException();
            // Check load factor and resize if necessary

            // Calculate index using hash function

            // If index is empty, add value, otherwise create chaining

            // Increment count
        }

        public void Clear()
        {
            throw new NotImplementedException();
            // Set the _hashTable to a new array of KVPairs 
            //      _hashTable = new KeyValuePair<K,V>[_defaultCapacity]
            //      _isOccupied = new bool[_defaultCapacity]
            //      _capacity = _defaultCapacity
            //      _count = 0
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
            return _count == 0;
        }

        public bool Remove(K key)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            return _count;
        }
    }
}
