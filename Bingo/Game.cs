using System.Collections.Generic;
using System.Linq;

namespace Bingo;

public class Game
{
	public List<Board> Boards = new List<Board>();

	public void AddBoards(List<Board> boards)
	{
		foreach (var b in boards)
		{
			AddBoard(b);
		}
	}

	public void AddBoard(Board board)
	{
		Boards.Add(board);
	}

	public Board? Draw(List<int> numbers)
	{
		foreach (var number in numbers)
		{
			foreach (var board in Boards)
			{
				board.MarkCell(number);
				// if we get a bingo, return the first board that bingos
				if (board.IsBingo()) return board;
			}
		}

		return null;
	}
}
