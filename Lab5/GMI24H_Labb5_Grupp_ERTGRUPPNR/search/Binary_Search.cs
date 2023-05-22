using System;

public class Binary_Search
{
	public Binary_Search() { }

	public int Search(int[] array, int target)
	{
		int min = 0;
		int max = array.Length - 1;

		while (min <= max)
		{
			int mid = (min + max) / 2;

			if (target < array[mid])
			{
				max = mid - 1;
			}
			else if (target > array[mid])
			{
				min = mid + 1;
			}
			else return mid;
		}

		return -1;
	}
}
