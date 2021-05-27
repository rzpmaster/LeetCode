using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeWeightedDigraph
{
    public class DirectedEdge
    {
        private int v;
        private int w;
        private double weight;
        public DirectedEdge(int v,int w,double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public double Weight()
        {
            return weight;
        }

        public int From()
        {
            return v;
        }

        public int To()
        {
            return w;
        }

        public override string ToString()
        {
            return $"{v}->{w} {weight.ToString("f2")}";
        }
    }
}
