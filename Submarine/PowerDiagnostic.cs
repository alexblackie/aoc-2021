using System;
using System.Collections;
using System.Collections.Generic;

namespace Submarine;

/// <summary>
/// Record to hold parsed power system diagnostic data. Supports parsing binary
/// diagnostic reports to initialise a record.
/// </summary>
public record PowerDiagnostic
{
	public int GammaRate = 0;
	public int EpsilonRate = 0;

	public static PowerDiagnostic Parse(List<BitArray> report)
	{
		var record = new PowerDiagnostic();
		int length = report[0].Length;
		bool[] blendedRate = new bool[length];

		for (var i = 0; i < length; i++)
		{
			blendedRate[i] = MostCommonBit(report, i);
		}

		BitArray gammaBits = new BitArray(blendedRate);
		BitArray epsilonBits = new BitArray(blendedRate).Not();

		record.GammaRate = bitsToInt(gammaBits);
		record.EpsilonRate = bitsToInt(epsilonBits);

		return record;
	}

	private static bool MostCommonBit(List<BitArray> report, int index)
	{
		int oneCount = 0;
		int zeroCount = 0;

		foreach(var measurement in report)
		{
			if (measurement[index] == true) oneCount++;
			if (measurement[index] == false) zeroCount++;
		};

		if (oneCount > zeroCount)
		{
			return true;
		}

		return false;
	}

	// fuck this so much. converting a bitarray to int is a fucking nightmare.
	// the only way it works is to convert the beautiful bitarray datatype into
	// a fucking *string* so it can cast to an int. i hate this.
	private static int bitsToInt(BitArray bits)
	{
		string value = "";

		for (int i = 0; i < bits.Count; i++)
		{
			if (bits[i] == true) value += "1";
			if (bits[i] == false) value += "0";
		}

		return Convert.ToInt32(value, 2);
	}
}
