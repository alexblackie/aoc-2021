using Xunit;

namespace Aoc;

public class IngestorTest
{
	[Fact]
	public void TestReadNumbers()
	{
		var service = new Ingestor();
		int[] result = service.ReadNumbers("../../../Fixtures/ListOfNumbers.txt");
		int[] expected = { 127, 147, 181, 194, 3, 183, 1023, 234 };

		Assert.Equal(expected, result);
	}
}
