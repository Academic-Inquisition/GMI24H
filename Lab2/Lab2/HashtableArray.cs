using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class HashTableArray<K, V> : HashTableInterface<K, V>
    {
        private const int _defaultCapacity = 8;
        private const int _defaultBucketCapacity = _defaultCapacity / 2;
        private const float _loadFactorThreshold = 0.7f;

        private int _totalCount;
        private int _count;
        private int[] _bucketCount;
        private int _capacity = _defaultCapacity;
        private int _bucketCapacity = _defaultBucketCapacity;

        private KeyValuePair<K, V>[,] _hashTable; 
        private bool[,] _isOccupied;
        

        public HashTableArray() 
        {
            _hashTable = new KeyValuePair<K, V>[_bucketCapacity, _capacity]; // I am confusion, men jag tror att det blir såhär om man ska använda arrays som buckets?
            _isOccupied = new bool[_bucketCapacity, _capacity];
            _count = 0;
            _bucketCount = new int[_capacity];
        }

        public bool Add(K key, V value)
        {
            // WIP
            // Check load factor and resize if necessary
            if (_count / _capacity >= _loadFactorThreshold) 
            {
                // (If necessary) Determine new size if it can be less than double the previous size
                Resize(_capacity * 2);
            }

            for (int i = 0; i < _capacity; i++)
            {
                if (_bucketCount[i] / _bucketCapacity >= _loadFactorThreshold)
                {
                    Resize(_capacity * 2);
                }
            }

            // Add function to check bucket load factor (just in case)

            // Calculate index using hash function
            int HashIndex = Math.Abs(Program.HashFunction(key.ToString(), _capacity));

            for (int i = 0; i < _bucketCapacity; i++) 
            {
                KeyValuePair<K, V> pair = _hashTable[i, HashIndex];

                if (pair != null) // If index isn't empty
                {
                    K indexKey = pair.GetKey();

                    if (indexKey != null && indexKey.Equals(key))  // If the keys match
                    {
                        // Set the value of the pair to the new passed in value.
                        pair.SetValue(value);
                        return true;
                    }
                }
                else // If index is empty
                {
                    // Add Value
                    KeyValuePair<K, V> newPair = new KeyValuePair<K, V>(key, value);
                    _hashTable[i, HashIndex] = newPair;
                    _isOccupied[i, HashIndex] = true;
                    // Increment count
                    _totalCount++;
                    if (i == 0)
                    {
                        _count++;
                        _bucketCount[HashIndex]++;
                    }
                    else
                    {
                        _bucketCount[HashIndex]++;
                    }

                    return true;
                }
            }
            
            return false;
        }

        public void Clear()
        {
            _bucketCapacity = _defaultBucketCapacity;
            _hashTable = new KeyValuePair<K, V>[_bucketCapacity, _defaultCapacity];
            _isOccupied = new bool[_bucketCapacity, _defaultCapacity];
            _capacity = _defaultCapacity;
            _count = 0;
        }

        public bool ContainsKey(K key)
        {
            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(Program.HashFunction(key.ToString(), _capacity));
            }
            else
            {
                throw new NullKeyException();
            }

            for (int i = 0; i < _bucketCapacity; i++) 
            {
                KeyValuePair<K, V> pair = _hashTable[i, HashIndex];  // Reminder: [row, column]
                K? indexKey = default;

                if (pair != null) indexKey = pair.GetKey();
                
                if (indexKey != null && indexKey.Equals(key)) return true;
            }

            return false;
        }

        public bool ContainsValue(V value)
        {
            // Det går säkert att göra den här funktionen mer effektiv
            for (int i = 0; i < _capacity; i++)
            {
                for (int j = 0; j < _bucketCapacity; j++) 
                {
                    KeyValuePair<K, V> pair = _hashTable[j, i];   // Reminder: [row, column]
                    V? indexValue;

                    if (pair != null)
                    {
                        indexValue = Get(pair.GetKey());
                        if (indexValue != null && indexValue.Equals(value)) return true;
                    }

                }
               
            }

            return false;
        }

        public V? Get(K key)
        {
            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(Program.HashFunction(key.ToString(), _capacity));
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
            int HashIndex = Math.Abs(Program.HashFunction(key.ToString(), _capacity));

            if (_bucketCount[HashIndex] == 0) return false;

            for (int i = 0; i < _bucketCapacity; i++)
            {
                KeyValuePair<K, V> pair = _hashTable[i, HashIndex];   // Reminder: [row, column]

                if (pair != null)
                {
                    K indexKey = pair.GetKey();
                    if (indexKey != null && indexKey.Equals(key))
                    {
                        K? defaultKey = default;
                        V? defaultValue = default;

                        KeyValuePair<K, V> defaultPair = new KeyValuePair<K, V>(defaultKey, defaultValue);
                        _hashTable[i, HashIndex] = defaultPair;
                        _isOccupied[i, HashIndex] = false;

                        _totalCount--;
                        if (i == 0)
                        {
                            _count--;
                            _bucketCount[HashIndex]--;
                        }
                        else
                        {
                            _bucketCount[HashIndex]--;
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public int TotalCount()
        {
            return _totalCount;
        }

        public int Count()
        {
            return _count;
        }

        public int BucketCount(int index)
        {
            return _bucketCount[index];
        }

        public int[] Capacity()
        {
            return new int[] { _capacity, _bucketCapacity };
        }

        public void Resize(int newCapacity)
        {
            KeyValuePair<K, V>[,] temp = new KeyValuePair<K, V>[newCapacity / 2, newCapacity];

            for (int i = 0; i < _capacity; i++)
            {
                for (int j = 0; j < _bucketCapacity; j++)
                {
                    temp[j, i] = _hashTable[j, i];
                }
            }

            _hashTable = temp;
        }
    }
}
