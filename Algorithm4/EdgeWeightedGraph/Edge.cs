using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeWeightedGraph
{
    public class Edge : IComparable<Edge>
    {
        private int v;
        private int w;
        private double weight;
        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public double Weight()
        {
            return weight;
        }

        public int Either()
        {
            return v;
        }

        public int Other(int vertex)
        {
            if (vertex == v)
            {
                return w;
            }
            else if (vertex == w)
            {
                return v;
            }
            else
            {
                throw new InvalidOperationException("Inconsistent edge");
            }
        }

        public override string ToString()
        {
            return $"{v}-{w} {weight.ToString("f2")}";
        }

        public int CompareTo(Edge other)
        {
            if (this.Weight() < other.Weight())
            {
                return -1;
            }
            else if (this.Weight() > other.Weight())
            {
                return +1;
            }
            else
            {
                return 0;
            }
        }
    }
}
