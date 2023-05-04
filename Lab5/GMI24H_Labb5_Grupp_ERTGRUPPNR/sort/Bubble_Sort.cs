using System;

public class Bubble_Sort
{
    public Bubble_Sort() {}
    
    public void Sort(int[] array)
    {
        int n = array.Length;
        bool not_sorted = true;
        while (not_sorted)
        {
            not_sorted = false;
            for (int i = 1; i < n; i++)
            {
                if (array[i] < array[i - 1])
                {
                    int temp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = temp;
                    not_sorted = true;
                }
            }
            n--;
        }
    }
}
