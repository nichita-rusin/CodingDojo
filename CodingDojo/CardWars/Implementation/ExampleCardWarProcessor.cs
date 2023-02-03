using CodingDojo.CardWars.Data;
using CodingDojo.CardWars.Infrastructure;

namespace CodingDojo.CardWars.Implementation;

public class ExampleCardWarProcessor : ICardWarProcessor
{
	public CardWarOutputData ProcessInput(CardWarInputData inputData)
	{
		if (inputData.PlayerOneStartingDeck.Any() && inputData.PlayerTwoStartingDeck.Any())
		{
			return CardWarOutputData.PlayerOne();
		}
		
		return CardWarOutputData.Tie();
	}
}