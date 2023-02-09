using System.Collections.Generic;
using CodingDojo.CardWars.Data;
using CodingDojo.CardWars.Implementation;
using CodingDojo.CardWars.Infrastructure;
using NUnit.Framework;

namespace CodingDojo.CardWars;

public class CodeWarsTests
{
	private ICardWarProcessor _cardWarProcessor;

	[SetUp]
	public void Setup()
	{
		_cardWarProcessor = new ExampleCardWarProcessor();
	}

	[Test]
	public void IsHigherHandWins()
	{
		var deck1 = new List<CardValue>
		{
			CardValue.Two
		};

		var deck2 = new List<CardValue>
		{
			CardValue.Ten
		};

		var input = new CardWarInputData(deck1, deck2);
		var result = _cardWarProcessor.ProcessInput(input);
		Assert.AreEqual(GameResultType.PlayerTwo, result);
	}

	[Test]
	public void IsEqualHandsTies()
	{
		var deck1 = new List<CardValue>
		{
			CardValue.Two
		};

		var deck2 = new List<CardValue>
		{
			CardValue.Two
		};

		var input = new CardWarInputData(deck1, deck2);
		var result = _cardWarProcessor.ProcessInput(input);
		Assert.AreEqual(result, GameResultType.Tie);
	}
	
	[Test]
	public void IsLargeHigherHandWins()
	{
		var deck1 = new List<CardValue>
		{
			CardValue.Two,
			CardValue.Three,
			CardValue.Four,
			CardValue.Five,
			CardValue.Ace
		};

		var deck2 = new List<CardValue>
		{
			CardValue.Two,
			CardValue.Three,
			CardValue.Four,
			CardValue.Five,
			CardValue.Six
		};

		var input = new CardWarInputData(deck1, deck2);
		var result = _cardWarProcessor.ProcessInput(input);
		Assert.AreEqual(GameResultType.PlayerOne, result);
	}

	[Test]
	public void IsLargeEqualHandsTies()
	{
		var deck1 = new List<CardValue>
		{
			CardValue.Three,
			CardValue.Two,
			CardValue.Five,
			CardValue.Ace,
			CardValue.Four,
		};

		var deck2 = new List<CardValue>
		{
			CardValue.Three,
			CardValue.Two,
			CardValue.Five,
			CardValue.Six,
			CardValue.Four,
		};

		var input = new CardWarInputData(deck1, deck2);
		var result = _cardWarProcessor.ProcessInput(input);
		Assert.AreEqual(GameResultType.Tie, result);
	}
}