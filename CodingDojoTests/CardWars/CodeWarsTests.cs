using System;
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
	public void IsBothNullInputThrows()
	{
		var input = new CardWarInputData(null, null);

		void Act() => _cardWarProcessor.ProcessInput(input);

		Assert.Throws(Is.InstanceOf<Exception>(), Act);
	}

	[Test]
	public void IsLeftNullInputThrows()
	{
		var playerOneStartingDeck = new List<CardValue>
		{
			CardValue.Eight
		};
		var input = new CardWarInputData(playerOneStartingDeck, null);

		void Act() => _cardWarProcessor.ProcessInput(input);

		Assert.Throws(Is.InstanceOf<Exception>(), Act);
	}

	[Test]
	public void IsRightNullInputThrows()
	{
		var startingDeck = new List<CardValue>
		{
			CardValue.Eight
		};
		var input = new CardWarInputData(null, startingDeck);

		void Act() => _cardWarProcessor.ProcessInput(input);

		Assert.Throws(Is.InstanceOf<Exception>(), Act);
	}
}