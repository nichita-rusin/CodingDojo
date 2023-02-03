namespace CodingDojo.CardWars.Data;

public struct CardWarInputData
{
	public IEnumerable<CardValue> PlayerOneStartingDeck { get; }
	public IEnumerable<CardValue> PlayerTwoStartingDeck { get; }

	public CardWarInputData(List<CardValue> playerOneStartingDeck, List<CardValue> playerTwoStartingDeck)
	{
		PlayerOneStartingDeck = playerOneStartingDeck;
		PlayerTwoStartingDeck = playerTwoStartingDeck;
	}
}