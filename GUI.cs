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
                    Console.Write(string.Format($"|{Player.Name, -10}({Player.PlrDck.Count})| \t"));
                }
                Console.WriteLine();
                bool state = true;
                for (int i = 0; state; i++)
                {
                    foreach (Player Player in Mth.PlrLst)
                    {
                        if (Player.PlrDck.Count > i)
                        {
                            Console.Write(string.Format($"{Player.PlrDck[i].Rank} of {Player.PlrDck[i].Suit} ({Player.PlrDck[i].Prt})\t"));
                        }
                        else
                        {
                            string blanc = "";
                            Console.Write(string.Format("{0, -10}", blanc));
                            int check = 0;
                            for (int x = 0; x < Mth.PlrLst.Count; x++)
                            {
                                if (Mth.PlrLst[x].PlrDck.Count < i)
                                {
                                    check ++;
                                    if (check == Mth.PlrLst.Count)
                                    {
                                        state = false;
                                    }
                                }
                            }
                            check = 0;
                        }
                    }
                    Console.WriteLine();
                }
                
                
                Console.ReadLine();
            }
        }
    }
}
