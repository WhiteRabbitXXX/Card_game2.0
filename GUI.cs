using System;
using Methods;
using _main;

namespace GUI
{
    class gUI
    {
        public bool round = false;
        public void Strt()
        {
            var Mth = new Methods.Mth();
            bool menu = true;
            while(menu)
            {
                Console.Clear();
                Console.WriteLine("create - create player | start - start game | exit - exit from app");
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
                foreach (Player Player in Mth.PlrLst)
                {
                    Mth.Dealing(Player.PlrDck, _main._main.deck);
                }
                int position = 0;
                round = true;
                while(round)
                {
                    Mth.PrintPlayers();
                    Mth.PrintTable();
                    Console.WriteLine($"pos is {position}");
                    Console.ReadLine();
                    round = Mth.PlrLst[position].Turn();
                    if (position == Mth.PlrLst.Count-1)
                    {
                        Console.WriteLine("pos clear");
                        Console.ReadLine();
                        position = 0;
                    }
                    else
                    {
                        Console.WriteLine("pos change");
                        Console.ReadLine();
                        position++;
                    }
                    
                
                }
                Mth.ClearTbls();
                Console.WriteLine("round end");
                Console.ReadLine();
            }
                
                
                
        }
        
    }
}
