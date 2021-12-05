using Xunit;
using System.Collections;
using System.Collections.Generic;
using Submarine;
using Data;

namespace SubmarineTests;

public class PowerDiagnosticTest
{

	private Ingestor _ingestor = new Ingestor();

	[Fact]
	public void TestParse()
	{
		// TODO: Fix this really awkward cross-package coupling. Need a test support library?
		List<BitArray> measurements = _ingestor.ReadBinary("../../../../DataTests/Fixtures/BinaryDiagnostic.txt");
		var record = PowerDiagnostic.Parse(measurements);

		Assert.Equal(22, record.GammaRate);
		Assert.Equal(9, record.EpsilonRate);
	}

}
