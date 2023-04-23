using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal interface HashTableInterface<K, V>
    {
        /**
         * Example: Add("HejsanPär", 5)
         * 
         * K: En nyckel av något slag med en implementerad ToString() metod
         * V: Vilket "T" Generic värde som helst
         * 
         * Lägger till ett värde i HashTable:n
         */
        public bool Add(K key, V value);

        /**
         * Example: Get("HejsanPär")
         * 
         * K: En nyckel av något slag med en implementerad ToString() metod
         * 
         * Hämtar ett värde ur HashTable:n
         */
        public V? Get(K key);

        /**
         * Example: Remove("HejsanPär")
         * 
         * K: En nyckel av något slag med en implementerad ToString() metod
         * 
         * Tar bort ett värde ur HashTable:n
         */
        public bool Remove(K key);

        /**
         * Example: Clear()
         * 
         * Noll-ställer och Rensar hela HashTable:n
         */
        public void Clear();

        /**
         * Example: ContainsValue(5)
         * 
         * V: Vilket "T" Generic värde som helst
         * 
         * Kollar om HashTable:n innehåller värdet
         */
        public bool ContainsValue(V value);

        /**
         * Example: ContainsKey("HejsanPär")
         * 
         * K: En nyckel av något slag med en implementerad ToString() metod
         * 
         * Kollar om HashTable:n innehåller nyckeln
         */
        public bool ContainsKey(K key);

        /**
         * Example: IsEmpty()
         * 
         * Ger dig antingen True eller False beroende på om HashTable:n är tom eller inte.
         */
        public bool IsEmpty();

        /**
         * Example: TotalCount()
         * 
         * Ger dig den totala counten av innehåll i HashTable:n.
         */
        public int TotalCount();

        /**
         * Example: Count()
         * 
         * Ger dig Count värdet på HashTable:n
         */
        public int Count();

        /**
         * Example: BucketCount(3)
         * 
         * Get dig "Count" värdet på bucket:n vid det Indexet
         */
        public int BucketCount(int index);

        /**
         * Example: Capacity()
         * 
         * Ger dig kapaciteten på HashTable:n
         */
        public int Capacity();

        /**
         * Example: Resize(_capacity * 2)
         * 
         * newCapacity: Nya kapaciteten på HashTable:n
         * 
         * Noll-ställer och Rensar hela HashTable:n
         */
        public void Resize(int newCapacity);
    }
}
