using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var tar =
                new int[] { 7, 6, 9, 1, 8, 4, 2, 3, 5, };
            //new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, };

            SortAlgorithm.ShowArray(tar);
            SortAlgorithm.QuickSort(tar, 0, tar.Length - 1);
            Console.Read();
        }
    }
}
