using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Sort
    {
        /// <summary>
        /// O(n^2)
        /// </summary>
        /// <param name="a"></param>
        public static void SelectionSort(IComparable[] a)
        {
            int N = a.Length; // 数组长度
            for (int i = 0; i < N; i++)
            { // 将a[i]和a[i+1..N]中最小的元素交换
                int min = i; // 最小元素的索引
                for (int j = i + 1; j < N; j++)
                {
                    if (Less(a[j], a[min])) min = j;
                }
                Exchange(a, i, min);
            }
        }

        /// <summary>
        /// O(n^2)
        /// </summary>
        /// <param name="a"></param>
        public static void InsertionSort(IComparable[] a)
        {
            int N = a.Length; // 数组长度
            for (int i = 0; i < N; i++)
            { // 将 a[i] 插入到 a[i-1]、a[i-2]、a[i-3]...之中
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                {
                    Exchange(a, j, j - 1);
                }
            }
        }

        public static void ShellSort(IComparable[] a)
        {
            int N = a.Length;
            int h = 1;
            while (h < N / 3) h = 3 * h + 1; // 1, 4, 13, 40, 121, 364, 1093, ...
            while (h >= 1)
            { // 将数组变为h有序
                for (int i = h; i < N; i++)
                { // 将a[i]插入到a[i-h], a[i-2*h], a[i-3*h]... 之中
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                    {
                        Exchange(a, j, j - h);
                    }
                }
                h = h / 3;
            }
        }

        /// <summary>
        /// O(nlogn)
        /// </summary>
        /// <param name="a"></param>
        public static void MergeSort(IComparable[] a)
        {

        }

        public static void QuickSort(IComparable[] a)
        {

        }

        public static void HeapSort(IComparable[] a)
        {

        }

        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        private static void Exchange(IComparable[] a, int i, int j)
        {
            IComparable temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static bool IsSorted(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
