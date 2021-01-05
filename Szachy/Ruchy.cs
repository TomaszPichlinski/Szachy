using System;
using System.Collections.Generic;

namespace Szachy
{
    public class Ruchy
    {
        public static void Move(string[] move, Dictionary<string, Bierki> wszystkie_bierki)
        {
            wszystkie_bierki[move[1]] = wszystkie_bierki[move[0]];
            wszystkie_bierki[move[0]] = new Bierki(7, " ", move[0], "o", true);
        }

        public static bool isCorrect(string[] move, Dictionary<string, Bierki> wszystkie_bierki, bool ruch_b)
        {
            string Kolor;
            int[] field_start_coordinates = new int[2];
            int[] field_end_coordinates = new int[2];
            int przesuniecieY, przesuniecieX;

            //Konwersja na współrzędne 
            field_start_coordinates[1] = Plansza.Konwersja_litera_cyfra(Convert.ToString(move[0][0]));
            field_start_coordinates[0] = 8 - Convert.ToInt32(Convert.ToString(move[0][1]));
            field_end_coordinates[1] = Plansza.Konwersja_litera_cyfra(Convert.ToString(move[1][0]));
            field_end_coordinates[0] = 8 - Convert.ToInt32(Convert.ToString(move[1][1]));

            przesuniecieY = Math.Abs(field_end_coordinates[0] - field_start_coordinates[0]);
            przesuniecieX = Math.Abs(field_end_coordinates[1] - field_start_coordinates[1]);

            bool poprawnosc = Poprawnosc(przesuniecieY, przesuniecieX, wszystkie_bierki[move[0]].Typ, move,
                wszystkie_bierki[move[0]].Brak_przesuniecia, wszystkie_bierki[move[1]].Typ);

            if (ruch_b)
            {
                Kolor = "Białe";
            }
            else
            {
                Kolor = "Czarne";
            }


            //Sprawdzenie czy pole początkowe nie jest puste
            if (wszystkie_bierki[move[0]].Typ == 7)
            {
                return false;
            }
            //Sprawdzenie czy to ruch gracza

            else if (wszystkie_bierki[move[0]].Kolor != Kolor)
            {
                return false;
            }
            //Sprawdzenie pola końcowego czy nie jest to bierka gracza
            else if (wszystkie_bierki[move[0]].Kolor == wszystkie_bierki[move[1]].Kolor)
            {
                return false;
            }
            else if (poprawnosc)
            {
                wszystkie_bierki[move[0]].Brak_przesuniecia = false;
                Move(move, wszystkie_bierki);
                return true;
            }

            return false;
        }

        public static bool Poprawnosc(int przesuniecieY, int przesuniecieX, int typ, string[] move,
            bool brak_przesuniecia, int typ_bicie)
        {
            Console.WriteLine(brak_przesuniecia);
            if (brak_przesuniecia & typ == 6)
            {
                if (ruchyPionRozpoczecie(przesuniecieY, przesuniecieX))
                {
                    return true;
                }
            }
            else if (typ == 6 & typ_bicie != 7)
            {
                
                if (ruchyPionBicie(przesuniecieY, przesuniecieX))
                {
                    Console.WriteLine(typ_bicie);
                    Console.Write("XD");
                    return true;
                }
            }
            else
            {
                switch (typ)
                {
                    case 1:
                        if (ruchyWieza(przesuniecieY, przesuniecieX))
                        {
                            return true;
                        }

                        break;
                    case 2:
                        if (ruchySkoczek(przesuniecieY, przesuniecieX))
                        {
                            return true;
                        }

                        break;
                    case 3:
                        if (ruchyGoniec(przesuniecieY, przesuniecieX))
                        {
                            return true;
                        }

                        break;
                    case 4:

                        if (ruchyHetman(przesuniecieY, przesuniecieX))
                        {
                            return true;
                        }

                        break;
                    case 5:
                        if (ruchyKrol(przesuniecieY, przesuniecieX))
                        {
                            return true;
                        }

                        break;
                    case 6:
                        if (ruchyPion(przesuniecieY, przesuniecieX, brak_przesuniecia, typ_bicie))
                        {
                            return true;
                        }

                        break;
                }
            }
            


            return false;
        }

        public static bool ruchyPion(int ruch_y, int ruch_x, bool brak_przesuniecia,int typ_bicie)
        {
            int[][] Ruchy = new int[1][];
            Ruchy[0] = new[] {0, 1};

            foreach (var x in Ruchy)
            {
                if (ruch_x == x[0] & ruch_y == x[1])
                    return true;
            }

            return false;
        }

