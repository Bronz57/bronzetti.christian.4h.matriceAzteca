using System;
using bronzetti.christian._4h.matriceAzteca.Models;

namespace bronzetti.christian._4h.matriceAzteca
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 91; //test 1, se è maggiore del range previsto reimposta ad un valore predefinito
            Matrice matriceAzteca1 = new Matrice(n);
            matriceAzteca1.DisegnaMatriceAzteca();
            Console.WriteLine($"{matriceAzteca1}\n\n");

            n = 6;
            Matrice matriceAzteca2 = new Matrice(n);
            matriceAzteca2.DisegnaMatriceAzteca();
            Console.WriteLine($"{matriceAzteca2}\n\n");

        }
    }
}
