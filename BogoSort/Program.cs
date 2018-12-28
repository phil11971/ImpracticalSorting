using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogoSort
{
    class Program
    {
        private static Random rnd;

        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            mas = BogoSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        //Сложность O(n*n!) в среднем
        public static int[] BogoSort(int[] array)
        {
            while (!IsSorted(array))
                Shuffle(array);

            return array;
        }

        public static void Shuffle(int[] array)
        {
            if (rnd == null) rnd = new Random();

            for (int i = 0; i < array.Length; i++)
                Swap(array, i, rnd.Next(0, array.Length - 1));
        }

        private static void Swap(int[] array, int item1, int item2)
        {
            int temp = array[item1];
            array[item1] = array[item2];
            array[item2] = temp;
        }

        private static bool IsSorted(int[] array)
        {
            bool ret = true;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if ( ((IComparable)array[i]).CompareTo((IComparable)array[i + 1]) == 1)
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
