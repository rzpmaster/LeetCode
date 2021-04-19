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
            Graph graph = new Graph(6);
            graph.AddEdge(0, 5);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(1, 2);
            graph.AddEdge(0, 1);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(0, 2);

            Console.WriteLine(graph.ToString());

            DepthFirstSearchPaths depthFirstSearchPaths = new DepthFirstSearchPaths(graph, 0);
            var path = depthFirstSearchPaths.PathTo(2);

            DepthFirstSearchPaths depthFirstSearchPaths2 = new DepthFirstSearchPaths(graph, 0, true);
            var path2 = depthFirstSearchPaths2.PathTo(5);


            Console.ReadLine();
        }
    }
}
