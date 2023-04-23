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
            if (_count / _capacity >= _loadFactorThreshold) // Check load factor and resize if necessary
            {
                Resize(_capacity * 2);
            }

            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity)); // Calculate index using hash function
            }
            else
            {
                throw new NullKeyException(); // Throw an exception if the input key is null
            }

            while (_hashTable[HashIndex] != null) // If there exists a value at this position
            {
                KeyValuePair<K, V> pair = _hashTable[HashIndex]; 
                if (pair != null && pair.GetKey().Equals(key)) // Check that the KVP isn't null and compare the keys
                {
                    _hashTable[HashIndex] = new KeyValuePair<K, V>(key, value); // Replace the value
                    return true;
                }
                if (HashIndex <= 1) // Check if the value is 0 or 1, if we don't do this we end-up in an infinite loop of hash values.
                {
                    for (int i = 0; i < _capacity; i++) // Loop over and all positions in the hashtable
                    {
                        if (_hashTable[i] == null) { 
                            HashIndex = i; // If we find an empty slow just set the "HashIndex" to that position
                            break;
                        }
                    }
                    break;
                }
                HashIndex = (int)(Math.Pow(Convert.ToDouble(HashIndex), 2) % _capacity); // Otherwise Quadratic-Probing Open Adressing
            }
            _hashTable[HashIndex] = new KeyValuePair<K, V>(key, value); // Add the value
            _isOccupied[HashIndex] = true; // Update isOccupied
            _count++; // Increment Count
            return true;
        }

        public void Clear()
        {
            _capacity = _defaultCapacity; // Reset Capacity to DefaultCapacity
            _count = 0; // Set count to 0
            _hashTable = new KeyValuePair<K, V>[_capacity]; // Reset the HashTable to a new array
            _isOccupied = new bool[_capacity]; // Reset IsOccupied
        }

        public bool ContainsKey(K key)
        {
            for (int i = 0; i < _capacity; i++) // Loop over all of the positions
            {
                KeyValuePair<K, V> pair = _hashTable[i]; // Grab the KVP
                if (pair != null && pair.GetKey().Equals(key)) return true; // Check is the KVP is null, if it isn't compare keys and return true if found.
            }
            return false; // If none are found then return false
        }

        public bool ContainsValue(V value)
        {
            for (int i = 0; i < _capacity; i++) // Loop over all of the positions
            {
                KeyValuePair<K, V> pair = _hashTable[i]; // Grab the KVP
                if (pair != null && pair.GetValue().Equals(value)) return true; // Check is the KVP is null, if it isn't compare values and return true if found.
            }
            return false;
        }

        public V? Get(K key)
        {
            for (int i = 0; i < _capacity; i++) // Loop over all of the positions
            {
                KeyValuePair<K,V> pair = _hashTable[i]; // Grab the KVP
                if (pair != null && pair.GetKey().Equals(key)) return pair.GetValue(); // Check is the KVP is null, if it isn't compare keys and return the value for the pair if found.
            }

            return default; // If none are found return the default which is normally null!
        }

        public bool IsEmpty()
        {
            return _count == 0; // True: Count is 0, False: Count is greater than 0, If it's less than 0 we've got a real problem boys D:
        }

        public bool Remove(K key)
        {
            for (int i = 0; i < _capacity; i++) // Loop over all of the positions
            {
                KeyValuePair<K, V> pair = _hashTable[i]; // Grab the KVP
                if (pair != null && pair.GetKey().Equals(key)) // Check is the KVP is null, if it isn't compare keys
                {
                    _hashTable[i] = null; // Set the HashTable index to null
                    _isOccupied[i] = false; // Set the isOccupied index to false
                    _count--; // Decrement count
                    return true;
                }
            }
            return false; // Return false for none found.
        }

        public int TotalCount()
        {
            return _count; // Not used here so return "_count"
        }

        public int Count()
        {
            return _count; // Return "_count"
        }

        public int BucketCount(int index)
        {
            return _count; // Not used here so return "_count"
        }

        public int Capacity()
        {
            return _capacity; // Return the capacity of the HashTable
        }

        public void Resize(int newCapacity)
        {
            KeyValuePair<K, V>[] hashTableTemp = new KeyValuePair<K, V>[newCapacity]; // Create a new HashTable with the new capacity
            bool[] isOccupiedTemp = new bool[newCapacity]; // Create a new isOccupied with the new capacity

            for (int i = 0; i < _capacity; i++) // Loop over all of the positions
            {
                hashTableTemp[i] = _hashTable[i]; // Copy over all the values in the HashTable
                isOccupiedTemp[i] = _isOccupied[i]; // Copy over all the values in isOccupied
            }

            _hashTable = hashTableTemp; // Set the old HashTable to be the new HashTable
            _isOccupied = isOccupiedTemp; // Set the old isOccupied to be the new isOccupied
            _capacity = newCapacity; // Set the capacity to the new capacity
        }

        public static int HashFunction(string key, int capacity)
        {
            int hash = 5381; // Default Hash
            foreach (char c in key) // Loopa över alla karaktären i nyckel strängen
            {
                hash = (hash * 33 + c) % capacity; // Ta orginal hashen gånger 33 + ASCII värdet för karaktären sen modulo på kapaciteten
            }

            return hash; // Returna den slutgiltiga hashen
        }
    }
}
