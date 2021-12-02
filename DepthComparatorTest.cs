using Xunit;

namespace Aoc;

public class DepthComparatorTest
{
    [Fact]
    public void TestCountIncreases()
    {
		int[] input = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
		var service = new DepthComparator();
		Assert.Equal(7, service.CountIncreases(input));
	}

	[Fact]
	public void TestCountIncreasesThrice()
	{
		int[] input = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
		var service = new DepthComparator();
		Assert.Equal(5, service.CountIncreasesThrice(input));
	}
}
