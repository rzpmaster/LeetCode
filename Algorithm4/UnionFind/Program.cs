using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] resources = new int[,]
            {
                { 4, 3 },
                { 3, 8 },
                { 6, 5 },
                { 9, 4 },
                { 2, 1 },
                { 5, 0 },
                { 7, 2 },
                { 6, 1 },
            };

            UF uf = new UF(10);
            for (int i = 0; i < resources.GetLength(0); i++)
            {
                var p = resources[i, 0];
                var q = resources[i, 1];

                if (uf.Connected(p, q)) continue; // 如果已经连通则忽略
                uf.Union(p, q); // 归并分量

                uf.Show();
            }

            Console.WriteLine($"{uf.Count()} components.");
            Console.ReadKey();
        }
    }
}
