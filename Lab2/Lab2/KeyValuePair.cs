using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class KeyValuePair<K, V>
    {
        // Nyckeln för KVP
        private K _key { get; }

        // Värdet för KVP
        private V _value { get; set; }

        // Constructor
        public KeyValuePair(K key, V value) 
        {
            _key = key;
            _value = value;
        }

        // De-Konstruerar KVP till sitt K och V värde.
        public void Deconstruct(out K key, out V value)
        {
            key = _key; value = _value;
        }

        // ToString() för KVP
        public override string ToString()
        {
            return $"Key: {_key}, Value: {_value}";
        }

        // Getter för Key
        public K GetKey() { return _key; }

        // Getter för Value
        public V GetValue() { return _value; }

        // Setter för Value
        public void SetValue(V value) { _value = value; }
    }
}
