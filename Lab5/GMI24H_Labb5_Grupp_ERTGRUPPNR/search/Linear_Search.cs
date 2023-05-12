using System;

public class Linear_Search
{
    public Linear_Search() { }

    public int Search(int[] array, int target)
    {
        // psuedokod skulle kunna vara
        // foreach int in array
        //  if int is target
        //      return int
        //  else
        //      keep searching
        
        for (int i = 0; i < array.Length; i++)
        {
            if (target == array[i])
                return i; // add +1 if yor want to know the posistion instead of index
        }
        return -1;


    }
}
