using System;
using System.Collections.Generic;
using System.Globalization;

namespace bank.monety
{
    internal class Automat
    {
        // WYMAGANIE: Jedyne miejsce z list¹ dozwolonych nomina³ów w ca³ym kodzie
        private readonly decimal[] _przyjmowaneMonety = { 5m, 2m, 1m, 0.50m, 0.20m, 0.10m };

        // S³owniki przechowuj¹ce aktualn¹ liczbê monet w automacie oraz ich maksymaln¹ pojemnoœæ
        private readonly Dictionary<decimal, int> _liczbaMonet = new();
        private readonly Dictionary<decimal, int> _pojemnosciNominalow = new();

        public Automat()
        {
            foreach (decimal moneta in _przyjmowaneMonety)
            {
                _liczbaMonet[moneta] = 0;
                // Ustawiamy sztywny limit pojemnoœci (np. maksymalnie 3 sztuki ka¿dego nomina³u do celów testowych)
                _pojemnosciNominalow[moneta] = 3;
            }
        }

        public void WrzucMonety(KontoBankowe konto, string ciagMonet)
        {
            // Zabezpieczenie przed przekazaniem pustego ci¹gu znaków
            if (string.IsNullOrWhiteSpace(ciagMonet))
            {
                Console.WriteLine("Nie podano ¿adnych monet.");
                return;
            }

            // Dzielimy przekazany tekst na pojedyncze elementy rozdzielone spacjami, przecinkami lub œrednikami
            string[] elementy = ciagMonet.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            int przyjete = 0;
            int zwrocone = 0;

            Console.WriteLine($"\nPrzetwarzanie wp³aty dla konta nr {konto.NumerKonta}...");

            // Pêtla analizuj¹ca ka¿d¹ pojedyncz¹ monetê z osobna
            foreach (string element in elementy)
            {
                // Ujednolicamy separatroy dziesiêtne (zamiana przecinka na kropkê)
                string ujednoliconyTekst = element.Replace(',', '.');

                // 1. Sprawdzamy, czy wpisany tekst da siê w ogóle przekszta³ciæ na liczbê
                if (!decimal.TryParse(ujednoliconyTekst, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal wartoscMonety))
                {
                    Console.WriteLine($"  [Odrzucono - b³¹d odczytu]: {element}");
                    zwrocone++;
                    continue; // Przechodzimy do kolejnej monety
                }

                // 2. Sprawdzamy dynamicznie, czy podana wartoœæ znajduje siê w naszej tablicy dozwolonych nomina³ów
                bool czyObslugiwany = Array.Exists(_przyjmowaneMonety, m => m == wartoscMonety);
                if (!czyObslugiwany)
                {
                    Console.WriteLine($"  [Odrzucono - z³y nomina³]: {wartoscMonety:0.00} z³");
                    zwrocone++;
                    continue;
                }

                // 3. Sprawdzamy pojemnoœæ: czy liczba monet danego nomina³u osi¹gnê³a ju¿ limit w automacie
                if (_liczbaMonet[wartoscMonety] >= _pojemnosciNominalow[wartoscMonety])
                {
                    Console.WriteLine($"  [Zwrócono - brak miejsca w automacie]: {wartoscMonety:0.00} z³");
                    zwrocone++;
                    continue;
                }

                // Jeœli przesz³o wszystkie testy: ksiêgujemy œrodki na koncie i zwiêkszamy licznik w automacie
                konto.Wplac(wartoscMonety);
                _liczbaMonet[wartoscMonety]++;
                przyjete++;
                Console.WriteLine($"  [Przyjêto]: {wartoscMonety:0.00} z³");
            }

            // Podsumowanie ca³ej operacji wrzucania garœci monet
            Console.WriteLine($"-> Podsumowanie wp³aty: Przyjêto monet: {przyjete}, Zwrócono monet: {zwrocone}");
        }

        public void PokazMonety()
        {
            decimal lacznaWartosc = 0m;

            Console.WriteLine("Stan monet w automacie:");

            foreach (decimal nominal in _przyjmowaneMonety)
            {
                int liczba = _liczbaMonet[nominal];
                int limit = _pojemnosciNominalow[nominal];
                decimal wartosc = liczba * nominal;
                lacznaWartosc += wartosc;

                Console.WriteLine($"  {nominal,5:0.00} z³: {liczba} szt. (limit: {limit})");
            }

            Console.WriteLine($"£¹czna wartoœæ w automacie: {lacznaWartosc:0.00} z³");
        }
    }
}