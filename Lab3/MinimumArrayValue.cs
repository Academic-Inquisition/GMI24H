using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class MinimumArrayValue
    {
        

        private int[] array;
        private readonly int arraySize;

        public MinimumArrayValue(int arraySize)
        {
            this.arraySize = arraySize;
            array = GenerateArray(this.arraySize);
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
            int minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue) minValue = array[i];
            }

            return minValue;
        }

        public string GetArray() 
        {
            string result = string.Join(", ", array);
            return result;
        }
    }
}
