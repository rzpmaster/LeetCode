using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digraph
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestSearch();

            TestSCC();

            Console.ReadLine();
        }

        private static void TestSCC()
        {
            var edges = new List<int[]>
            {
                new int[2]{4,2},
                new int[2]{2,3},
                new int[2]{3,2},
                new int[2]{6,0},
                new int[2]{0,1},
                new int[2]{2,0},
                new int[2]{11,12},
                new int[2]{12,9},
                new int[2]{9,10},
                new int[2]{9,11},
                new int[2]{8,9},
                new int[2]{10,12},
                new int[2]{11,4},
                new int[2]{4,3},
                new int[2]{3,5},
                new int[2]{7,8},
                new int[2]{8,7},
                new int[2]{5,4},
                new int[2]{0,5},
                new int[2]{6,4},
                new int[2]{6,9},
                new int[2]{7,6},
            };
            Digraph digraph = new Digraph(edges, 13);

            StrongConnectedComponent scc = new KosarajuSCC(digraph);
            Console.WriteLine($"强联通分量个数:{scc.Count()}");

            for (int i = 0; i < digraph.Vertices(); i++)
            {
                Console.WriteLine($"{i}:{scc.Id(i)}");
            }
        }

        private static void TestSearch()
        {
            var edges = new List<int[]>
            {
                new int[2]{4,2},
                new int[2]{2,3},
                new int[2]{3,2},
                new int[2]{6,0},
                new int[2]{0,1},
                new int[2]{2,0},
                new int[2]{11,12},
                new int[2]{12,9},
                new int[2]{9,10},
                new int[2]{9,11},
                new int[2]{8,9},
                new int[2]{10,12},
                new int[2]{11,4},
                new int[2]{4,3},
                new int[2]{3,5},
                new int[2]{7,8},
                new int[2]{8,7},
                new int[2]{5,4},
                new int[2]{0,5},
                new int[2]{6,4},
                new int[2]{6,9},
                new int[2]{7,6},
            };
            Digraph digraph = new Digraph(edges, 13);

            Search search = new DirectedDFS(digraph, new List<int> { 1, 2, 6 });
            for (int i = 0; i < digraph.Vertices(); i++)
            {
                if (search.Marked(i))
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();

        }
    }
}
