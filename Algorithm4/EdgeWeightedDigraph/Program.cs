using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeWeightedDigraph
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDijkstra();

            Console.ReadLine();
        }

        private static void TestDijkstra()
        {
            var edges = new List<double[]>
            {
                new double[3]{4,5,0.35},
                new double[3]{5,4,0.35},
                new double[3]{4,7,0.37},
                new double[3]{5,7,0.28},
                new double[3]{7,5,0.28},
                new double[3]{5,1,0.32},
                new double[3]{0,4,0.38},
                new double[3]{0,2,0.26},
                new double[3]{7,3,0.39},
                new double[3]{1,3,0.29},
                new double[3]{2,7,0.34},
                new double[3]{6,2,0.4},
                new double[3]{3,6,0.52},
                new double[3]{6,0,0.58},
                new double[3]{6,4,0.93},
            };
            EdgeWeightedDigraph digraph = new EdgeWeightedDigraph(edges, 8);
        }
    }
}
