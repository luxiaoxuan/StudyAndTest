using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy
{
    public class SortAlgorithm
    {
        public static void QuickSort<T>(IList<T> array, int i, int j) where T : IComparable
        {
            if (i >= j)
            {
                return;
            }

            var key = array[i];
            var start = i;
            var end = j;
            Console.WriteLine((start + 1) + " ~ " + (end + 1) + " :");

            for (var n = j; j > i; j--)
            {
                if (array[j].CompareTo(key) < 0)
                {
                    do
                    {
                        i++;
                    }
                    while (array[i].CompareTo(key) <= 0 && i != j);

                    if (i == j)
                    {
                        break;
                    }

                    Swap(array, i, j);
                    //ShowArray(array);
                }
            }

            //do
            //{
            //    if (array[j].CompareTo(key) < 0)
            //    {
            //        i++;
            //        if (i < j)
            //        {
            //            Swap(array, i, j);
            //            ShowArray(array);
            //        }
            //    }
            //    else
            //    {
            //        j--;
            //    }
            //}
            //while (j > i);

            Swap(array, start, j);
            //ShowArray(array);

            QuickSort(array, start, j - 1);
            QuickSort(array, j + 1, end);
        }

        public static void ShowArray<T>(IList<T> array)
        {
            foreach (var u in array)
                Console.Write(u.ToString() + " ");
            Console.WriteLine();
        }


        private static void Swap<T>(IList<T> array, int a, int b)
        {
            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}