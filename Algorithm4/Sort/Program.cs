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
            var list = RandomNums(10000);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            {
                //Sort.SelectionSort(list);   // 1116
                //Sort.InsertionSort(list);   // 1333
                //Sort.ShellSort(list);       // 10
                //Sort.MergeSort(list);       // 791
                //Sort.QuickSort(list);       // 5
            }
            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            if (Sort.IsSorted(list))
            {
                Console.WriteLine("OK");
            }

            Console.ReadLine();
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
