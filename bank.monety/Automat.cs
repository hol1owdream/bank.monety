using System.Globalization;

namespace bank.monety
{
    internal class Automat
    {
        private readonly decimal[] _przyjmowaneMonety =
        {
            5m, 2m, 1m, 0.50m, 0.20m, 0.10m
        };

        private readonly Dictionary<decimal, int> _liczbaMonet = new();

        public Automat()
        {
            foreach (decimal moneta in _przyjmowaneMonety)
            {
                _liczbaMonet[moneta] = 0;
            }
        }

        public void WrzucMonete(KontoBankowe konto, string tekstMonety)
        {
            string ujednoliconyTekst = tekstMonety.Replace(',', '.');

            if (!decimal.TryParse(
                    ujednoliconyTekst,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal wartoscMonety))
            {
                Console.WriteLine($"Nieudany odczyt: {tekstMonety}");
                return;
            }

            if (!_liczbaMonet.ContainsKey(wartoscMonety))
            {
                Console.WriteLine($"Z³a moneta: {wartoscMonety}");
                return;
            }

            konto.Wplac(wartoscMonety);
            _liczbaMonet[wartoscMonety]++;
            Console.WriteLine($"Moneta przyjêta: {wartoscMonety:0.00} z³");
        }

        public void PokazMonety()
        {
            decimal lacznaWartosc = 0m;

            Console.WriteLine("Monety w automacie:");

            foreach (decimal nomina³ in _przyjmowaneMonety)
            {
                int liczba = _liczbaMonet[nomina³];
                decimal wartosc = liczba * nomina³;
                lacznaWartosc += wartosc;

                Console.WriteLine($"{nomina³:0.00} z³: {liczba}");
            }

            Console.WriteLine($"£¹czna wartoœæ: {lacznaWartosc:0.00} z³");
        }
    }
}