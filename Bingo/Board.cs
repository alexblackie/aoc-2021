using System.Collections.Generic;

namespace Bingo;

public class Board
{
	public List<List<Cell>> Cells = new List<List<Cell>>();

	public void MarkCell(int number)
	{
		foreach (var row in Cells)
		{
			foreach (var cell in row)
			{
				cell.MarkIf(number);
			}
		}
	}

	public bool IsBingo()
	{
		var marks = Cells.Select(row => row.Select(c => c.Marked).ToList()).ToList();

		foreach (var row in marks)
		{
			if (row.All(c => c == true)) return true;
		}

		for (int i = 0; i < marks[0].Count; i++)
		{
			if (marks.Select(row => row[i]).All(c => c == true)) return true;
		}

		return false;
	}
}
