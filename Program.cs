using System;
using System.Text.Json;
using Methods;

namespace _main
{
    class _main
    {
        public static void Main()
        {
            var Mth = new Methods.Mth();
            List<Card> deck = Mth.DkUpd("card_collection.json");
            deck = Mth.Shuffle(deck);
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
