using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmStudy;

namespace AlgorithmStudyTest
{
    [TestClass]
    public class SortAlgorithmTest
    {
        /// <summary>
        /// テストメソッドのコメント
        /// </summary>
        [TestMethod]
        public void QuickSortTest()
        {
            // 変数定義
            var target = new int[] { 7, 6, 9, 1, 8, 4, 2, 3, 5, };
            var expectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, };

            SortAlgorithm.QuickSort(target, 0, target.Length - 1);

            CollectionAssert.AreEqual(target, expectedResult);
        }
    }
}
