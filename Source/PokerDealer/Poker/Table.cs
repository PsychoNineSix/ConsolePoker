using System;
using System.Collections.Generic;
using System.Text;

namespace PokerDealer.Poker
{
    public class Table
    {
        public CardSet Cards { get; }
        private List<Player> Players { get; set; }
        public TableState State { get; private set; }
        public Dictionary<string, Hand> PlayerHands { get; private set; }

        public Table()
        {
            Cards = new CardSet();
            Players = new List<Player>();
            State = TableState.Setup;
            PlayerHands = new Dictionary<string, Hand>();
        }

        public Player AddPlayer (string name, int money)
        {
            Player p = new Player(name, money);
            Players.Add(p);
            return p;
        }

        public List<Player> GetPlayers()
        {
            return Players;
        }

        public void RemovePlayer (Player p)
        {
            Players.Remove(p);
            PlayerHands.Remove(p.Name);
        }

        public void DealToPlayers()
        {
            Cards.BurnCard();
            foreach(Player p in Players)
            {
                Hand h = Cards.CreateHand();
                p.GiveHand(h);
                PlayerHands.Add(p.Name, h);
            }
        }
    }

    public enum TableState
    {
        Setup,
        Preflop,
        Flop,
        Turn,
        River,
        FinishingRound,
        Done
    }
}
