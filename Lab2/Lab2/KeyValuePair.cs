using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class KeyValuePair<K, V>
    {
        private K _key { get; }
        private V _value { get; }

        public KeyValuePair(K key, V value) 
        {
            _key = key;
            _value = value;
        }
    }
}
