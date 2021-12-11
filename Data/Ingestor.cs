using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;

namespace Data;

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
	/// Read the input file with the given name, and parse each line as a binary
	/// value, storing each bit in a <c>BitArray</c>.
	/// </summary>
	public List<BitArray> ReadBinary(string name)
	{
		return Read(name).Select(line =>
			new BitArray(line.ToCharArray().Select(c => c == '1').ToArray())
		).ToList();
	}

	/// <summary>
	/// Read the input file with the given name, and parse it as a bingo game
	/// -- the first line being the draws, and the remaining being a series of
	/// boards.
	/// </summary>
	public (List<int>, List<List<List<int>>>) ReadBingoGame(string name)
	{
		List<string> input = Read(name).Select(line => line).ToList();

		// Pull the first line as the draws
		var draws = input[0].Split(",").Select(number => int.Parse(number)).ToList();

		// Join the remaining input into a string so we can split on the
		// double-newlines to get each board out.
		var boards = string.Join("\n", input.Skip(1))
			.Split("\n\n")
			.Select(textBoard =>
					textBoard
					.Split("\n")
					.Where(cell => !string.IsNullOrWhiteSpace(cell))
					.Select(line =>
						line
						.Split(" ")
						.Where(cell => !string.IsNullOrWhiteSpace(cell))
						.Select(cell => int.Parse(cell)).ToList()).ToList())
			.ToList();

		return (draws, boards);
	}
}
