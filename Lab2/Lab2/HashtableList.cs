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
            _hashTable = new List<KeyValuePair<K, V>>[_capacity]; // Create the HashTable
            for (int i = 0; i < _capacity; i++) _hashTable[i] = new List<KeyValuePair<K, V>>(); // Prefill with Buckets
            _isOccupied = new List<bool>[_capacity]; // Create the isOccupied array
            for (int i = 0; i < _capacity; i++) _isOccupied[i] = new List<bool>(); // Prefill with Buckets
            _count = 0; // Set count to 0
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

            List<KeyValuePair<K, V>> bucket = _hashTable[HashIndex];

            if (bucket.Count == 0) // If it's the first value to be added to the bucket, then go ahead and just add it!
            {
                // Add Value
                KeyValuePair<K, V> newPair = new KeyValuePair<K, V>(key, value); // Create the new KVP
                bucket.Add(newPair); // Add the KVP to the bucket
                _isOccupied[HashIndex].Add(true); // Update the isOccupied bucket slot
                // Increment count
                _totalCount++; // Increment the total count
                _count++; // Increment the count
                return true;
            }

            List<KeyValuePair<K, V>> newBucket; // Setup a newBucket variable

            while (_hashTable[HashIndex] != null) // Check if the bucket isn't null, if it is we have a problem since we prefilled buckets!
            {
                newBucket = _hashTable[HashIndex]; // Grab the bucket
                if (newBucket.Count == 0) break;  // Check if the bucket has no entries
                KeyValuePair<K, V> pair = newBucket[0]; // Grab the first entry
                if (pair != null && pair.GetKey().Equals(key)) // If it isn't null and the keys match
                {
                    newBucket[0] = new KeyValuePair<K, V>(key, value); // Then replace the KVP with a new KVP with an updated Value
                    return true;
                }
                if (HashIndex <= 1) // Check if the value is 0 or 1, if we don't do this we end-up in an infinite loop of hash values.
                {
                    for (int i = 0; i < _capacity; i++) // Loop over and all positions in the hashtable
                    {
                        if (_hashTable[i] == null)
                        {
                            HashIndex = i; // If we find an empty slow just set the "HashIndex" to that position
                            break;
                        }
                    }
                    break;
                }
                HashIndex = (HashIndex + 1 ) % _capacity; // Otherwise Linear-Probing Open Adressing
            }

            newBucket = _hashTable[HashIndex]; // Grab the Bucket
            KeyValuePair<K, V> np2 = new KeyValuePair<K, V>(key, value); // Create a new KVP with the values
            newBucket.Add(np2); // Add the KVP to the Bucket
            _totalCount++; // Increment TotalCount
            _count++; // Increment Count
            return true;
        }

        public void Clear()
        {
            _capacity = _defaultCapacity; // Reset capacity to default
            _totalCount = 0; // Reset total_count
            _count = 0; // Reset count
            _hashTable = new List<KeyValuePair<K, V>>[_capacity]; // Reset the HashTable
            _isOccupied = new List<bool>[_capacity]; // Reset the isOccupied
        }

        public bool ContainsKey(K key)
        {
            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity)); // Calculate index using hash function
            }
            else
            {
                throw new NullKeyException(); // Throw an exception if the input key is null
            }

            List<KeyValuePair<K, V>> bucket = _hashTable[HashIndex]; // Grab the bucket

            for (int i = 0; i < bucket.Count; i++) // Loop over all the bucket contents
            {
                KeyValuePair<K, V> pair = bucket[i];  // Grab the KVP
                K? indexKey = default; // Have a defaulted KVP

                if (pair != null) indexKey = pair.GetKey(); // Replace the defaulted with the pair Key if available

                if (indexKey != null && indexKey.Equals(key)) return true; // If the keys matches then return true
            }

            return false; // Else return false
        }

        public bool ContainsValue(V value)
        {
            // Det går säkert att göra den här funktionen mer effektiv
            for (int i = 0; i < _capacity; i++)
            {
                List<KeyValuePair<K, V>> bucket = _hashTable[i]; // Grab the bucket
                for (int j = 0; j < bucket.Count; j++) // Loop the bucket contents
                {
                    KeyValuePair<K, V> pair = bucket[j];   // Grab the pair
                    V? indexValue; // Init index value variable

                    if (pair != null) // Null-Check for Pair
                    {
                        indexValue = Get(pair.GetKey()); // Grab the Value
                        if (indexValue != null && indexValue.Equals(value)) return true; // Check so the values match, if they do return true 
                    }

                }
            }
            return false; // Else False
        }

        public V? Get(K key)
        {
            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity)); // Calculate index using hash function
            }
            else
            {
                throw new NullKeyException(); // Throw an exception if the input key is null
            }

            List<KeyValuePair<K, V>> bucket = _hashTable[HashIndex]; // Grab the bucket

            for (int i = 0; i < bucket.Count; i++) // Loop the bucket contents
            {
                KeyValuePair<K, V> pair = bucket[i]; // Grab the pair

                if (pair != null) // Null-Check the pair
                {
                    K indexKey = pair.GetKey(); // Grab key
                    if (indexKey != null && indexKey.Equals(key)) return pair.GetValue(); // Check Keys, if they match return the value
                }
            }

            return default; // Else pass default (usually null)
        }

        public bool IsEmpty()
        {
            return _count == 0; // True: Count is 0, False: Count is greater than 0, If it's less than 0 we've got a real problem boys D:
        }

        public bool Remove(K key)
        {
            int HashIndex;

            if (key != null)
            {
                HashIndex = Math.Abs(HashFunction(key.ToString(), _capacity)); // Calculate index using hash function
            }
            else
            {
                throw new NullKeyException(); // Throw an exception if the input key is null
            }

            List<KeyValuePair<K, V>> bucket = _hashTable[HashIndex]; // Grab the bucket

            if (bucket.Count == 0) return false; // If the bucket is empty then return false

            for (int i = 0; i < bucket.Count; i++) // Loop the buckets contents
            {
                KeyValuePair<K, V> pair = bucket[i];   // Grab the KVP

                if (pair != null) // Null-Check the pair
                {
                    K indexKey = pair.GetKey(); // Grab the key
                    if (indexKey != null && indexKey.Equals(key)) // Null-Check the Key and Compare
                    {
                        bucket[i] = null; // Set the buckets positional value to null
                        _isOccupied[HashIndex][i] = false; // Set the positional value of the isOccupied bucket array to false
                        _totalCount--; // Decrement totalCount
                        if (i == 0) // Is it the first value in the bucket
                        {
                            _count--; // Decrement Count
                        }
                        return true; // Return true for success
                    }
                }
            }
            return false; // Return false for failure
        }

        public int TotalCount()
        {
            return _totalCount; // Returns total_count
        }

        public int Count()
        {
            return _count; // Returns count
        }

        public int BucketCount(int index)
        {
            return _hashTable[index].Count; // Returns the buckets count
        }

        public int Capacity()
        {
            return _capacity; // Returns the capacity of the HashTable
        }

        public void Resize(int newCapacity)
        {
            List<KeyValuePair<K, V>>[] hashTableTemp = new List<KeyValuePair<K, V>>[newCapacity]; // Create a new HashTable with the new capacity
            for (int i = 0; i < newCapacity; i++) hashTableTemp[i] = new List<KeyValuePair<K, V>>(); // Prefill the new HashTable with Buckets
            List<bool>[] isOccupiedTemp = new List<bool>[newCapacity]; // Create a new isOccupied with the new capacity
            for (int i = 0; i < newCapacity; i++) isOccupiedTemp[i] = new List<bool>(); // Prefill the new isOccupied array with Buckets

            for (int i = 0; i < _capacity; i++) // Loop over all of the positions
            {
                List<KeyValuePair<K, V>> bucket = _hashTable[i];
                for (int j = 0; j < bucket.Count; j++)
                {
                    hashTableTemp[i] = _hashTable[i]; // Copy over all the buckets in the HashTable
                    isOccupiedTemp[i] = _isOccupied[i]; // Copy over all the values in isOccupied
                }
            }

            _hashTable = hashTableTemp; // Set the old HashTable to be the new HashTable
            _isOccupied = isOccupiedTemp; // Set the old isOccupied to be the new isOccupied
            _capacity = newCapacity; // Set the capacity to the new capacity
        }

        private int HashFunction(string input, int capacity)
        {
            int total = 0; // Skapa en "total" variable med värdet 0
            char[] c = input.ToCharArray(); // Skapa en karaktärs array som är input-strängen bryten in i karaktärer.

            for (int k = 0; k <= c.GetUpperBound(0); k++) // loopa igenom alla karaktärer
                total += (int)c[k]; // Summera alla karaktärernas Ascii-koder till total
            return total % capacity; // Modulo av Totalen och Capacity
        }
    }
}
