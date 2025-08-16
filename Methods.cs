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
        public Player(string name, int plrtp)
        {
            Name = name;
            PlrTp = plrtp;
        }
   }
   class Mth
   {
        public static string trump;
        public static List<Player> PlrLst = new List<Player>();
        public static List<Card> AtkTable = new List<Card>();
        public static List<Card> DefTable = new List<Card>();
        public void PlayerTurn()
        {
            int numb = Convert.ToInt32(Console.ReadLine());
            AtkTable.Add(PlrLst[0].PlrDck[numb]);
            PlrLst[0].PlrDck.RemoveAt(numb);
            
        }
        public void PrintTable()
        {
            string message;
            Console.Write("Attack:\t");
            foreach (Card Card in AtkTable)
            {
                message = Card.Rank + " of " + Card.Suit;
                Console.Write(string.Format("{0, -19}", message));
            }
            Console.WriteLine();
            Console.Write("Defend:\t");
            foreach (Card Card in DefTable)
            {
                message = Card.Rank + " of " + Card.Suit;
                Console.Write(string.Format("{0, -19}", message));
            }
            
        }
        public void PrintPlayers()
        {
            Console.Clear();
            foreach (Player Player in PlrLst)
            {
                Console.Write(string.Format($"|{Player.Name, -10}({Player.PlrDck.Count})| \t"));
            }
            Console.WriteLine();
            bool state = true;
            for (int i = 0; state; i++)
            {
                foreach (Player Player in PlrLst)
                {
                    if (Player.PlrDck.Count > i)
                    {
                        Console.Write(string.Format($"{Player.PlrDck[i].Rank} of {Player.PlrDck[i].Suit} ({Player.PlrDck[i].Prt})\t"));
                    }
                    else
                    {
                        string blanc = " ";
                        Console.Write(string.Format("{0, -24}", blanc));
                        int check = 0;
                        for (int x = 0; x < PlrLst.Count; x++)
                        {
                            if (PlrLst[x].PlrDck.Count < i)
                            {
                                check ++;
                                if (check == PlrLst.Count)
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
        }
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