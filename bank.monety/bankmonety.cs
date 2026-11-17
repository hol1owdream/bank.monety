using System;
using System.Collections.Generic;

namespace bank.monety
{
    // Konto przechowuje saldo, numer oraz historię wpłat klienta.
    internal class KontoBankowe
    {
        // Aktualna kwota pieniędzy na koncie.
        private decimal _saldo;

        // Numer nadawany kolejnym tworzonym kontom.
        private static int _kolejnyNumerKonta = 1;

        // Kwoty wszystkich zaakceptowanych wpłat.
        private readonly List<decimal> _historiaWplat = new();

        public KontoBankowe()
        {
            // Każde konto otrzymuje kolejny unikalny numer.
            NumerKonta = _kolejnyNumerKonta.ToString();
            _kolejnyNumerKonta++;
        }

        // Numer identyfikujący konto.
        public string NumerKonta { get; }

        // Zwiększa saldo i zapisuje wpłatę w historii.
        public void Wplac(decimal kwota)
        {
            _saldo += kwota;
            _historiaWplat.Add(kwota);
        }

        // Próbuje wypłacić podaną kwotę z konta.
        public bool Wyplac(decimal kwota)
        {
            // Nie można wypłacić kwoty ujemnej, zera ani większej niż saldo.
            if (kwota <= 0 || kwota > _saldo)
            {
                return false;
            }

            _saldo -= kwota;
            return true;
        }

        // Zwraca aktualne saldo konta.
        public decimal StanKonta()
        {
            return _saldo;
        }

        // Wyświetla wszystkie wpłaty zapisane w historii konta.
        public void WyswietlHistorieWplat()
        {
            Console.WriteLine($"Historia wpłat dla konta nr {NumerKonta}:");

            // Jeżeli lista jest pusta, nie ma czego wyświetlać.
            if (_historiaWplat.Count == 0)
            {
                Console.WriteLine("  Brak wpłat.");
                return;
            }

            foreach (var wpłata in _historiaWplat)
            {
                Console.WriteLine($"  - wpłacono: {wpłata:0.00} zł");
            }
        }
    }
}