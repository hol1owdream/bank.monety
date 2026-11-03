using System;
using System.Collections.Generic;
using System.Text;

namespace bank.monety
{
    internal class bankmonety
    {
        private decimal _saldo;
        private string _numer; // generowany automatycznie przy tworzeniu konta

        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
    }
}
