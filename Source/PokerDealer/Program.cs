using System;
using System.Collections.Generic;
using PokerDealer.Poker;
using Terminal.Gui;

namespace PokerDealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetWindowSize(128, 32);
            Console.Title = "Poker Server 420";

            Application.Init();
            var top = Application.Top;

            var TablesWindow = new Window("Tables")
            {
                X = 0,
                Y = 1,

                Width = Dim.Percent(25),
                Height = Dim.Percent(50)
            };

            var PlayersWindow = new Window("Players")
            {
                X = 0,
                Y = Pos.Bottom(top) - 15,

                Width = Dim.Percent(25),
                Height = Dim.Percent(100)
            };

            var PlayerDetailsWindow = new Window("Player Details")
            {
                X = Pos.Center() - 32,
                Y = 1,

                Width = Dim.Percent(100),
                Height = Dim.Percent(25)
            };

            var TableViewWindow = new Window("Table View")
            {
                X = Pos.Center() - 32,
                Y = Pos.Bottom(top) - 23,

                Width = Dim.Percent(100),
                Height = Dim.Percent(100)
            };

            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_Quit", "", () => {
                        Application.RequestStop ();
                    })
                }),
            });

            top.Add(TablesWindow, PlayersWindow, PlayerDetailsWindow, TableViewWindow, menu);

            //pokerwin.Add(w);

            //Application.Run();

            Table tab = new Table();
            tab.AddPlayer("Aron", 5000);
            
            foreach(Card c in tab.Cards.Deck)
            {
                c.DrawCard();
            }

            Console.Read();
        }
    }
}
