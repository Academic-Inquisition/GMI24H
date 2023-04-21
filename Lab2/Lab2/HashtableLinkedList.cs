using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class HashTableLinkedList<K, V> : HashTableInterface<K, V>
    {
        private const int _defaultCapacity = 8;
        private const float _loadFactorThreshold = 0.7f;

        private int _totalCount;
        private int _count;
        private int _capacity = _defaultCapacity;

        private LinkedList<KeyValuePair<K, V>>[] _hashTable;
        private LinkedList<bool>[] _isOccupied;


        public HashTableLinkedList()
        {
            _hashTable = new LinkedList<KeyValuePair<K, V>>[_capacity]; // 
            for (int i = 0; i < _capacity; i++) _hashTable[i] = new LinkedList<KeyValuePair<K, V>>();
            _isOccupied = new LinkedList<bool>[_capacity];
            for (int i = 0; i < _capacity; i++) _isOccupied[i] = new LinkedList<bool>();
            _count = 0;
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

            // Add function to check bucket load factor (just in case)

            // Calculate index using hash function
            int HashIndex = Math.Abs(key.GetHashCode() % _capacity);

            LinkedList<KeyValuePair<K, V>> bucket = _hashTable[HashIndex];

            // Om det är första värdet som läggs till i denna bucket
            if (bucket.Count() == 0)
            {
                // Add Value
                KeyValuePair<K, V> newPair = new KeyValuePair<K, V>(key, value);
                bucket.AddLast(newPair);
                _isOccupied[HashIndex].AddLast(true);
                // Increment count
                _totalCount++;
                _count++;
                return true;
            }

            // Loopa över och kolla om man ska uppdatera värdet
            for (int i = 0; i < bucket.Count(); i++)
            {
                KeyValuePair<K, V> pair = bucket.ElementAt(i);

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
            }

            KeyValuePair<K, V> np = new KeyValuePair<K, V>(key, value);
            bucket.AddLast(np);
            _isOccupied[HashIndex].AddLast(true);
            // Increment count
            _totalCount++;
            _count++;
            return true;
        }

        public void Clear()
        {
            _capacity = _defaultCapacity;
            _totalCount = 0;
            _count = 0;

            _hashTable = new LinkedList<KeyValuePair<K, V>>[_capacity]; // I am confusion, men jag tror att det blir såhär om man ska använda arrays som buckets?
            _isOccupied = new LinkedList<bool>[_capacity];
        }

        public bool ContainsKey(K key)
        {
            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(key.GetHashCode() % _capacity);
            }
            else
            {
                throw new NullKeyException();
            }

            LinkedList<KeyValuePair<K, V>> bucket = _hashTable[HashIndex];

            for (int i = 0; i < bucket.Count(); i++)
            {
                KeyValuePair<K, V> pair = bucket.ElementAt(i);  // Reminder: [row, column]
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
                LinkedList<KeyValuePair<K, V>> bucket = _hashTable[i];
                for (int j = 0; j < bucket.Count(); j++)
                {
                    KeyValuePair<K, V> pair = bucket.ElementAt(i);   // Reminder: [row, column]
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
                HashIndex = Math.Abs(key.GetHashCode() % _capacity);
            }
            else
            {
                throw new NullKeyException();
            }

            LinkedList<KeyValuePair<K, V>> bucket = _hashTable[HashIndex];

            for (int i = 0; i < bucket.Count(); i++)
            {
                KeyValuePair<K, V> pair = bucket.ElementAt(i);   // Reminder: [row, column]

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
            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(key.GetHashCode() % _capacity);
            }
            else
            {
                throw new NullKeyException();
            }

            LinkedList<KeyValuePair<K, V>> bucket = _hashTable[HashIndex];

            if (bucket.Count() == 0) return false;

            for (int i = 0; i < bucket.Count(); i++)
            {
                KeyValuePair<K, V> pair = bucket.ElementAt(i);   // Reminder: [row, column]

                if (pair != null)
                {
                    K indexKey = pair.GetKey();
                    
                    if (indexKey != null && indexKey.Equals(key))
                    {
                        K? defaultKey = default;
                        V? defaultValue = default;

                        
                        KeyValuePair<K, V> defaultPair = new KeyValuePair<K, V>(defaultKey, defaultValue);
                        V test = pair.GetValue();
                        KeyValuePair<K, V> test2 = new KeyValuePair<K,V >(indexKey,test);
                        test2  = defaultPair;
                        bool temp = _isOccupied[HashIndex].ElementAt(i);
                        temp = false;

                        _totalCount--;
                        if (i == 0)
                        {
                            _count--;
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
            return _hashTable[index].Count();
        }

        public int[] Capacity()
        {
            return new int[] { _capacity, -1 };
        }

        public void Resize(int newCapacity)
        {
            LinkedList<KeyValuePair<K, V>>[] hashTableTemp = new LinkedList<KeyValuePair<K, V>>[newCapacity]; // I am confusion, men jag tror att det blir såhär om man ska använda arrays som buckets?
            for (int i = 0; i < newCapacity; i++) hashTableTemp[i] = new LinkedList<KeyValuePair<K, V>>();
            LinkedList<bool>[] isOccupiedTemp = new LinkedList<bool>[newCapacity];
            for (int i = 0; i < newCapacity; i++) isOccupiedTemp[i] = new LinkedList<bool>();

            for (int i = 0; i < _capacity; i++)
            {
                LinkedList<KeyValuePair<K, V>> bucket = _hashTable[i];
                for (int j = 0; j < bucket.Count(); j++)
                {
                    hashTableTemp[i] = _hashTable[i];
                    isOccupiedTemp[i] = _isOccupied[i];
                }
            }

            _hashTable = hashTableTemp;
            _isOccupied = isOccupiedTemp;
            _capacity = newCapacity;
        }
    }
}
