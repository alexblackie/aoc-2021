namespace Day1;

public class DepthComparator
{
	// <summary>
	// Return the number of depth measurements that are increases from the
	// previously-measured value.
	// </summary>
	public int CountIncreases(int[] depths)
	{
		int count = 0;
		int? previousD = null;
		foreach (int d in depths)
		{
			if (previousD != null && d > previousD)
				count++;

			previousD = d;
		}

		return count;
	}
}
