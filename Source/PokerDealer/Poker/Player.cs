using System;
using System.Collections.Generic;
using System.Text;

namespace PokerDealer.Poker
{
    public class Player
    {
        public string Name { get; }

        public PlayerStatus Status { get; }

        public Hand PlayerHand { get; private set; }

        public int Money { get; private set; }

        public Player (string name, int money)
        {
            Name = name;
            Money = money;
            Status = 0;
        }

        public void GiveHand(Hand h)
        {
            PlayerHand = h;
        }

        public void RemoveHand()
        {
            PlayerHand = null;
        }

        public static Player Load(string name)
        {
            int money = 0;
            //TODO: Load player from file/db
            return new Player(name, money);
        }

        public bool Save()
        {
            //TODO: Save player to file/db
            return false;
        }
    }

    public enum PlayerStatus
    {
        Active = 1,
        Folded = 0
    }
}
