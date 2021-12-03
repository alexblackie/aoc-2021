using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc;

/// <summary>
/// Provides an API to read text files from disk and parse them in various ways
/// depending on their expected content format.
/// </summary>
public class Ingestor
{
	/// <summary>
	/// Read the input file with the given name and return its contents.
	/// </summary>
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

	/// <summary>
	/// Read the input file with the given name, and cast each line to an
	/// integer, returning an array of these integers.
	/// </summary>
	public int[] ReadNumbers(string name)
	{
		return Read(name)
			.Select(line => int.Parse(line))
			.ToArray();
	}

	/// <summary>
	/// Read the input file with the given name, and parse each line as a
	/// "change of direction" command. Parses each into proper
	/// <c>DirectionChange</c> records.
	/// </summary>
	public List<DirectionChange> ReadDirectionChanges(string name)
	{
		return Read(name).Select(line => DirectionChange.Parse(line)).ToList();
	}
}
