using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gra, kto dziś śpi od ściany! za dużo - za mało");
            // 1. komputer losuje
            #region losowanie
            var los = new Random(); //tworzę obiekt typu random
            int wylosowana = los.Next(1,101);
#if DEBUG
            Console.WriteLine(wylosowana);
#endif   
            Console.WriteLine("Wylosowałem liczbę od 1 do 100. Odgadnij ją!");
            #endregion losowanie
            
            bool odgadniete = false;
            // dopóki nie odgadnięte
            while ( !odgadniete)
            {
                                                            
                // 2. człowiek proponuje rozwiązanie
                Console.Write("Podaj swoją propozycję:");
                int propozycja = int.Parse(Console.ReadLine());
                
                // 3. komputer ocenia
                if (propozycja < wylosowana)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("za mało");
                    Console.ResetColor();
                }
                else if (propozycja > wylosowana)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("za duzo");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("trafiono");
                    Console.ResetColor();
                    odgadniete = true;
                }
            }
            Console.WriteLine("Koniec gry");
        }
    }
}
