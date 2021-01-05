using System;

namespace Szachy
{
    public class Bierki
    {
        
        
        public int Typ;
        public string Kolor;
        public string Pozycja;
        public string Shortname;
        public bool Brak_przesuniecia;

        public Bierki(int typ, string kolor, string pozycja, string shortname, bool brak_przesuniecia)
        {
            Typ = typ;
            Kolor = kolor;
            Pozycja = pozycja;
            Shortname = shortname;
            Brak_przesuniecia = brak_przesuniecia;
        }

        public void printInfo()
        {
            Console.WriteLine("XD");
        }
    }
}