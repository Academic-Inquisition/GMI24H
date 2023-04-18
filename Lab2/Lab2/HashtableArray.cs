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
        private int _capacity = _defaultCapacity;
        

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
                // (If necessary) Determine new size if it can be less than double the previous size
                Resize(_capacity * 2);
            }

            // Calculate index using hash function
            int hash = key.GetHashCode() % _capacity;
            KeyValuePair<K,V> pair = _hashTable[hash];

            // If index isn't empty
            if (pair != null) 
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
            for (int i = 0; i <= Size(); i++)
            {
                KeyValuePair<K, V> pair = _hashTable[i];
                K indexKey = default;

                if (pair != null) indexKey = pair.GetKey();
                
                if (indexKey.Equals(key))
                {
                    return true;
                }
                else
                {
                    // Lägg till kod för att kolla chaining
                }

                return false;
            }
        }

        public bool ContainsValue(V value)
        {
            throw new NotImplementedException();
            for (int i = 0; i <= Size(); i++)
            {
                KeyValuePair<K, V> pair = _hashTable[i];
                V indexValue = default;

                if (pair != null) indexValue = Get(pair.GetKey());
               
                if (indexValue.Equals(value))
                {
                    return true;
                }
                else
                {
                    // Lägg till kod för att kolla chaining
                }

                return false;
            }
        }

        public V? Get(K key)
        {
            int HashIndex = -1;

            if (key != null)
            {
                HashIndex = key.GetHashCode() % _capacity;
            }
            else
            {
                // Throw some kind of null key error
            }
            
            KeyValuePair<K, V> pair = _hashTable[HashIndex];

            if (pair != null) 
            {
                K indexKey = pair.GetKey();
                if (indexKey != null && indexKey.Equals(key)) return pair.GetValue();
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
