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
            _hashTable = new LinkedList<KeyValuePair<K, V>>[_capacity]; // Create the HashTable
            for (int i = 0; i < _capacity; i++) _hashTable[i] = new LinkedList<KeyValuePair<K, V>>(); // Prefill with Buckets
            _isOccupied = new LinkedList<bool>[_capacity]; // Create the isOccupied array
            for (int i = 0; i < _capacity; i++) _isOccupied[i] = new LinkedList<bool>(); // Prefill with Buckets
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

            // Add Value
            LinkedList<KeyValuePair<K, V>> bucket = _hashTable[HashIndex]; // Grab the bucket
            KeyValuePair<K, V> newPair = new KeyValuePair<K, V>(key, value); // Create the new KVP
            bucket.AddLast(newPair); // Add it to the end of the bucket
            _isOccupied[HashIndex].AddLast(true); // Add a true to the end of the isOccupied Bucket Array
            
            _totalCount++; // Increment the total count
            _count++; // Increment the count
            return true;
        }

        public void Clear()
        {
            _capacity = _defaultCapacity; // Reset capacity to default
            _totalCount = 0; // Reset total_count
            _count = 0; // Reset count
            _hashTable = new LinkedList<KeyValuePair<K, V>>[_capacity]; // Reset the HashTable
            _isOccupied = new LinkedList<bool>[_capacity]; // Reset the isOccupied
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

            LinkedList<KeyValuePair<K, V>> bucket = _hashTable[HashIndex]; // Grab the bucket

            for (int i = 0; i < bucket.Count; i++) // Loop over all the bucket contents
            {
                KeyValuePair<K, V> pair = bucket.ElementAt(i);  // Grab the KVP
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
                LinkedList<KeyValuePair<K, V>> bucket = _hashTable[i]; // Grab the bucket
                for (int j = 0; j < bucket.Count; j++) // Loop the bucket contents
                {
                    KeyValuePair<K, V> pair = bucket.ElementAt(j);   // Grab the pair
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

            LinkedList<KeyValuePair<K, V>> bucket = _hashTable[HashIndex]; // Grab the bucket

            for (int i = 0; i < bucket.Count; i++) // Loop the bucket contents
            {
                KeyValuePair<K, V> pair = bucket.ElementAt(i); // Grab the pair

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

            LinkedList<KeyValuePair<K, V>> bucket = _hashTable[HashIndex]; // Grab the bucket

            if (bucket.Count == 0) return false; // If the bucket is empty then return false

            for (int i = 0; i < bucket.Count; i++) // Loop the buckets contents
            {
                KeyValuePair<K, V> pair = bucket.ElementAt(i); // Grab the KVP

                if (pair != null) // Null-Check the pair
                {
                    K indexKey = pair.GetKey(); // Grab the key

                    if (indexKey != null && indexKey.Equals(key)) // Null-Check the Key and Compare
                    {
                        bucket.Remove(pair); // Remove the KVP from the bucket
                        bool temp = _isOccupied[HashIndex].ElementAt(i); // Set the positional value of the isOccupied bucket array to false
                        temp = false;
                        _totalCount--; // Decrement totalCount
                        _count--; // Decrement count
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
            LinkedList<KeyValuePair<K, V>>[] hashTableTemp = new LinkedList<KeyValuePair<K, V>>[newCapacity]; // Create a new HashTable with the new capacity
            for (int i = 0; i < newCapacity; i++) hashTableTemp[i] = new LinkedList<KeyValuePair<K, V>>(); // Prefill the new HashTable with Buckets
            LinkedList<bool>[] isOccupiedTemp = new LinkedList<bool>[newCapacity]; // Create a new isOccupied with the new capacity
            for (int i = 0; i < newCapacity; i++) isOccupiedTemp[i] = new LinkedList<bool>(); // Prefill the new isOccupied array with Buckets

            for (int i = 0; i < _capacity; i++) // Loop over all of the positions
            {
                LinkedList<KeyValuePair<K, V>> bucket = _hashTable[i];
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
            long total = 0; // Skapa en "total" variable med värdet 0
            char[] c = input.ToCharArray(); // Skapa en karaktärs array som är input-strängen bryten in i karaktärer.

            // "Horner's rule for generating a polynomial of 11 using ASCII values of the characters"
            for (int k = 0; k <= c.GetUpperBound(0); k++)
                total += 11 * total + (int)c[k];

            total = total % capacity; // Sätt total till en modulo av total och capacity

            if (total < 0) // Om total är mindre än 0
                total += capacity; // Increment total med Capacity

            return (int)total; // Return total
        }
    }
}
