using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class HashTableArray<K, V> : HashTableInterface<K, V>
    {
        private const int _defaultCapacity = 8;
        private const float _loadFactorThreshold = 0.7f;

        private int _count = 0;
        private int _capacity = _defaultCapacity;
        private int _bucketCapacity = _defaultCapacity / 2;

        private KeyValuePair<K, V>[,] _hashTable; 
        private bool[,] _isOccupied;
        

        public HashTableArray() 
        {
            _hashTable = new KeyValuePair<K, V>[_capacity, _capacity]; // I am confusion, men jag tror att det blir såhär om man ska använda arrays som buckets?
            _isOccupied = new bool[_capacity, _capacity];
        }

        public bool Add(K key, V value)
        {
            throw new NotImplementedException();

            // WIP
            // Check load factor and resize if necessary
            if (_count / _capacity >= _loadFactorThreshold) 
            {
                // (If necessary) Determine new size if it can be less than double the previous size
                Resize(_capacity * 2);
            }

            // Calculate index using hash function
            int HashIndex = key.GetHashCode() % _capacity;

            for (int i = 0; i < _bucketCapacity; i++) 
            {
                KeyValuePair<K, V> pair = _hashTable[i, HashIndex];

                if (pair != null) // If index isn't empty
                {
                    K indexKey = pair.GetKey();

                    if (indexKey.Equals(key))  // If the keys match
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
                    KeyValuePair<K, V> newPair = new KeyValuePair<K, V>(key, value);
                    _hashTable[i, HashIndex] = newPair;
                    _isOccupied[i, HashIndex] = true;
                    // Increment count
                    _count++;
                    return true;
                }
            }
            
        }

        public void Clear()
        {
            throw new NotImplementedException();
            // WIP
            _hashTable = new KeyValuePair<K, V>[_defaultCapacity, _defaultCapacity];
            _isOccupied = new bool[_defaultCapacity, _defaultCapacity];
            _capacity = _defaultCapacity;
            _count = 0;
        }

        public bool ContainsKey(K key)
        {
            throw new NotImplementedException();
            int HashIndex;

            if (key != null)
            {
                HashIndex = key.GetHashCode() % _capacity;
            }
            else
            {
                throw new NullKeyException();
            }

            for (int i = 0; i < _bucketCapacity; i++) 
            {
                KeyValuePair<K, V> pair = _hashTable[i, HashIndex];  // Reminder: [row, column]
                K indexKey;

                if (pair != null) indexKey = pair.GetKey();

                if (indexKey.Equals(key)) return true;

            }

            return false;
        }

        public bool ContainsValue(V value)
        {
            // Det går säkert att göra den här funktionen mer effektiv
            throw new NotImplementedException();
            for (int i = 0; i < Size(); i++)
            {
                for (int j = 0; j < _bucketCapacity; j++) 
                {
                    KeyValuePair<K, V> pair = _hashTable[j, i];   // Reminder: [row, column]
                    V indexValue;

                    if (pair != null) indexValue = Get(pair.GetKey());

                    if (indexValue.Equals(value)) return true;

                }
               
            }

            return false;
        }

        public V? Get(K key)
        {
            int HashIndex;

            if (key != null)
            {
                HashIndex = key.GetHashCode() % _capacity;
            }
            else
            {
                throw new NullKeyException();
            }
            
            for (int i = 0; i < _bucketCapacity; i++)
            {
                KeyValuePair<K, V> pair = _hashTable[i, HashIndex];   // Reminder: [row, column]

                if (pair != null)
                {
                    K indexKey = pair.GetKey();
                    if (indexKey != null && indexKey.Equals(key)) return pair.GetValue();
                }
            }

            return default;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool Remove(K key)
        {
            throw new NotImplementedException();
            int HashIndex;

            if (key != null)
            {
                HashIndex = key.GetHashCode() % _capacity;
            }
            else
            {
                throw new NullKeyException();
            }

            for (int i = 0; i < _bucketCapacity; i++)
            {
                KeyValuePair<K, V> pair = _hashTable[i, HashIndex];   // Reminder: [row, column]

                if (pair != null)
                {
                    K indexKey = pair.GetKey();
                    if (indexKey != null && indexKey.Equals(key))
                    {
                        _hashTable[i, HashIndex] = null;
                        _isOccupied[i, HashIndex] = false;
                        _count--;
                        return true;
                    }
                }
            }

            return false;
        }

        public int Size()
        {
            return _count;
        }

        public void Resize(int newCapacity)
        {
            throw new NotImplementedException();
        }
    }
}
