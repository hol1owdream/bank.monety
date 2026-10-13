using System;
using System.Collections.Generic;
using System.Text;

namespace bank.monety
{
    internal class Automat
    {
        private int _iloscMonet;

        // stworz metode wrzucmonete
        public void wrzucmonete(bankmonety konto, decimal wartoscmonet)
        {
            _iloscMonet++;
            konto.saldo += wartoscmonet;
        }
        Console.WriteLine($"moneta wrzucona {wartoscmonet}");
}


}

    }
}
