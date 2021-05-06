using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestSearch();

            //TestPaths();

            TestConnectedComponent();

            Console.ReadLine();
        }

        private static void TestConnectedComponent()
        {
            var edges = new List<int[]>
            {
                new int[2]{0,5},
                new int[2]{4,3},
                new int[2]{0,1},
                new int[2]{9,12},
                new int[2]{6,4},
                new int[2]{5,4},
                new int[2]{0,2},
                new int[2]{11,12},
                new int[2]{9,10},
                new int[2]{0,6},
                new int[2]{7,8},
                new int[2]{9,11},
                new int[2]{5,3},
            };
            Graph graph = new Graph(edges, 13);

            ConnectedComponent cc = new ConnectedComponent(graph);
            var count = cc.Count();
            Console.WriteLine($"{count} components");

            List<int>[] components = new List<int>[count];
            for (int i = 0; i < count; i++)
            {
                components[i] = new List<int>();
            }
            for (int i = 0; i < graph.Vertices(); i++)
            {
                components[cc.Id(i)].Add(i);
            }

            for (int i = 0; i < count; i++)
            {
                foreach (var item in components[i])
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        private static void TestPaths()
        {
            var edges = new List<int[]>
            {
                new int[2]{0,5},
                new int[2]{2,4},
                new int[2]{2,3},
                new int[2]{1,2},
                new int[2]{0,1},
                new int[2]{3,4},
                new int[2]{3,5},
                new int[2]{0,2},
            };
            Graph graph = new Graph(edges, 6);

            int s = 0;
            //Paths paths = new DepthFirstPaths(graph, 0);
            Paths paths = new BreadthFirstPaths(graph, 0);
            for (int i = 0; i < graph.Vertices(); i++)
            {
                Console.Write($"{s} to {i}:");
                if (paths.HasPathTo(i))
                {
                    var path = paths.PathTo(i);
                    foreach (var item in path)
                    {
                        if (item == s)
                        {
                            Console.Write(item);
                        }
                        else
                        {
                            Console.Write($"-{item}");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        private static void TestSearch()
        {
            var edges = new List<int[]>
            {
                new int[2]{0,5},
                new int[2]{4,3},
                new int[2]{0,1},
                new int[2]{9,12},
                new int[2]{6,4},
                new int[2]{5,4},
                new int[2]{0,2},
                new int[2]{11,12},
                new int[2]{9,10},
                new int[2]{0,6},
                new int[2]{7,8},
                new int[2]{9,11},
                new int[2]{5,3},
            };

            Graph graph = new Graph(edges, 13);

            //Search search = new DepthFirstSearch(graph, 9);
            Search search = new BreadthFirstSearch(graph, 9);
            for (int i = 0; i < graph.Vertices(); i++)
            {
                if (search.Marked(i))
                {
                    Console.Write(i + "\t");
                }
            }
            Console.WriteLine();

            if (search.Count() != graph.Vertices())
            {
                Console.Write("NOT ");
            }
            Console.WriteLine("connected.");
        }
    }
}
