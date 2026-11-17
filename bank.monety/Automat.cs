using System;
using System.Collections.Generic;
using System.Globalization;

namespace bank.monety
{
    internal class Automat
    {
        // 1. Jedyne miejsce z list¹ dozwolonych nomina³ów w ca³ym kodzie
        private readonly decimal[] _przyjmowaneMonety =
        {
            5m, 2m, 1m, 0.50m, 0.20m, 0.10m
        };

        private readonly Dictionary<decimal, int> _liczbaMonet = new();
        private readonly Dictionary<decimal, int> _pojemnosciNominalow = new();

        public Automat()
        {
            foreach (decimal moneta in _przyjmowaneMonety)
            {
                _liczbaMonet[moneta] = 0;
                // Ustalamy maksymaln¹ pojemnoœæ dla ka¿dego nomina³u w automacie (np. max 3 sztuki)
                _pojemnosciNominalow[moneta] = 3;
            }
        }

        // 2. Metoda przyjmuj¹ca ci¹g znaków z wieloma monetami naraz
        public void WrzucMonety(KontoBankowe konto, string ciagMonet)
        {
            if (string.IsNullOrWhiteSpace(ciagMonet))
            {
                Console.WriteLine("Nie podano ¿adnych monet.");
                return;
            }

            // Dzielimy ci¹g tekstowy na pojedyncze elementy rozdzielone spacjami, przecinkami lub œrednikami
            string[] elementy = ciagMonet.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            int przyjete = 0;
            int zwrocone = 0;

            Console.WriteLine($"\nPrzetwarzanie wp³aty dla konta nr {konto.NumerKonta}...");

            foreach (string element in elementy)
            {
                string ujednoliconyTekst = element.Replace(',', '.');

                // Sprawdzenie poprawnoœci formatu liczby
                if (!decimal.TryParse(
                        ujednoliconyTekst,
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture,
                        out decimal wartoscMonety))
                {
                    Console.WriteLine($"  [Odrzucono - b³¹d odczytu]: {element}");
                    zwrocone++;
                    continue;
                }

                // Sprawdzenie czy nomina³ jest obs³ugiwany (weryfikacja na podstawie tablicy bez sztywnych warunków if)
                bool czyObslugiwany = Array.Exists(_przyjmowaneMonety, m => m == wartoscMonety);
                if (!czyObslugiwany)
                {
                    Console.WriteLine($"  [Odrzucono - z³y nomina³]: {wartoscMonety:0.00} z³");
                    zwrocone++;
                    continue;
                }

                // 3. Sprawdzenie pojemnoœci automatu dla danego nomina³u
                if (_liczbaMonet[wartoscMonety] >= _pojemnosciNominalow[wartoscMonety])
                {
                    Console.WriteLine($"  [Zwrócono - brak miejsca w automacie]: {wartoscMonety:0.00} z³");
                    zwrocone++;
                    continue;
                }

                // Przyjêcie monety
                konto.Wplac(wartoscMonety);
                _liczbaMonet[wartoscMonety]++;
                przyjete++;
                Console.WriteLine($"  [Przyjêto]: {wartoscMonety:0.00} z³");
            }

            Console.WriteLine($"-> Podsumowanie: Przyjêto monet: {przyjete}, Zwrócono monet: {zwrocone}");
        }

        public void PokazMonety()
        {
            decimal lacznaWartosc = 0m;

            Console.WriteLine("Stan monet w automacie:");

            foreach (decimal nomina³ in _przyjmowaneMonety)
            {
                int liczba = _liczbaMonet[nomina³];
                int limit = _pojemnosciNominalow[nomina³];
                decimal wartosc = liczba * nomina³; // Poprawiono b³¹d z brakuj¹cym operatorem mno¿enia
                lacznaWartosc += wartosc;

                Console.WriteLine($"  {nomina³,5:0.00} z³: {liczba} szt. (limit: {limit})");
            }

            Console.WriteLine($"£¹czna wartoœæ w automacie: {lacznaWartosc:0.00} z³");
        }
    }
}