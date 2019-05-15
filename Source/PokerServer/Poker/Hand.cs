using System;
using System.Collections.Generic;
using System.Text;

namespace PokerServer.Poker
{
    public class Hand
    {
        public List<Card> Cards { get; }

        public bool Visible { get; set; }

        public Hand (Card one, Card two)
        {
            Cards = new List<Card>(new Card[] { one, two });
            Visible = false;
        }
    }
}
