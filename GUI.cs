using System;
using Methods;

namespace GUI
{
    class gUI
    {
        public bool Strt()
        {
            var Mth = new Methods.Mth();
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
                return true;
            }
            else if(insert == "start")
            {
                Console.WriteLine("soon");
                return true;
            }
            else
            {
                Console.WriteLine("exit");
                return false;
            }
        }
    }
}
