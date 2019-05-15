using System;
using System.Collections.Generic;
using System.Text;
using PokerServer.Poker;

namespace PokerServer.Drawing
{
    public static class DrawElements
    {
        public static void DrawCard(Card c, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("|");

            switch (c.Suit)
            {
                case CardSuit.Clubs:
                    Console.Write("\u2663");
                    break;
                case CardSuit.Hearts:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\u2665");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case CardSuit.Diamonds:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\u2666");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case CardSuit.Spades:
                    Console.Write("\u2660");
                    break;
            }

            Console.Write(" |");
            Console.SetCursorPosition(x, y + 1);
            Console.Write('|');

            if ((int)c.Value <= 10)
            {
                Console.Write((int)c.Value);
            }
            else
            {
                Console.Write(c.Value.ToString().Substring(0, 1));
            }

            Console.Write((Console.CursorLeft == x + 3) ? "|" : " |");
        }
    }
}
