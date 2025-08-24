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
        void ClearTbls()
        {
            if (Mth.AtkTable.Count != 0)
            {
                Mth.AtkTable.Clear();
            }
            if (Mth.DefTable.Count != 0)
            {
                Mth.DefTable.Clear();
            }
        }
        void Grab()
        {
            if (Mth.AtkTable.Count != 0)
            {
                PlrDck.InsertRange(0, Mth.AtkTable);
            }
            if (Mth.DefTable.Count != 0)
            {
                PlrDck.InsertRange(0, Mth.DefTable);
            }
        }
        bool DefChk(Card Atk, Card Def)
        {
            bool result = false;
            if ((Atk.Prt < Def.Prt) && ((Def.Suit == Atk.Suit)|(Def.Suit == Mth.trump)))
            {
                result = true;
            }
            else
            {
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
                    return true;
                }
            }
            if (Mth.AtkTable.Count == 0)
            {
                return true;
            }
            else if ((Mth.AtkTable[0].Rank == Atk.Rank))
            {
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
            bool Check = true;
            string input;
            int numb;
            if (Att|(Mth.AtkTable.Count == 0))
            {
                Att = true;
            }
            else
            {
                Att = false;
            }
            if (PlrTp == 1)
            {
                do{
                    Console.WriteLine($"await for player turn so PRINT IT GOOFY Att is {Att}");
                    input = Console.ReadLine();
                    if ((input == "pass")|(input == ""))
                    {
                        if (!Att)
                        {
                            Grab();
                        }
                        else
                        {
                            Att = false;
                            Mth.PlrLst.Reverse();
                        }
                        ClearTbls();
                        return false;
                    }
                    else
                    {
                        numb = Convert.ToInt32(input);
                    }
                    if (Att&&(AtkChk(PlrDck[numb]))&Check)
                    {
                        Mth.AtkTable.Add(PlrDck[(numb)]);
                        PlrDck.RemoveAt(numb);
                        Check = false;
                    }
                    else if ((!Att)&&Check&(DefChk(Mth.AtkTable[Mth.AtkTable.Count -1], PlrDck[numb])))
                    {
                        Mth.DefTable.Add(PlrDck[numb]);
                        PlrDck.RemoveAt(numb);
                        Check = false;
                    }
                } while (Check);
                return true;
            }
            else
            {
                PlrDck.Sort((s1, s2) => s1.Prt.CompareTo(s2.Prt));
                do {
                    for (int i = 0; Check; i++)
                    {
                        if (i == PlrDck.Count)
                        {
                            if (!Att)
                            {
                                Grab();
                            }
                            else
                            {
                                Att = false;
                                Mth.PlrLst.Reverse();
                            }
                            ClearTbls();
                            Check = false;
                            return false;
                        }
                        if (Check&&Att&&(AtkChk(PlrDck[i])))
                        {
                            Att = true;
                            Mth.AtkTable.Add(PlrDck[i]);
                            PlrDck.RemoveAt(i);
                            Check = false;
                        }
                        else if (Check&&(!Att)&&(DefChk(Mth.AtkTable[Mth.AtkTable.Count -1], PlrDck[i])))
                        {
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
        public bool Dealing(List<Card> Player, List<Card> deck)
        {
            bool Deal = true;
            do 
            {
                if (deck.Count !=0)
                {
                    if (Player.Count < 6)
                    {
                        Player.Add(deck[0]);
                        deck.RemoveAt(0);
                    }
                    else
                    {
                        Deal = false;
                    }
                }
                else
                {
                    Deal = false;
                    return false;
                }   
            }while (Deal);
            return true;
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