using Xunit;
using System.Collections.Generic;

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

	[Fact]
	public void TestReadDirectionChanges()
	{
		var service = new Ingestor();

		List<DirectionChange> changes = service.ReadDirectionChanges("../../../Fixtures/SubmarineControls.txt");
		var expected = new List<DirectionChange>()
		{
			new DirectionChange() { Down = 0, Forward = 5, Reverse = 0, Up = 0 },
			new DirectionChange() { Down = 5, Forward = 0, Reverse = 0, Up = 0 },
			new DirectionChange() { Down = 0, Forward = 8, Reverse = 0, Up = 0 },
			new DirectionChange() { Down = 0, Forward = 0, Reverse = 0, Up = 3 },
			new DirectionChange() { Down = 8, Forward = 0, Reverse = 0, Up = 0 },
			new DirectionChange() { Down = 0, Forward = 2, Reverse = 0, Up = 0 },
		};

		Assert.Equal(expected, changes);
	}
}
