using CodingDojo.CardWars.Data;

namespace CodingDojo.CardWars.Infrastructure;

public interface ICardWarProcessor
{
	CardWarOutputData ProcessInput(CardWarInputData inputData);
}