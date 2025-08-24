using System;
using Methods;
using _main;

namespace GUI
{
    class gUI
    {
        public bool round = false;
        public bool menu = true;
        public bool gamePlay = false;
        public void Strt()
        {
            var Mth = new Methods.Mth();
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
            gamePlay = true;
            var Mth = new Methods.Mth();
            do{
                round = true;
                foreach (Player Player in Mth.PlrLst)
                {
                    if ((!Mth.Dealing(Player.PlrDck, _main._main.deck))&&(Player.PlrDck.Count == 0))
                    {
                        Console.WriteLine($"{Player.Name} win");
                        Console.ReadLine();
                        round = false;
                    }
                }
                int position = 0;
                while(round)
                {
                    Mth.PrintPlayers();
                    Mth.PrintTable();
                    round = Mth.PlrLst[position].Turn();
                    if (position == Mth.PlrLst.Count-1)
                    {
                        position = 0;
                    }
                    else
                    {
                        position++;
                    }
                }
                Console.WriteLine("round end if you want exit - insert exit");
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    Console.Clear();

                    gamePlay = false;
                    _main._main.gameOn = false;
                }
            }while(gamePlay);
                
                
                
        }
        
    }
}
