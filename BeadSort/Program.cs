using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeadSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            BeadSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        //Сложность O(n) или O(sqrt(n)), 
        public static void BeadSort(int[] data)
        {
            int i, j, max, sum;
            byte[] beads;

            for (i = 1, max = data[0]; i < data.Length; ++i)
                if (data[i] > max)
                    max = data[i];

            beads = new byte[max * data.Length];

            for (i = 0; i < data.Length; ++i)
                for (j = 0; j < data[i]; ++j)
                    beads[i * max + j] = 1;

            for (j = 0; j < max; ++j)
            {
                for (sum = i = 0; i < data.Length; ++i)
                {
                    sum += beads[i * max + j];
                    beads[i * max + j] = 0;
                }

                for (i = data.Length - sum; i < data.Length; ++i)
                    beads[i * max + j] = 1;
            }

            for (i = 0; i < data.Length; ++i)
            {
                for (j = 0; j < max && Convert.ToBoolean(beads[i * max + j]); ++j) ;
                data[i] = j;
            }
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
