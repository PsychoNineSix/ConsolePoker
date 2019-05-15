using System;
using System.Collections.Generic;
using System.Text;

namespace PokerServer.Poker
{
    public class CardSet
    {
        public List<Card> Deck = new List<Card>();

        private Random RandCard;

        public CardSet()
        {
            RandCard = new Random();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Deck.Add(new Card(suit, value));
                }
            }
        }

        public void BurnCard ()
        {
            Deck.RemoveAt(RandCard.Next(Deck.Count));
        }

        public bool ResetCards()
        {
            Deck.Clear();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Deck.Add(new Card(suit, value));
                }
            }

            return Deck.Count == 52 ? true : false;
        }

        public Hand CreateHand()
        {
            Card c1 = Deck[RandCard.Next(Deck.Count)];
            Deck.Remove(c1);
            Card c2 = Deck[RandCard.Next(Deck.Count)];
            Deck.Remove(c2);

            return new Hand(c1, c2);
        }

        public Card[] DealFlop()
        {
            Deck.RemoveAt(RandCard.Next(Deck.Count));

            Card[] cards = new Card[3];
            for (int i = 0; i < 3; i++)
            {
                cards[i] = Deck[RandCard.Next(Deck.Count)];
                Deck.Remove(cards[i]);
            }

            return cards;
        }

        public Card DealCard()
        {
            Deck.RemoveAt(RandCard.Next(Deck.Count));
            Card card = Deck[RandCard.Next(Deck.Count)];
            Deck.Remove(card);

            return card;
        }
    }
}
