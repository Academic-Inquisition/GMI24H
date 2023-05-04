using System;

public class Insertion_Sort
{
	public Insertion_Sort() {}

    public void Sort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int k = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > k)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = k;
        }
    }
}
