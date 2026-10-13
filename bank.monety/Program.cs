using System.Runtime.InteropServices;

namespace bank.monety
{
    internal class Program
    {
        static void Main(string[] args)
        {
          bankmonety kontobankowe = new bankmonety();//tworzenie konta
            
            Automat automat = new Automat(kontobankowe);//tworzenie automatu
            automat.wrzucmonete(kontobankowe, "0,5");

            Console.WriteLine(kontobankowe.stankonta());//wyświetlenie stanu konta





















        }
    }
}
