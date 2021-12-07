namespace Bingo;

public record Cell
{
	public int Number;
	public bool Marked = false;

	public void MarkIf(int number)
	{
		if (Number == number) Marked = true;
	}
}
