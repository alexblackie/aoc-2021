namespace Submarine;

/// <summary>
/// Service to map increases from radar telemetry logs.
/// </summary>
public class DepthComparator
{
	/// <summary>
	/// Return the number of depth measurements that are increases from the
	/// previously-measured value.
	/// </summary>
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

	/// <summary>
	/// Use a three-element sliding window to compare depths, only counting an
	/// increase if the sum of the window's elements has increased.
	/// </summary>
	public int CountIncreasesThrice(int[] depths)
	{
		int count = 0;
		int? previousSum = null;

		for (int i = 0; i < (depths.Length - 2); i++)
		{
			int sum = depths[i] + depths[i+1] + depths[i+2];

			if (previousSum != null && sum > previousSum)
				count++;

			previousSum = sum;
		}

		return count;
	}
}
