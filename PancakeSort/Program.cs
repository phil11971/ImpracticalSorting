using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            PancakeSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        public static void PancakeSort(int[] arr)
        {
            for (int curr_size = arr.Length; curr_size > 1; curr_size--)
            {
                int mi = FindMax(arr, curr_size);

                if (mi != curr_size - 1)
                {
                    Flip(arr, mi);
                    Flip(arr, curr_size - 1);
                }
            }
        }

        private static int FindMax(int[] arr, int n)
        {
            int mi, i;
            for (mi = 0, i = 0; i < n; i++)
                if (arr[i] > arr[mi])
                    mi = i;

            return mi;
        }

        private static void Flip(int[] arr, int i)
        {
            int temp, start = 0;
            while (start < i)
            {
                temp = arr[start];
                arr[start] = arr[i];
                arr[i] = temp;
                start++;
                i--;
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
