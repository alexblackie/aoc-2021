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

	[Fact]
	public void TestReadBingoGame()
	{
		var service = new Ingestor();

		var (actualDraws, actualBoards) = service.ReadBingoGame("../../../Fixtures/Bingo.txt");
		var expectedDraws = new List<int>()
		{
			7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15,
			25, 12, 22, 18, 20, 8, 19, 3, 26, 1
		};

		var expectedBoards = new List<List<List<int>>>()
		{
			new List<List<int>>()
			{
				new List<int>() { 22, 13, 17, 11, 0 },
				new List<int>() { 8, 2, 23, 4, 24 },
				new List<int>() { 21, 9, 14, 16, 7 },
				new List<int>() { 6, 10, 3, 18, 5 },
				new List<int>() { 1, 12, 20, 15, 19 }
			},

			new List<List<int>>()
			{
				new List<int>() { 3, 15, 0, 2, 22 },
				new List<int>() { 9, 18, 13, 17, 5 },
				new List<int>() { 19, 8, 7, 25, 23 },
				new List<int>() { 20, 11, 10, 24, 4 },
				new List<int>() { 14, 21, 16, 12, 6 }
			},

			new List<List<int>>()
			{
				new List<int>() { 14, 21, 17, 24, 4 },
				new List<int>() { 10, 16, 15, 9, 19 },
				new List<int>() { 18, 8, 23, 26, 20 },
				new List<int>() { 22, 11, 13, 6, 5 },
				new List<int>() { 2, 0, 12, 3, 7 }
			},
		};

		Assert.Equal(expectedDraws, actualDraws);

		// The errors from just straight-comparing the two deep-nested lists
		// are 100% useless (basically just "DIDN'T MATCH LOL") so this at
		// least gives us a ghost of a chance to track down _something_
		for (int y = 0; y < expectedBoards.Count; y++)
		{
			for (int x = 0; x < expectedBoards[y].Count; x++)
			{
				Assert.Equal(expectedBoards[y][x], actualBoards[y][x]);
			}
		}
	}
}
