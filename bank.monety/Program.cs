using System;

namespace bank.monety
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KontoBankowe kontoPierwsze = new KontoBankowe();
            KontoBankowe kontoDrugie = new KontoBankowe();
            Automat automat = new Automat();

            // WYMAGANIE: Wrzucamy całą garść monet naraz (w tym zły nominał '3', błędny tekst 'kqw' oraz powtórzenia do testu limitu)
            automat.WrzucMonety(kontoPierwsze, "5 0.50 2 3 kqw 5 5 5");

            Console.WriteLine();
            Console.WriteLine($"Stan pierwszego konta: {kontoPierwsze.StanKonta():0.00} zł");
            Console.WriteLine($"Numer pierwszego konta: {kontoPierwsze.NumerKonta}");

            // WYMAGANIE: Wyświetlenie historii wpłat pierwszego konta
            Console.WriteLine("Historia wpłat pierwszego konta:");
            foreach (var wpłata in kontoPierwsze.PobierzHistorieWplat())
            {
                Console.WriteLine($" - wpłacono: {wpłata:0.00} zł");
            }

            Console.WriteLine();
            Console.WriteLine($"Numer drugiego konta: {kontoDrugie.NumerKonta}");
            Console.WriteLine($"Numery są różne: {kontoPierwsze.NumerKonta != kontoDrugie.NumerKonta}");

            Console.WriteLine();
            automat.PokazMonety();
        }
    }
}