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

            // WIP
            // Check load factor and resize if necessary
            if (_count / _capacity >= _loadFactorThreshold) 
            { 
                // Implement resize code
            }

            // Calculate index using hash function
            int hash = key.GetHashCode() % _capacity;
            KeyValuePair<K,V> pair = _hashTable[hash];

            // If index isn't empty
            if (pair != null) 
            { 
                // If the keys match
                if (pair.GetKey().Equals(key))
                {
                    // Set the value of the pair to the new passed in value.
                    pair.SetValue(value);
                    return true;
                }
                else // If they don't match, then perform conflict resolution
                {
                    // Implement strategy to combat conflicts
                    return false;
                }
            }
            else // If index is empty
            {
                // Add Value
                KeyValuePair<K,V> newPair = new KeyValuePair<K,V>(key, value);
                _hashTable[hash] = newPair;
                _isOccupied[hash] = true;
                // Increment count
                _count++;
                return true;
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
            // WIP
            _hashTable = new KeyValuePair<K, V>[_defaultCapacity];
            _isOccupied = new bool[_defaultCapacity];
            _capacity = _defaultCapacity;
            _count = 0;
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
            int HashIndex = key.GetHashCode() % _capacity;
            KeyValuePair<K, V> pair = _hashTable[HashIndex];
            if (pair != null) 
            { 
                if (pair.GetKey().Equals(key))
                {
                    return pair.GetValue();
                }
            }
            return default(V);
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
