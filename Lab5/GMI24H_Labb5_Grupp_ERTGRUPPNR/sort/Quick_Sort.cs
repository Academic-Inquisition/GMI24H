using System;
using System.ComponentModel;

public class Quick_Sort
{
	public Quick_Sort() {}

    public void Sort(int[] array, int start, int end)
    {
        var i = start;
        var j = end;
        var pivot = array[start];

        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if (start < j)
            Sort(array, start, j);

        if (i < end)
            Sort(array, i, end);
    }
}
