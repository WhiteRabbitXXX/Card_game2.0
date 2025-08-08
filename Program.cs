using System;
using System.Text.Json;
using Methods;
using GUI;

namespace _main
{
    class _main
    {
        public static void Init()
        {
            var Mth = new Methods.Mth();
            var GUI = new GUI.gUI(); 
            List<Card> deck = Mth.DkUpd("card_collection.json");
            deck = Mth.Shuffle(deck);
        } 
        public static void Main()
        {
            var Mth = new Methods.Mth();
            var GUI = new GUI.gUI(); 
            Init();
            bool gameOn = true;
            while (gameOn)
            {
                gameOn = GUI.Strt();
            }
            //Mth.CrtPlr();
            //Mth.CrtPlr();
            //Mth.PlrLst[0].PlrDck.Add(deck[10]);
            //Mth.PlrLst[1].PlrDck.Add(deck[20]);
            //Console.WriteLine($"{deck[1].Suit}");
            //Console.WriteLine($"{Mth.PlrLst[0].PlrDck[0].Suit}");
            //Console.WriteLine($"{Mth.PlrLst[1].PlrDck[0].Suit}");
            //Console.WriteLine(Mth.trump);
            Console.ReadLine();
        }
    }
    
}
