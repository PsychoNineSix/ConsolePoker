using System;
using System.Collections.Generic;
using System.Text;

namespace PokerServer.Poker
{
    public class Table
    {
        public CardSet Cards { get; }
        private List<Player> Players { get; }
        public TableState State { get; private set; }
        public Dictionary<string, Hand> PlayerHands { get; }
        public List<Card> BoardCards { get; }
        public List<Dictionary<string, int>> PotList { get; }

        public Table()
        {
            Cards = new CardSet();
            Players = new List<Player>();
            State = TableState.Setup;
            PlayerHands = new Dictionary<string, Hand>();
            BoardCards = new List<Card>();
            PotList = new List<Dictionary<string, int>>();
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
