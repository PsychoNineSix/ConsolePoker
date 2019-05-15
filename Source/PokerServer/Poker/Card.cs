using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PokerServer.Poker
{
    public class Card
    {
        public CardSuit Suit { get; }
        public CardValue Value { get; }

        public Card (CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }

    public enum CardSuit
    {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }

    public enum CardValue
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
