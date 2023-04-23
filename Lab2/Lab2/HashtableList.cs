namespace Lab2
{
    public class HashTableList<K, V> : HashTableInterface<K, V>
    {
        private const int _defaultCapacity = 8;
        private const float _loadFactorThreshold = 0.7f;

        private int _totalCount;
        private int _count;
        private int _capacity = _defaultCapacity;

        private List<KeyValuePair<K, V>>[] _hashTable;
        private List<bool>[] _isOccupied;


        public HashTableList()
        {
            _hashTable = new List<KeyValuePair<K, V>>[_capacity]; //
            for (int i = 0; i < _capacity; i++) _hashTable[i] = new List<KeyValuePair<K, V>>();
            _isOccupied = new List<bool>[_capacity];
            for (int i = 0; i < _capacity; i++) _isOccupied[i] = new List<bool>();
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
            int HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity));

            List<KeyValuePair<K, V>> bucket = _hashTable[HashIndex];

            // Om det är första värdet som läggs till i denna bucket
            if (bucket.Count() == 0)
            {
                // Add Value
                KeyValuePair<K, V> newPair = new KeyValuePair<K, V>(key, value);
                bucket.Add(newPair);
                _isOccupied[HashIndex].Add(true);
                // Increment count
                _totalCount++;
                _count++;
                return true;
            }

            // Loopa över och kolla om man ska uppdatera värdet

            List<KeyValuePair<K, V>> newBucket;

            while (_hashTable[HashIndex] != null)
            {
                newBucket = _hashTable[HashIndex];
                if (newBucket.Count == 0) break; 
                KeyValuePair<K, V> pair = newBucket[0];
                if (pair != null && pair.GetKey().Equals(key))
                {
                    newBucket[0] = new KeyValuePair<K, V>(key, value);
                    return true;
                }
                if (HashIndex <= 1)
                {
                    for (int i = 0; i < _capacity; i++)
                    {
                        if (_hashTable[i] == null)
                        {
                            HashIndex = i;
                            break;
                        }
                    }
                    break;
                }
                HashIndex = (int)(Math.Pow(Convert.ToDouble(HashIndex), 2) % _capacity);
            }

            newBucket = _hashTable[HashIndex];
            KeyValuePair<K, V> np2 = new KeyValuePair<K, V>(key, value);
            newBucket.Add(np2);
            _totalCount++;
            _count++;
            return true;
        }

        public void Clear()
        {
            _capacity = _defaultCapacity;
            _totalCount = 0;
            _count = 0;

            _hashTable = new List<KeyValuePair<K, V>>[_capacity];
            _isOccupied = new List<bool>[_capacity];
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

            List<KeyValuePair<K, V>> bucket = _hashTable[HashIndex];

            for (int i = 0; i < bucket.Count(); i++)
            {
                KeyValuePair<K, V> pair = bucket[i];  // Reminder: [row, column]
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
                List<KeyValuePair<K, V>> bucket = _hashTable[i];
                for (int j = 0; j < bucket.Count(); j++)
                {
                    KeyValuePair<K, V> pair = bucket[j];   // Reminder: [row, column]
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
                HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity));
            }
            else
            {
                throw new NullKeyException();
            }

            List<KeyValuePair<K, V>> bucket = _hashTable[HashIndex];

            for (int i = 0; i < bucket.Count(); i++)
            {
                KeyValuePair<K, V> pair = bucket[i];   // Reminder: [row, column]

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
                HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity));
            }
            else
            {
                throw new NullKeyException();
            }

            List<KeyValuePair<K, V>> bucket = _hashTable[HashIndex];

            if (bucket.Count() == 0) return false;

            for (int i = 0; i < bucket.Count(); i++)
            {
                KeyValuePair<K, V> pair = bucket[i];   // Reminder: [row, column]

                if (pair != null)
                {
                    K indexKey = pair.GetKey();
                    if (indexKey != null && indexKey.Equals(key))
                    {
                        bucket[i] = null;
                        _isOccupied[HashIndex][i] = false;

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

        public int Capacity()
        {
            return _capacity;
        }

        public void Resize(int newCapacity)
        {
            List<KeyValuePair<K, V>>[] hashTableTemp = new List<KeyValuePair<K, V>>[newCapacity];
            for (int i = 0; i < newCapacity; i++) hashTableTemp[i] = new List<KeyValuePair<K, V>>();
            List<bool>[] isOccupiedTemp = new List<bool>[newCapacity];
            for (int i = 0; i < newCapacity; i++) isOccupiedTemp[i] = new List<bool>();

            for (int i = 0; i < _capacity; i++)
            {
                List<KeyValuePair<K, V>> bucket = _hashTable[i];
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

        private int HashFunction(string input, int capacity)
        {
            int total = 0;
            char[] c;
            c = input.ToCharArray();

            // Summing up all the ASCII values
            // of each alphabet in the string
            for (int k = 0; k <= c.GetUpperBound(0); k++)
                total += (int)c[k];

            return total % capacity;
        }
    }
}
