using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Sort
            var list = RandomNums(10000);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            {
                //Sort.SelectionSort(list);   // 870
                //Sort.InsertionSort(list);   // 1100
                //Sort.ShellSort(list);       // 8
                //Sort.MergeSort(list);       // 580
                //Sort.QuickSort(list);       // 5
                Sort.HeapSort(list);        // 8
            }
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            if (Sort.IsSorted(list))
            {
                Console.WriteLine("OK");
            }
            #endregion

            #region PriorityQueue
            //List<char> cl1 = new List<char> { 'a', 'b', 'c', 'f', 'g', 'i', 'i', 'z' };
            //List<char> cl2 = new List<char> { 'b', 'd', 'h', 'p', 'q', 'q' };
            //List<char> cl3 = new List<char> { 'a', 'b', 'e', 'f', 'j', 'n' };
            //MergeList(cl1, cl2, cl3);
            #endregion

            Console.ReadLine();
        }

        private static void MergeList(params List<char>[] args)
        {
            int N = args.Length;
            IndexPriorityQueue<char> pq = new IndexPriorityQueue<char>(N);

            for (int i = 0; i < N; i++)
            {
                if (args[i].Count > 0)
                {
                    pq.Insert(i, args[i][0]);
                    args[i].RemoveAt(0);
                }
            }

            while (!pq.IsEmpty())
            {
                var min = pq.Min();
                int i = pq.DelMin();

                Console.WriteLine(min + " from " + i);

                if (args[i].Count > 0)
                {
                    pq.Insert(i, args[i][0]);
                    args[i].RemoveAt(0);
                }
            }
        }

        static IComparable[] RandomNums(int count)
        {
            IComparable[] list = new IComparable[count];
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                list[i] = random.Next(0, count);
            }
            return list;
        }

        static void Show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i].ToString());
                Console.Write("\t");
            }
            Console.WriteLine();
        }
    }
}
