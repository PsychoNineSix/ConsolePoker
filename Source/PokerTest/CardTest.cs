using System;
using Xunit;
using PokerServer.Poker;

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
        }
    }
}
