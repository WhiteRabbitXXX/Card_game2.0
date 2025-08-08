using System;
using Methods;
using _main;

namespace GUI
{
    class gUI
    {
        public void Strt()
        {
            var Mth = new Methods.Mth();
            bool menu = true;
            while(menu)
            {
                Console.Clear();
                Console.WriteLine("create - create player start - start game exit - exit from app");
                foreach (Player Player in Mth.PlrLst)
                {
                    Console.WriteLine($"{Player.Name} : {Player.PlrTp}");
                }
                string insert = Console.ReadLine();
                if (insert == "create")
                {
                    Mth.CrtPlr();
                    menu = true;
                }
                else if(insert == "start")
                {
                    menu = false;
                }
                else
                {
                    Console.WriteLine("exit");
                    menu = false;
                    _main._main.gameOn = false;
                }
            }
        }
        public void GamePlay()
        {
            var Mth = new Methods.Mth();
            bool GamePlay = true;
            while(GamePlay)
            {
                Console.Clear();
                foreach (Player Player in Mth.PlrLst)
                {
                    Mth.Dealing(Player.PlrDck, _main._main.deck);
                }
                foreach (Player Player in Mth.PlrLst)
                {
                    Console.WriteLine($"{Player.Name} \t");
                    foreach (Card Card in Player.PlrDck)
                    {
                        Console.WriteLine($"{Card.Rank} of {Card.Suit} ({Card.Prt})");
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