        public static bool ruchyPionRozpoczecie(int ruch_y, int ruch_x)
        {
            int[][] Ruchy = new int[2][];
            Ruchy[0] = new[] {0, 2};
            Ruchy[1] = new[] {0, 1};
            
            foreach (var x in Ruchy)
            {
                if (ruch_x == x[0] & ruch_y == x[1])
                    return true;
            }

            return false;
        }

        public static bool ruchyPionBicie(int ruch_y, int ruch_x)
        {
            int[][] Ruchy = new int[1][];
            Ruchy[0] = new[] {1, 1};
            
            foreach (var x in Ruchy)
            {
                if (ruch_x == x[0] & ruch_y == x[1])
                    return true;
            }

            return false;
        }

        public static bool ruchyWieza(int ruch_y, int ruch_x)
        {
            int[][] Ruchy = new int[16][];
            Ruchy[0] = new[] {1, 0};
            Ruchy[1] = new[] {2, 0};
            Ruchy[2] = new[] {3, 0};
            Ruchy[3] = new[] {4, 0};
            Ruchy[4] = new[] {5, 0};
            Ruchy[5] = new[] {6, 0};
            Ruchy[6] = new[] {7, 0};
            Ruchy[7] = new[] {8, 0};
            Ruchy[8] = new[] {0, 1};
            Ruchy[9] = new[] {0, 2};
            Ruchy[10] = new[] {0, 3};
            Ruchy[11] = new[] {0, 4};
            Ruchy[12] = new[] {0, 5};
            Ruchy[13] = new[] {0, 6};
            Ruchy[14] = new[] {0, 7};
            Ruchy[15] = new[] {0, 8};

            foreach (var x in Ruchy)
            {
                if (ruch_y == x[0] & ruch_x == x[1])
                    return true;
            }

            return false;
        }

        public static bool ruchySkoczek(int ruch_y, int ruch_x)
        {
            int[][] Ruchy = new int[2][];
            Ruchy[0] = new[] {2, 1};
            Ruchy[1] = new[] {1, 2};
            foreach (var x in Ruchy)
            {
                if (ruch_y == x[0] & ruch_x == x[1])
                    return true;
            }

            return false;
        }

        public static bool ruchyGoniec(int ruch_y, int ruch_x)
        {
            int[][] Ruchy = new int[8][];
            Ruchy[0] = new[] {1, 1};
            Ruchy[1] = new[] {2, 2};
            Ruchy[2] = new[] {3, 3};
            Ruchy[3] = new[] {4, 4};
            Ruchy[4] = new[] {5, 5};
            Ruchy[5] = new[] {6, 6};
            Ruchy[6] = new[] {7, 7};
            Ruchy[7] = new[] {8, 8};
            foreach (var x in Ruchy)
            {
                if (ruch_y == x[0] & ruch_x == x[1])
                    return true;
            }

            return false;
        }

        public static bool ruchyHetman(int ruch_y, int ruch_x)
        {
            int[][] Ruchy = new int[24][];
            Ruchy[0] = new[] {1, 1};
            Ruchy[1] = new[] {2, 2};
            Ruchy[2] = new[] {3, 3};
            Ruchy[3] = new[] {4, 4};
            Ruchy[4] = new[] {5, 5};
            Ruchy[5] = new[] {6, 6};
            Ruchy[6] = new[] {7, 7};
            Ruchy[7] = new[] {8, 8};
            Ruchy[8] = new[] {1, 0};
            Ruchy[9] = new[] {2, 0};
            Ruchy[10] = new[] {3, 0};
            Ruchy[11] = new[] {4, 0};
            Ruchy[12] = new[] {5, 0};
            Ruchy[13] = new[] {6, 0};
            Ruchy[14] = new[] {7, 0};
            Ruchy[15] = new[] {8, 0};
            Ruchy[16] = new[] {0, 1};
            Ruchy[17] = new[] {0, 2};
            Ruchy[18] = new[] {0, 3};
            Ruchy[19] = new[] {0, 4};
            Ruchy[20] = new[] {0, 5};
            Ruchy[21] = new[] {0, 6};
            Ruchy[22] = new[] {0, 7};
            Ruchy[23] = new[] {0, 8};

            foreach (var x in Ruchy)
            {
                if (ruch_y == x[0] & ruch_x == x[1])
                    return true;
            }

            return false;
        }

        public static bool ruchyKrol(int ruch_y, int ruch_x)
        {
            int[][] Ruchy = new int[3][];
            Ruchy[0] = new[] {1, 1};
            Ruchy[1] = new[] {0, 1};
            Ruchy[2] = new[] {1, 0};

            foreach (var x in Ruchy)
            {
                if (ruch_y == x[0] & ruch_x == x[1])
                    return true;
            }

            return false;
        }
    }
}