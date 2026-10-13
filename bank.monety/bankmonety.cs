using System;
using System.Collections.Generic;
using System.Text;

namespace bank.monety
{
    internal class bankmonety
    {
        private decimal _saldo;
        private string _numerKonta;
        private string _wlasciel;

        public decimal Saldo
        {
            get { return _saldo; }
        }

        public string Wlasciciel
        {
            get { return _wlasciel; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _wlasciel = value;
                }
                else
                {
                    Console.WriteLine("Błąd: Nazwa właściciela nie może być pusta!");
                }
            }
        }
        public bankmonety()
        {
            _wlasciel = "Nieznany";
            _saldo = 0;

            Console.WriteLine("Utworzono puste konto.");
        }
        public bankmonety(string nowywlasciciel, decimal startowesaldo);
         {
            _wlasciel = nowyWlasciciel;
             _saldo = startoweSaldo;
             Console.WriteLine($"Utworzone nowe konto dla: {_wlasciel} z saldem: {_saldo} PLN.");
        }
    public void Wplac(decimal kwota)
        {
            _saldo += kwota;
            Console.WriteLine($"Wpłacono: {kwota} PLN. Aktualny stan konta {_saldo} PLN.");
        }
        public void WyswietlInformacje()
        {
            Console.WriteLine($"Właściciel: {_wlasciel}");
            Console.WriteLine($"Stan konta: {_saldo} PLN");


        }
}
