using System;
using System.Collections.Generic;
using PokerServer.Drawing;
using PokerServer.Poker;
using Terminal.Gui;

namespace PokerServer
{
    class Program
    {
        static ColorScheme scheme = new ColorScheme()
        {
            Normal = Terminal.Gui.Attribute.Make(Color.White, Color.Black),
            Focus = Terminal.Gui.Attribute.Make(Color.BrightRed, Color.Black),
            HotNormal = Terminal.Gui.Attribute.Make(Color.BrightRed, Color.Black),
            HotFocus = Terminal.Gui.Attribute.Make(Color.BrightRed, Color.Black)
        };

        static Toplevel top = Application.Top;

        static Window TablesWindow = new Window("Tables")
        {
            X = 0,
            Y = 1,

            Width = Dim.Percent(25),
            Height = Dim.Percent(50),
            ColorScheme = scheme
        };

        static Window PlayersWindow = new Window("Players")
        {
            X = 0,
            Y = Pos.Bottom(top) - 15,

            Width = Dim.Percent(25),
            Height = Dim.Percent(100),
            ColorScheme = scheme
        };

        static Window PlayerDetailsWindow = new Window("Player Details")
        {
            X = Pos.Center() - 32,
            Y = 1,

            Width = Dim.Percent(100),
            Height = Dim.Percent(25),
            ColorScheme = scheme
        };

        static Window TableViewWindow = new Window("Table View")
        {
            X = Pos.Center() - 32,
            Y = Pos.Bottom(top) - 23,

            Width = Dim.Percent(100),
            Height = Dim.Percent(100),
            ColorScheme = scheme
        };

        static List<Table> PokerTables;

        static void Main(string[] args)
        {
            Application.Init();


            PokerTables = new List<Table>();

            Table t1 = AddTable();
            Table t2 = AddTable();
            Table t3 = AddTable();

            t1.AddPlayer("Aron",    6699);
            t1.AddPlayer("Thomas",  2148);
            t1.AddPlayer("Mario",   69);
            t2.AddPlayer("Daan",    4244442);
            t2.AddPlayer("Daimy",   42040);
            t3.AddPlayer("Gerrit",  9001);
            t3.AddPlayer("Joost",   1337);
            t3.AddPlayer("Mag",     73337);
            t3.AddPlayer("Het",     8008);
            t3.AddPlayer("Weten",   9090);

            SetupConsole();       

            Dialog g = new Dialog("Are you sure?", 20, 10, new Button[] {
                new Button("Yes", true),
                new Button("No")
            });

            var menu = new MenuBar(new MenuBarItem[]
            {
                new MenuBarItem ("_Server", new MenuItem []
                {
                    new MenuItem ("_Start Server", "", new Action(StartServer)),
                    new MenuItem ("S_top Server", "", null),
                    new MenuItem ("_Quit Gracefully", "", null),
                    new MenuItem ("_ForceQuit", "", new Action(ForceQuit))
                })
            });

            top.Add(TablesWindow, PlayersWindow, PlayerDetailsWindow, TableViewWindow, menu);
            
            Application.Run();
        }

        private static Table AddTable()
        {
            if (PokerTables.Count < 9)
            {
                Table t = new Table();
                PokerTables.Add(t);
                TablesWindow.RemoveAll();
                TablesWindow.SetNeedsDisplay();

                for (int i = 0; i < PokerTables.Count; i++)
                {
                    Table tt = PokerTables[i];
                    string btntxt = string.Format("Table [{0}/{1}] ({2}/8 Players)", i + 1, PokerTables.Count, t.GetPlayers().Count);

                    TablesWindow.Add(new Button(0, i, btntxt, false) { Clicked = () => { ShowPlayers(tt); } });
                }

                return t;
            }

            return null;
        }

        private static void ShowPlayers(Table t)
        {
            PlayersWindow.RemoveAll();
            PlayersWindow.SetNeedsDisplay();
            List<Player> players = t.GetPlayers();

            string[] ButtonTexts = new string[players.Count];
            int firstindex = 100;

            for (int i = 0; i < players.Count; i++)
            {
                string text = string.Format
                (
                    "{0}{2}{1}",
                    players[i].Name,
                    players[i].Money,
                    new string(' ', (25 - players[i].Name.Length - players[i].Money.ToString().Length))
                );

                for (int y = text.Length - 1; y > 0; y--)
                {
                    bool isNumeric = int.TryParse(text[y].ToString(), out int n);
                    if (isNumeric && text[y - 1] == ' ')
                    {
                        firstindex = firstindex <= y - 2 ? firstindex : y - 2;
                    }
                }

                ButtonTexts[i] = text;
            }

            for (int i = 0; i < players.Count; i++)
            {
                char[] arr = ButtonTexts[i].ToCharArray();
                arr[firstindex] = '€';

                string txt = new string(arr);

                PlayersWindow.Add(new Button(0, i, txt, false));
            }
            
        }

        private static void SetupConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.SetWindowSize(128, 32);
            Console.Title = "Poker Server 420";
        }

        static void StartServer ()
        {
            if(true)
            {
                if (MessageBox.Query(64, 8, "Are you sure?", "Do you want to start the poker server?", new string[] { "Yes", "No!" }) == 0)
                {
                    //TODO: Start server
                }
            }
        }

        static void StopServer ()
        {
            
        }

        static void ForceQuit ()
        {
            if(MessageBox.ErrorQuery(32, 8, "Are you sure?", "This will not save!", new string[] { "Yes", "No!"}) == 0)
            {
                Application.RequestStop();
            }        
        }
    }
}
