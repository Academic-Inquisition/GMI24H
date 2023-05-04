using System;

public class Jump_Search
{
	public Jump_Search() {}

    public int Search(int[] array, int target)
    {
        new Insertion_Sort().Sort(array);
        int step = (int) Math.Floor(Math.Sqrt(array.Length));
        int prev = 0;
        while (array[Math.Min(step, array.Length) - 1] < target)
        {
            prev = step;
            step += (int) Math.Floor(Math.Sqrt(array.Length - prev));
            if (prev >= array.Length)
                return -1;
        }
        while (array[prev] < target)
        {
            prev++;
            if (prev == Math.Min(step, array.Length))
                return -1;
        }
        if (array[prev] == target)
            return prev;
        else
            return -1;
    }
}
