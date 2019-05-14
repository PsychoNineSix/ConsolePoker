using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PokerDealer.Poker
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

        public void DrawCard()
        {
            switch(Suit)
            {
                case CardSuit.Clubs:
                    Console.Write("\u2663 ");
                    break;
                case CardSuit.Hearts:
                    Console.Write("\u2665 ");
                    break;
                case CardSuit.Diamonds:
                    Console.Write("\u2666 ");
                    break;
                case CardSuit.Spades:
                    Console.Write("\u2660 ");
                    break;
            }
            Console.WriteLine(Value);
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
