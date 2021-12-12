namespace Bingo;

/// <summary>Represents the winning result of a game.</summary>
public record GameResult
{
	public int WinningDraw;
	public Board WinningBoard;

	public int Score()
	{
		return WinningBoard.UnmarkedSum() * WinningDraw;
	}
}
