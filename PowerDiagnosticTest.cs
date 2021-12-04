using Xunit;
using System.Collections;
using System.Collections.Generic;

namespace Aoc;

public class PowerDiagnosticTest
{

	private Ingestor _ingestor = new Ingestor();

	[Fact]
	public void TestParse()
	{
		List<BitArray> measurements = _ingestor.ReadBinaryDiagnostic("../../../Fixtures/BinaryDiagnostic.txt");
		var record = PowerDiagnostic.Parse(measurements);

		Assert.Equal(22, record.GammaRate);
		Assert.Equal(9, record.EpsilonRate);
	}

}
