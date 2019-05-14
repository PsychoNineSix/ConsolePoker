using System;
using Xunit;
using PokerDealer.Poker;

namespace PokerTest
{
    public class DeckTest
    {
        [Fact]
        public void TestStackCreationOfDeckerDeck()
        {
            CardSet c = new CardSet();
            Assert.Equal(52, c.Deck.Count);
        }

        [Fact]
        public void TestHandCreationAndStuff()
        {
            CardSet c = new CardSet();
            Hand h = c.CreateHand();

            Assert.Equal(50, c.Deck.Count);
            Assert.NotNull(h.CardOne);
            Assert.NotNull(h.CardTwo);
            Assert.NotEqual(h.CardOne, h.CardTwo);
        }
    }
}
