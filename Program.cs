using System;
using System.Text.Json;
using Methods;
using GUI;

namespace _main
{
    class _main
    {
        public static List<Card> deck;
        public static bool gameOn = true;
        public static void Init()
        {
            var Mth = new Methods.Mth();
            var GUI = new GUI.gUI(); 
            deck = Mth.DkUpd("card_collection.json");
            deck = Mth.Shuffle(deck);
        } 
        public static void Main()
        {
            var Mth = new Methods.Mth();
            var GUI = new GUI.gUI(); 
            Init();
            do
            {
                GUI.Strt();
                if (gameOn)
                {
                    GUI.GamePlay();
                }
            }while (gameOn);
            Console.WriteLine("bye");
            Console.ReadLine();
        }
    }
    
}
