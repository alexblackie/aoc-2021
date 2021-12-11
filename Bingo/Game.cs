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
}
