using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc;

public class Ingestor
{
	// <summary>
	// Read the input file with the given name and return its contents.
	// </summary>
	public IEnumerable<string> Read(string name)
	{
		string? line;
		using (var reader = File.OpenText(name))
		{
			while ((line = reader.ReadLine()) != null)
			{
				yield return line;
			}
		}
	}

	public int[] ReadNumbers(string name)
	{
		return Read(name)
			.Select(line => int.Parse(line))
			.ToArray();
	}
}
