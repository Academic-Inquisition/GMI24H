namespace Lab2
{
    public class HashTableArray<K, V> : HashTableInterface<K, V>
    {
        private const int _defaultCapacity = 8;
        private const float _loadFactorThreshold = 0.7f;

        private int _capacity;
        private int _count;

        private KeyValuePair<K, V>[] _hashTable;
        private bool[] _isOccupied;

        public HashTableArray()
        {
            _capacity = _defaultCapacity;
            _count = 0;
            _hashTable = new KeyValuePair<K, V>[_capacity];
            _isOccupied = new bool[_capacity];
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

            // Calculate index using hash function
            int HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity));


            while (_hashTable[HashIndex] != null)
            {
                KeyValuePair<K, V> pair = _hashTable[HashIndex];
                if (pair.GetKey().Equals(key))
                {
                    _hashTable[HashIndex] = new KeyValuePair<K, V>(key, value);
                    return true;
                }
                if (HashIndex <= 1)
                {
                    for (int i = 0; i < _capacity; i++)
                    {
                        if (_hashTable[i] == null) { 
                            HashIndex = i;
                            break;
                        }
                    }
                    break;
                }
                HashIndex = (int)(Math.Pow(Convert.ToDouble(HashIndex), 2) % _capacity);
            }
            _hashTable[HashIndex] = new KeyValuePair<K, V>(key, value);
            _isOccupied[HashIndex] = true;
            _count++;
            return true;
        }

        public void Clear()
        {
            _capacity = _defaultCapacity;
            _count = 0;
            _hashTable = new KeyValuePair<K, V>[_capacity]; 
            _isOccupied = new bool[_capacity];
        }

        public bool ContainsKey(K key)
        {
            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity));
            }
            else
            {
                throw new NullKeyException();
            }

            for (int i = 0; i < _capacity; i++)
            {
                KeyValuePair<K, V> pair = _hashTable[i];
                if (pair != null && pair.GetKey().Equals(key)) return true;
            }
            return false;
        }

        public bool ContainsValue(V value)
        {
            // Det går säkert att göra den här funktionen mer effektiv
            for (int i = 0; i < _capacity; i++)
            {
                KeyValuePair<K, V> pair = _hashTable[i];
                if (pair != null && pair.GetValue().Equals(value)) return true;
            }
            return false;
        }

        public V? Get(K key)
        {
            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity));
            }
            else
            {
                throw new NullKeyException();
            }

            for (int i = 0; i < _capacity; i++)
            {
                KeyValuePair<K,V> pair = _hashTable[i];
                if (pair != null && pair.GetKey().Equals(key)) return pair.GetValue();
            }

            return default;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool Remove(K key)
        {
            for (int i = 0; i < _capacity; i++)
            {
                KeyValuePair<K, V> pair = _hashTable[i];
                if (pair != null && pair.GetKey().Equals(key))
                {
                    _hashTable[i] = null;
                    _isOccupied[i] = false;
                    _count--;
                    return true;
                }
            }
            return false;
        }

        public int TotalCount()
        {
            return _count;
        }

        public int Count()
        {
            return _count;
        }

        public int BucketCount(int index)
        {
            return _count;
        }

        public int Capacity()
        {
            return _capacity;
        }

        public void Resize(int newCapacity)
        {
            KeyValuePair<K, V>[] hashTableTemp = new KeyValuePair<K, V>[newCapacity];
            bool[] isOccupiedTemp = new bool[newCapacity];

            for (int i = 0; i < _capacity; i++)
            {
                hashTableTemp[i] = _hashTable[i];
                isOccupiedTemp[i] = _isOccupied[i];
            }

            _hashTable = hashTableTemp;
            _isOccupied = isOccupiedTemp;
            _capacity = newCapacity;
        }

        public static int HashFunction(string key, int capacity)
        {
            int hash = 5381;
            foreach (char c in key)
            {
                hash = (hash * 33 + c) % capacity;
            }

            return hash;
        }
    }
}
