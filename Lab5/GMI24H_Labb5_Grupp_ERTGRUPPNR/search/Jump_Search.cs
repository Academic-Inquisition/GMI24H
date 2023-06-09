﻿using System;

public class Jump_Search
{
	public Jump_Search() {}

    public int Search(int[] array, int target)
    {
        new Insertion_Sort().Sort(array);
        int step = Floor(Sqrt(array.Length));
        int prev = 0;

        while (array[Min(step, array.Length) - 1] < target)
        {
            prev = step;
            step += Floor(Sqrt(array.Length - prev));
            if (prev >= array.Length)
                return -1;
        }
        while (array[prev] < target)
        {
            prev++;
            if (prev == Min(step, array.Length))
                return -1;
        }
        if (array[prev] == target)
            return prev;
        else
            return -1;
    }

    private int Min(float x, float y)
    {
        return (int)(x < y ? x : y);
    }

    private int Floor(double x)
    {
        return (int)x;
    }

    private double Sqrt(float x)
    {
        float y = 1; 
        float number = x;
        float precision = 0.000001f;           

        while (Abs(x - y) / Abs(x) > precision)
        {
            x = (x + y) / 2;
            y = number / x;
        }

        return x;
    }

    private double Abs(double  x) 
    {
        return (x < 0) ? -x : x;
    }

}
