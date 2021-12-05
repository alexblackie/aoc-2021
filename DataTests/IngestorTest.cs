using Xunit;
using System.Collections;
using System.Collections.Generic;
using Data;

namespace DataTests;

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
	public void TestReadBinary()
	{
		var service = new Ingestor();

		List<BitArray> bits = service.ReadBinary("../../../Fixtures/BinaryDiagnostic.txt");
		List<BitArray> expected = new List<BitArray>()
		{
			new BitArray(new bool[] { false, false, true, false, false }),
			new BitArray(new bool[] { true, true, true, true, false }),
			new BitArray(new bool[] { true, false, true, true, false }),
			new BitArray(new bool[] { true, false, true, true, true }),
			new BitArray(new bool[] { true, false, true, false, true }),
			new BitArray(new bool[] { false, true, true, true, true }),
			new BitArray(new bool[] { false, false, true, true, true }),
			new BitArray(new bool[] { true, true, true, false, false }),
			new BitArray(new bool[] { true, false, false, false, false }),
			new BitArray(new bool[] { true, true, false, false, true }),
			new BitArray(new bool[] { false, false, false, true, false }),
			new BitArray(new bool[] { false, true, false, true, false }),
		};

		Assert.Equal(expected, bits);
	}
}
