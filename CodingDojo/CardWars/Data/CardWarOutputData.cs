namespace CodingDojo.CardWars.Data;

public struct CardWarOutputData
{
	public GameResultType GameResultType { get; }

	private CardWarOutputData(GameResultType gameResultType)
	{
		GameResultType = gameResultType;
	}

	public static CardWarOutputData Tie()
	{
		return new CardWarOutputData(GameResultType.Tie);
	}

	public static CardWarOutputData PlayerOne()
	{
		return new CardWarOutputData(GameResultType.PlayerOne);
	}

	public static CardWarOutputData PlayerTwo()
	{
		return new CardWarOutputData(GameResultType.PlayerTwo);
	}
}