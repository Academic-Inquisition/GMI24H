using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class MinimumArrayValue
    {
        private readonly int[] _array;


        public MinimumArrayValue(int arraySize)
        {
            _array = GenerateArray(arraySize); 
        }

        private int[] GenerateArray(int size) 
        {
            int[] temp = new int[size]; 
            Random rnd; 

            for (int i = 0; i < size; i++) 
            { 
                rnd = new Random(); 
                temp[i] = rnd.Next(25); 
            }

            return temp; 
        }

        /*
        ----- PSEUDOKOD -----
        Sätt första värdet i arrayen till minValue
        Loopa igenom hela arrayen och jämför varje tal med minValue
        Om det aktuella värdet i arrayen är mindre än minValue, sätt minValue till array[i]
        När loopen är klar, returnera minValue

        minValue = array[0]

        for each value in array
            if array[i] < minValue
                minValue = array[i]
        return minValue
        */

        public int Run()
        {
            int minValue = _array[0]; // O(1)

            for (int i = 1; i < _array.Length; i++) // O(n)
            {
                if (_array[i] < minValue) minValue = _array[i]; // O(1)
            }

            return minValue; // O(1)

            // Total tidskomplexitet: O(n)
        }

        public string GetArray() 
        {
            string result = string.Join(", ", _array);
            return result;
        }
    }
}
