using System;

namespace bank.monety
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KontoBankowe kontoPierwsze = new KontoBankowe();
            KontoBankowe kontoDrugie = new KontoBankowe();
            Automat automat = new Automat();

            automat.WrzucMonete(kontoPierwsze, "5");
            automat.WrzucMonete(kontoPierwsze, "0.50");
            automat.WrzucMonete(kontoPierwsze, "2");
            automat.WrzucMonete(kontoPierwsze, "3");
            automat.WrzucMonete(kontoPierwsze, "kqw");

            Console.WriteLine();
            Console.WriteLine($"Stan pierwszego konta: {kontoPierwsze.StanKonta():0.00} zł");
            Console.WriteLine($"Numer pierwszego konta: {kontoPierwsze.NumerKonta}");
            Console.WriteLine($"Numer drugiego konta: {kontoDrugie.NumerKonta}");
            Console.WriteLine($"Numery są różne: {kontoPierwsze.NumerKonta != kontoDrugie.NumerKonta}");

            Console.WriteLine();
            automat.PokazMonety();
        }
    }
}