using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace bank.monety
{
    internal class Automat
    {
        private int _iloscMonet;
        private readonly decimal[] _przyjmowaneMonety = new decimal[] { 5.0m, 2.0m, 1.0m, 0.5m, 0.2m, 0.1m };
        // Stwórz metodę WrzucMonete
        public void WrzucMonete(bankmonety konto, string moneta)
        {
            //zamieniamy , na . żeby można było sparsować monete
            string monetaUjednoliczonyZapis = moneta.Replace(',', '.');

            // Sprawdzamy czy monetę da się W OGÓLE sparsować na jakiś decimal
            bool czyUdanyParse = decimal.TryParse(monetaUjednoliczonyZapis, CultureInfo.InvariantCulture,        out decimal wartoscMonety);

            if (!czyUdanyParse)
            {
                Console.WriteLine("Nieudany odczyt monety.");
                return;
            }

            // Sprawdź czy monety są z zakresu _przyjmowaneMonety
            foreach (decimal nominal in _przyjmowaneMonety)
            {
                // Jeżeli tak, to zwiększ saldo konta i ilość monet w automacie
                if (wartoscMonety == nominal)
                {
                    konto.Saldo += nominal;
                    _iloscMonet++;
                    Console.WriteLine($"pryjete monete: {wartoscMonety}. wrzucono: {moneta}, a ujednoliczony zapis: {monetaUjednoliczonyZapis}");
                }
            }
        }
    }
}

