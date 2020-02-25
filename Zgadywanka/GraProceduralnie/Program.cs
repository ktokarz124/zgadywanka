using System;
using System.Diagnostics;

namespace GraProceduralnie
{
    class Program
    {
        const string zaduzo = "ZA DUŻO";
        const string zamalo = "ZA MAŁO";
        const string trafiono = "TRAFIONO";
        
        static void Main(string[] args)
        {
            Console.WriteLine("Gra, kto dziś śpi od ściany!");
            int a = WczytajLiczbe("Podaj dolny zakres losowania: ");
            int b = WczytajLiczbe("Podaj górny zakres losowania: ");
            int wylosowana = Losuj(a, b);
            
#if DEBUG
            Console.WriteLine(wylosowana);
#endif
            int licznik = 0;
            var stoper = new Stopwatch();
            stoper.Start();


            while (true)
            {
                // 2. człowiek proponuje rozwiązanie
                licznik++; //licznik = licznik + 1;
                int propozycja = WczytajLiczbe("Podaj swoją propozycję lub X, aby zakończyć: ");
                string wynik = (Ocena(wylosowana, propozycja));
                Console.WriteLine(wynik);
                if (wynik == "TRAFIONO")
                    break;
            }
            stoper.Stop();
            Console.WriteLine($"licznik ruchów = {licznik}");
            Console.WriteLine($"czas gry = {stoper.Elapsed}");
            Console.WriteLine("Koniec gry, śpisz od ściany!");
        }

        /// <summary>
        /// Losuje liczbę z podanego zakresu włącznie
        /// </summary>
        /// <param name="min">dolne ograniczenie</param>
        /// <param name="max">górne ograniczenie</param>
        /// <returns></returns>
        static int Losuj (int min = 1, int max = 100)
        {
            var min1 = Math.Min(min, max);
            var max1 = Math.Max(min, max);
            
            var nrd = new Random();
            var los = nrd.Next(min1, max1 + 1);
                        
            return los;
        }

        static int WczytajLiczbe(string prompt = "")
        {
            bool poprawnie = false;
            int wynik = 0;
            do
            {
                Console.Write(prompt);
                string wczytano = Console.ReadLine();
                if (wczytano == "x" || wczytano == "x")
                    Environment.Exit(0);

                try
                {
                    wynik = int.Parse(wczytano);
                    poprawnie = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("niepoprawny zapis liczby. Spróbuj  jeszcze raz: ");
                }

                catch (OverflowException)
                {
                    Console.WriteLine("przekroczony zakres");
                }

                catch (Exception)
                {
                    Console.WriteLine("nieznany błąd");
                }
            }
            while (!poprawnie);

            return wynik;
        }

        static string Ocena(int wylosowana, int propozycja )
        {
            if (wylosowana < propozycja)
            {
                return zaduzo;
            }
            else if (wylosowana > propozycja)
            {
                return zamalo;
            }
            else
            {
                return trafiono;
            }
        }
    }
}
