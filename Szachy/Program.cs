using System;
using System.Collections.Generic;
using System.IO;
using Szachy;


namespace Szachy
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            //Tworzenie planszy i zapełnianie jej bierkami
            
            Dictionary<string, Bierki> wszystkie_bierki = new Dictionary<string, Bierki>();
            Plansza.Populate( wszystkie_bierki);
            //Odczyt przebiegu gry
            StreamReader file =
                new StreamReader(@"D:\Projekty\C# - PichlinskiTomasz\Szachy\Szachy\Zapis_partii.txt");
            Plansza.Display(wszystkie_bierki);
            Console.WriteLine();
            bool ruch_b = true;
            while ((line = file.ReadLine()) != null)
            {
                
                string[] lines = line.Split('.');
                lines = lines[1].Split(' ');
                
                
                string[] white_move = lines[0].ToUpper().Split(':', '-');
                string[] black_move = lines[1].ToUpper().Split(':', '-');
                
                //Ruch Białych
                if (Ruchy.isCorrect(white_move, wszystkie_bierki, ruch_b) == false)
                {
                    Console.WriteLine("Błędny ruch w " + lines[0]);
                    break;
                }
                
                
                ruch_b = !ruch_b;
                
                //Ruch Czarncyh

                if(Ruchy.isCorrect(black_move, wszystkie_bierki, ruch_b)==false)
                {
                    Console.WriteLine("Błędny ruch w " + lines[1]);
                    break;
                }
                
                ruch_b = !ruch_b;
                
            }
            
            
            //Wyświetlenie planszy po wykonaniu ruchów jeśli były poprawne
            //
            Plansza.Display(wszystkie_bierki);
        }
    }
}