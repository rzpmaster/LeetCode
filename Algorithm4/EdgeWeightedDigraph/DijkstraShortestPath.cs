using Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeWeightedDigraph
{
    public class DijkstraShortestPath
    {
        private DirectedEdge[] edgeTo;
        private double[] distTo;
        private PriorityQueue<Double> pq;

        public DijkstraShortestPath(EdgeWeightedDigraph digraph, int s)
        {
            edgeTo = new DirectedEdge[digraph.Vertices()];
            distTo = new double[digraph.Vertices()];
            pq = new PriorityQueue<double>(digraph.Vertices());

            for (int i = 0; i < digraph.Vertices(); i++)
            {
                distTo[i] = double.PositiveInfinity;
            }
            distTo[s] = 0;
        }

        private void Relax(DirectedEdge edge)
        {
            int v = edge.From();
            int w = edge.To();
            if (distTo[w] > distTo[v] + edge.Weight())
            {
                distTo[w] = distTo[v] + edge.Weight();
                edgeTo[w] = edge;
            }
        }
    }
}
