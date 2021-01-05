using System;
using System.Collections.Generic;

namespace Szachy
{
    public class Plansza
    {
        //Konwersja litery na cyfrę
        public static string Konwersja_cyfra_litera(int i)
        {
            Dictionary<int, string> konwerter = new Dictionary<int, string>();
            konwerter.Add(0, "A");
            konwerter.Add(1, "B");
            konwerter.Add(2, "C");
            konwerter.Add(3, "D");
            konwerter.Add(4, "E");
            konwerter.Add(5, "F");
            konwerter.Add(6, "G");
            konwerter.Add(7, "H");
            return (konwerter[i]);
        }

        public static int Konwersja_litera_cyfra(string i )
        {
            Dictionary<string, int> konwerter = new Dictionary<string, int>();
            konwerter.Add("A", 0);
            konwerter.Add("B", 1);
            konwerter.Add("C", 2);
            konwerter.Add("D", 3);
            konwerter.Add("E", 4);
            konwerter.Add("F", 5);
            konwerter.Add("G", 6);
            konwerter.Add("H", 7);
            return konwerter[i];
        }
        

        //Wyświetlanie planszy po wykonaniu ruchów
        public static void Display(Dictionary<string, Bierki> wszystkie_bierki)
        {
            int licznik = 0;
            Console.Write("\t");
            for (int i = 0; i < 8; i++)
            {
                Console.Write((" " + Konwersja_cyfra_litera(i) + "\t"));
            }

            Console.WriteLine();
            int licznikK = 8;
            foreach (var x in wszystkie_bierki)
            {
                if (licznik == 0)
                {
                    Console.Write(licznikK + "\t");
                }

                Console.Write(" " + x.Value.Shortname + "\t");
                licznik++;
                if (licznik == 8)
                {
                    Console.Write(licznikK + "\t");
                    Console.WriteLine("\t");
                    licznik = 0;
                    licznikK--;
                }
            }

            Console.Write("\t");
            for (int i = 0; i < 8; i++)
            {
                Console.Write((" " + Konwersja_cyfra_litera(i) + "\t"));
            }

            Console.WriteLine("\t");
        }

        public static void Populate(Dictionary<string, Bierki> wszystkie_bierki)
        {
            //Liczniki służą do ułatwienia odróżniania bierek na wyświetlanej planszy
            int licznikP = 1;
            int licznikW = 1;
            int licznikS = 1;
            int licznikG = 1;


            string pozycja = " ";

            //Czarne
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 0)
                    {
                        //Wieża
                        if (j == 0 ^ j == 7)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(1, "Czarne", pozycja, "CW" + licznikW, true));
                            licznikW++;
                        }

                        //Skoczek
                        if (j == 1 ^ j == 6)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(2, "Czarne", pozycja, "CS" + licznikS, true));
                            licznikS++;
                        }

                        //Goniec
                        if (j == 2 ^ j == 5)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(3, "Czarne", pozycja, "CG" + licznikG, true));
                            licznikG++;
                        }

                        //Hetman
                        if (j == 3)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(4, "Czarne", pozycja, "CH", true));
                        }

                        //Król
                        if (j == 4)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(5, "Czarne", pozycja, "CK", true));
                        }
                    }
                    //Pion
                    if (i == 1)
                    {
                        pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                        wszystkie_bierki.Add(pozycja, new Bierki(6, "Czarne", pozycja, "CP" + licznikP, true));
                        licznikP++;
                    }
                }
            }

            //Puste
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                    wszystkie_bierki.Add(pozycja, new Bierki(7, " ", pozycja, "o", true));
                }
            }

            //Białe
            licznikP = 1;
            licznikW = 1;
            licznikS = 1;
            licznikG = 1;
            for (int i = 6; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 7)
                    {
                        //Wieża
                        if (j == 0 ^ j == 7)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(1, "Białe", pozycja, "BW" + licznikW, true));
                            licznikW++;
                        }

                        //Skoczek
                        if (j == 1 ^ j == 6)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(2, "Białe", pozycja, "BS" + licznikS, true));
                            licznikS++;
                        }

                        //Goniec
                        if (j == 2 ^ j == 5)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(3, "Białe", pozycja, "BG" + licznikG, true));
                            licznikG++;
                        }

                        //Hetman
                        if (j == 3)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(4, "Białe", pozycja, "BH" ,true));
                        }

                        //Król
                        if (j == 4)
                        {
                            pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                            wszystkie_bierki.Add(pozycja, new Bierki(5, "Białe", pozycja, "BK",true));
                        }
                    }

                    if (i == 6)
                    {
                        pozycja = Konwersja_cyfra_litera(j) + Convert.ToString(8 - i);
                        wszystkie_bierki.Add(pozycja, new Bierki(6, "Białe", pozycja, "BP" + licznikP, true));
                        licznikP++;
                    }
                }
            }
        }
    }
}