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
        /// 稳定
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
        /// 不稳定
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

        /// <summary>
        /// O(N^3/2)
        /// 本质上就是插入排序，不稳定
        /// </summary>
        /// <param name="a"></param>
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
        /// 稳定
        /// </summary>
        /// <param name="a"></param>
        public static void MergeSort(IComparable[] a)
        {
            IComparable[] aux = new IComparable[a.Length];  // 一次申明数组，避免在递归中申明
            MergeSort(a, aux, 0, a.Length - 1);
        }

        #region MergeSort

        private static void MergeSort(IComparable[] a, IComparable[] aux, int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            int mid = lo + (hi - lo) / 2;   // 防止溢出
            MergeSort(a, aux, lo, mid);
            MergeSort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
        }

        private static void Merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {
            // 两侧指针
            int i = lo, j = mid + 1;

            for (int k = 0; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {// 左边用光了，用右边的，右边指针前进
                    a[k] = aux[j++];
                }
                else if (j > hi)
                {// 右边用光了，有左边的，左边指针前进
                    a[k] = aux[i++];
                }
                else if (Less(aux[j], aux[i]))
                {// 两边都没用光，谁小用谁，用谁谁指针前进
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
            }
        }

        #endregion

        /// <summary>
        /// O(nlogn)
        /// 不稳定
        /// </summary>
        /// <param name="a"></param>
        public static void QuickSort(IComparable[] a)
        {
            QuickSort(a, 0, a.Length - 1);
        }

        #region QuickSort

        private static void QuickSort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            int j = Partition(a, lo, hi);
            QuickSort(a, lo, j - 1);
            QuickSort(a, j + 1, hi);
        }

        private static int Partition(IComparable[] a, int lo, int hi)
        {
            // 两侧指针
            int i = lo, j = hi + 1;

            // 切分元素
            IComparable v = a[lo];

            while (true)
            {
                // 依次扫描左右，检查扫描是否结束并交换元素

                while (Less(a[++i], v))
                {
                    if (i == hi)
                    {// 防止越界
                        break;
                    }
                }

                while (Less(v, a[--j]))
                {
                    if (j == lo)
                    {// 防止越界
                        break;
                    }
                }

                // 如果指针没有相遇，则需要继续循环交换
                // 当指针相遇时，说明以v为切分点，左侧都小于v，右侧都大于v
                // 而此时，v所在的切分点索引正好为j

                if (i >= j)
                {
                    break;
                }
                else
                {
                    Exchange(a, i, j);  // 交换后可以保证左指针左侧都比v小，右指针右侧都比v大，继续循环
                }
            }

            Exchange(a, lo, j);     // 将v = a[j]放入正确的位置

            return j;
        }

        #endregion

        /// <summary>
        /// O(nlogn)
        /// 不稳定
        /// </summary>
        /// <param name="a"></param>
        public static void HeapSort(IComparable[] a)
        {
            int N = a.Length;

            // heapify phase
            for (int k = N / 2; k >= 1; k--)
            {
                Sink(a, k, N);
            }

            // sortdown phase
            while (N > 1)
            {
                Exchange(a, 1 - 1, N-- - 1);
                Sink(a, 1, N);
            }
        }

        #region HeapSort

        private static void Sink(IComparable[] a, int k, int N)
        {
            // 为了不使用额外空间，利用数组第一个元素
            // 以下所有 比较 和 交换 都应该在 优先队列 的基础上减一
            while (2 * k <= N)
            {
                int j = 2 * k;
                // j j+1 都是 k 的子节点
                if (j < N && Less(a[j - 1], a[j + 1 - 1]))
                {
                    j++;    // 保证 j 指向两个子节点中较大的
                }
                // 如果 k 比 j 大，说明父节点大于比较小的子节点了，就不需要再下沉了
                if (!Less(a[k - 1], a[j - 1]))
                {
                    break;
                }
                // 否则，需要继续下沉
                Exchange(a, k - 1, j - 1);
                k = j;
            }
        }

        #endregion

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
