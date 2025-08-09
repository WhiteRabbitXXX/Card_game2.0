using System;
using System.Text.Json;

namespace Methods
{
    class Card
   {
        public string Suit {get;}
        public string Rank {get;}
        public int Prt {get; set;}
        public Card(string suit, string rank, int prt)
        {
            Suit = suit;
            Rank = rank;
            Prt = prt;
        }
   }
   class Player
   {
        public string Name {get; set;}
        public int PlrTp {get; set;}
        public List<Card> PlrDck {get; set;} = new List<Card>();
        public int PlrPrt {get; set;}
        public Player(string name, int plrtp)
        {
            Name = name;
            PlrTp = plrtp;
        }
   }
   class Mth
   {
        public string trump;
        public static List<Player> PlrLst = new List<Player>();
        public void CrtPlr()
        {
            Console.Clear();
            Console.WriteLine("Add player");
            if (PlrLst.Count<4)
            {
                Console.WriteLine("player name");
                string name = Console.ReadLine();
                Console.WriteLine("player type: 0 - CPU, 1 - player");
                int type = Convert.ToInt32(Console.ReadLine());
                PlrLst.Add(new Player(name, type));
            }
            else
            {
                Console.WriteLine("Too many players");
                Console.ReadLine();
            }
        }
        public void Dealing(List<Card> Player, List<Card> deck)
        {
         for (int i = Player.Count - 1; i < 5; i++)
         {
            Player.Add(deck[0]);
            deck.RemoveAt(0);
         }
        } 
        public List<Card> DkUpd(string dct)
        {
            FileStream fl_strm = new FileStream(dct, FileMode.OpenOrCreate);
            List<Card>? deck = JsonSerializer.Deserialize<List<Card>>(fl_strm);
            return deck;
        }
        public List<Card> Shuffle(List<Card>? Y)
        {
           Random _rnd = new Random();
           for (int x = 0; x<=Y!.Count-1; x++)
            {
                int j = _rnd.Next(x+1);
                Card swp = Y[j];
                Y[j] = Y[x];
                Y[x] = swp;
            }
            trump = Y[Y.Count-1].Suit;
            foreach (Card card in Y)
            {
                if (card.Suit == trump)
                {
                card.Prt += 20;
                }
            }
            return Y;
        }
   }
   
}