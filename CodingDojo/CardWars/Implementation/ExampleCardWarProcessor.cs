using CodingDojo.CardWars.Data;
using CodingDojo.CardWars.Infrastructure;

namespace CodingDojo.CardWars.Implementation;

public class ExampleCardWarProcessor : ICardWarProcessor
{
    public GameResultType ProcessInput(CardWarInputData inputData)
    {
        var p1deck = inputData.PlayerOneStartingDeck.ToList();
        var p2deck = inputData.PlayerTwoStartingDeck.ToList();

        while (CheckGameResult(p1deck, p2deck) == null)
        {
            var p1cards = DrawCard(p1deck);
            var p2cards = DrawCard(p2deck);

            var roundResult = GetRoundResult(p1cards, p2cards);

            while (roundResult == RoundResultType.Tie 
                   && CheckGameResult(p1deck, p2deck) == null)
            {
                // Draw 3 cards, lose if no more cards
                for (int faceDownCards = 0; faceDownCards < 3; faceDownCards++)
                {
                    DrawNextCard(p1deck, p1cards);
                    DrawNextCard(p2deck, p2cards);

                    // if someone ran out of cards - drop out of here 
                    var intermediaryGameResult = CheckGameResult(p1deck, p2deck);
                    if (intermediaryGameResult != null)
                    {
                        return intermediaryGameResult.Value;
                    }
                }

                DrawNextCard(p1deck, p1cards);
                DrawNextCard(p2deck, p2cards);
                
                roundResult = GetRoundResult(p1cards, p2cards);
            }

            if (roundResult == RoundResultType.Tie)
            {
                return CheckGameResult(p1deck, p2deck) ?? GameResultType.Tie;
            }

            // здесь roundResult точно не Tie
            if (roundResult == RoundResultType.PlayerOne)
            {
                GiveCardsToWinner(
                    winnerDeck: p1deck,
                    winnerRoundCards: p1cards,
                    loserRoundCards: p2cards
                );
            }
            else
            {
                GiveCardsToWinner(
                    winnerDeck: p2deck,
                    winnerRoundCards: p2cards,
                    loserRoundCards: p1cards
                );
            }
        }
        
        return CheckGameResult(p1deck, p2deck).Value;
    }

    private List<CardValue> DrawCard(List<CardValue> deck)
    {
        var res = new List<CardValue>() { deck.FirstOrDefault() };
        deck.RemoveAt(0);
        return res;
    }

    // Draw 1 card, this needs to be called 4 times in case of tie
    private void DrawNextCard(List<CardValue> deck, List<CardValue> roundCards)
    {
        roundCards.Add(deck.First());
        deck.RemoveAt(0);
    }

    private RoundResultType GetRoundResult(List<CardValue> p1RoundCards, List<CardValue> p2RoundCards)
    {
        return (RoundResultType)p1RoundCards.Last().CompareTo(p2RoundCards.Last());
    }

    private void GiveCardsToWinner(List<CardValue> winnerDeck, List<CardValue> winnerRoundCards,
        List<CardValue> loserRoundCards)
    {
        for (int i = 0; i < winnerRoundCards.Count(); i++)
        {
            winnerDeck.Add(loserRoundCards[i]);
            winnerDeck.Add(winnerRoundCards[i]);
        }
    }

    private GameResultType? CheckGameResult(List<CardValue> p1Cards, List<CardValue> p2Cards)
    {
        if (!p1Cards.Any() && !p2Cards.Any())
        {
            return GameResultType.Tie;
        }

        if (!p1Cards.Any())
        {
            return GameResultType.PlayerTwo;
        }

        if (!p2Cards.Any())
        {
            return GameResultType.PlayerOne;
        }

        return null;
    }
}