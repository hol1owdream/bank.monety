using System;
namespace bank.monety
{
    internal class KontoBankowe
    {
        private decimal _saldo;
        private static int _kolejnyNumerKonta = 1;

        public KontoBankowe()
        {
            NumerKonta = _kolejnyNumerKonta.ToString();
            _kolejnyNumerKonta++;
        }

        public string NumerKonta { get; }

        public void Wplac(decimal kwota)
        {
            _saldo += kwota;
        }

        public decimal StanKonta()
        {
            return _saldo;
        }
    }
}
