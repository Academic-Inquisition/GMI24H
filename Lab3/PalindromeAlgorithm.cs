using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class PalindromeAlgorithm
    {
        /* Pseudo kod för denna uppgift skulle kunna se ut ungefär såhär. 
         * 
         * def IsPalindrome(str):
         *   clean = str.toLowerCase().filter(char => isLetterOrDigit(char))
         *   i = 0
         *   j =  clean.length - 1
         *   while i < j do:
         *       if clean[i] != clean[j] 
         *           then return false
         *       end if
         *       i = i + 1
         *       j = j - 1
         *   end while
         *   return true
         * end def
         *
         * Överlag är tidskomplexiten för funktionen O(n) + O(n) alltså O(2n) vilket simplifieras till O(n).
         * Detta betyder att tidskomplexiten växer linjärt med längden på input strängen.
         */
        public static bool IsPalindrome(string input)
        {
            // Clean-up the string by changing it to lower-case and removing any non-alphanumeric characters
            string cleanStr = new string(input.ToLower().Where(char.IsLetterOrDigit).ToArray()); // O(n)

            // Loop over from both ends 
            for (int i = 0, j = cleanStr.Length - 1; i < j; i++, j--) // O(n/2) => O(n)
            {
                // If the characters don't match-up then return False
                if (cleanStr[i] != cleanStr[j]) // O(1) + O(1)
                {
                    return false;
                }
            }
            // Else return true
            return true;
        }
    }
}
