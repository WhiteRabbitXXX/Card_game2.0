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
        private bool Att {get; set;} = false; 
        public List<Card> PlrDck {get; set;} = new List<Card>();
        public Player(string name, int plrtp)
        {
            Name = name;
            PlrTp = plrtp;
        }
        bool DefChk(Card Atk, Card Def)
        {
            bool result = false;
            if ((Atk.Prt < Def.Prt) && ((Def.Suit == Atk.Suit)|(Def.Suit == Mth.trump)))
            {
                Console.WriteLine("chk for def succes");
                result = true;
            }
            else
            {
                Console.WriteLine("chk for def not succes");
                result = false;
            }
            return result;
        }
        bool AtkChk(Card Atk)
        {
            foreach (Card Card in Mth.DefTable)
            {
                if (Card.Rank == Atk.Rank)
                {
                    Console.WriteLine("chk for Rank opt1 succes");
                    Console.ReadLine();
                    return true;
                }
            }
            if (Mth.AtkTable.Count == 0)
            {
                return true;
            }
            else if ((Mth.AtkTable[0].Rank == Atk.Rank))
            {
                Console.WriteLine("chk for Rank opt2 succes");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Cant be played. Choose another card or pass");
                return false;
            }
        }
        public bool Turn()
        {
            Console.WriteLine($"chk Att is {Att}");
            bool Check = true;
            string input;
            int numb;
            if (Att|(Mth.AtkTable.Count == 0))
            {
                Att = true;
                Console.WriteLine($"{Name} chk for empty tbl succes");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"{Name} chk for empty tbl not succes");
                Console.ReadLine();
                Att = false;
            }
            if (PlrTp == 1)
            {
                do{
                    Console.WriteLine($"await for player turn so PRINT IT GOOFY Att is {Att}");
                    input = Console.ReadLine();
                    if ((input == "pass")|(input == "exit"))
                    {
                        if (Att)
                        {
                            Att = false;
                            Mth.PlrLst.Reverse();
                        }
                        return false;
                    }
                    else
                    {
                        numb = Convert.ToInt32(input);
                    }
                    if (Att&&(AtkChk(PlrDck[numb]))&Check)
                    {
                        Console.WriteLine($"players turn for atk AtkTbl is {Mth.AtkTable.Count} Att is {Att}");
                        Console.ReadLine();
                        Mth.AtkTable.Add(PlrDck[(numb)]);
                        PlrDck.RemoveAt(numb);
                        Check = false;
                    }
                    else if ((!Att)&&Check&(DefChk(Mth.AtkTable[Mth.AtkTable.Count -1], PlrDck[numb])))
                    {
                        Console.WriteLine($"players turn for def AtkTbl is {Mth.AtkTable.Count} Att is {Att}");
                        Console.ReadLine();
                        Mth.DefTable.Add(PlrDck[numb]);
                        PlrDck.RemoveAt(numb);
                        Check = false;
                    }
                } while (Check);
                return true;
            }
            else
            {
                do {
                    for (int i = 0; Check; i++)
                    {
                        if (i == PlrDck.Count)
                        {
                            Console.WriteLine("index chk");
                            Console.ReadLine();
                            if (Att)
                            {
                                Att = false;
                                Mth.PlrLst.Reverse();
                            }
                            return false;
                            Check = false;
                        }
                        if (Check&&Att&&(AtkChk(PlrDck[i])))
                        {
                            Console.WriteLine($"bot turn for atk AtkTbl is {Mth.AtkTable.Count} Att is {Att}");
                            Console.ReadLine();
                            Att = true;
                            Mth.AtkTable.Add(PlrDck[i]);
                            PlrDck.RemoveAt(i);
                            Check = false;
                        }
                        else if (Check&&(!Att)&&(DefChk(Mth.AtkTable[Mth.AtkTable.Count -1], PlrDck[i])))
                        {
                            Console.WriteLine($"bot turn for def AtkTbl is {Mth.AtkTable.Count} Att is {Att}");
                            Console.ReadLine();
                            Mth.DefTable.Add(PlrDck[i]);
                            PlrDck.RemoveAt(i);
                            Check = false;
                        }
                    }
                } while (Check);
                return true;
            } 
        }
   }
   class Mth
   {
        public static string trump;
        public static List<Player> PlrLst = new List<Player>();
        public static List<Card> AtkTable = new List<Card>();
        public static List<Card> DefTable = new List<Card>();

        public void ClearTbls()
        {
            if (AtkTable.Count != 0)
            {
                AtkTable.Clear();
            }
            if (DefTable.Count != 0)
            {
                DefTable.Clear();
            }
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
            Console.WriteLine();
            
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