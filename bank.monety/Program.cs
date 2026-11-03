using System;

namespace bank.monety
{
    internal class Program
    {
            static void Main(string[] args)
            {
                // Tworzenie konta
                bankmonety kontoBankowe = new bankmonety();
                bankmonety kontoBankowe2 = new bankmonety();
                bankmonety kontoBankowe3 = new bankmonety();
            // Tworzenie automatu do wpłat
            Automat automat = new Automat();

                automat.WrzucMonete(kontoBankowe, "5");
                automat.WrzucMonete(kontoBankowe, "0.5");


            // Wyświetlamy stan konta (jeszcze nie zrobione)
            //    Console.WriteLine(kontoBankowe.Saldo);
        }
        }
    }










