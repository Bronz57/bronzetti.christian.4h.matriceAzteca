using System;
using System.Collections.Generic;
using System.Text;

namespace bronzetti.christian._4h.matriceAzteca.Models
{
   
    class Matrice
    {
        const int LIMITE_MINIMO = 1;
        const int LIMITE_MASSIMO = 30;
        const int VALORE_PREDEFINITO = 10;
        int _n;
        int[,] _matrix = new int[30, 30];

        public Matrice(int n)
        {

            if (n < LIMITE_MINIMO - 1 || n > LIMITE_MASSIMO)
            {
                _n = VALORE_PREDEFINITO;
                _matrix = (int[,])ResizeArray(_matrix, new int[] { _n, _n });  //se non è nel range predefinito ridimensiona la matrice ad un valore predefinito
            }    
            else
                _n = n;


           
        }

        public Matrice() { }

        public int N
        {
            get => _n;

            set 
            {
                if (value < LIMITE_MINIMO - 1 || value > LIMITE_MASSIMO + 1) //se il numero esce dal range indicato assegno valore predefinito
                    _n = 10;
                else
                    _n = value;
            }
        }

        public int [,] Matrix
        {
            get => _matrix;

            set => _matrix = value;
        }

        public void DisegnaMatriceAzteca()
        {
            int i, j;

            int k = 1; //contatore che va a popolare la matrice (inizia da 1)
            int giro = 0; //variabile che permette un incremento dei giri (cornici)

            //popolamento matrice secondo schema delle cornici concentriche
            for (giro = 0; giro <= _n / 2; giro++)
            { //giri fino a n/2
                for (i = giro; i < _n - giro; i++)
                    for (j = giro; j < _n - giro; j++)
                        if (i == giro ||
                            j == giro ||
                            i == _n - (giro + 1) ||
                            j == _n - (giro + 1)
                            ) //controllo se è la cornice cioè il perimetro della matrice
                            Matrix[i, j] = k;
                k++; //incremento cornice ogni giro
            }
        }

        public override string ToString()
        {
            string ris = "";
            
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    ris += $"\t{Matrix[i, j]}";

                }
                ris += "\n\n";
            }

            return ris;
        }
        private static Array ResizeArray(Array arr, int[] newSizes) //metodo per ridimensionare la matrice. credit: https://docs.microsoft.com/it-it/dotnet/api/system.array.resize?view=net-5.0
        {
            if (newSizes.Length != arr.Rank)
                throw new ArgumentException("arr must have the same number of dimensions " +
                                            "as there are elements in newSizes", "newSizes");

            var temp = Array.CreateInstance(arr.GetType().GetElementType(), newSizes);
            int length = arr.Length <= temp.Length ? arr.Length : temp.Length;
            Array.ConstrainedCopy(arr, 0, temp, 0, length);
            return temp;
        }
    }
}
