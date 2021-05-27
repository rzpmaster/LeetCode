using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeWeightedDigraph
{
    public class EdgeWeightedDigraph
    {
        private readonly int V;     // 顶点个数
        private int E;              // 边个数
        private List<DirectedEdge>[] adj;    // 邻接表

        public EdgeWeightedDigraph(int v)
        {
            this.V = v;
            this.E = 0;
            this.adj = new List<DirectedEdge>[v];
            for (int i = 0; i < Vertices(); i++)
            {
                adj[i] = new List<DirectedEdge>();
            }
        }

        public EdgeWeightedDigraph(List<double[]> edges, int v) : this(v)
        {
            edges.Reverse();
            foreach (var item in edges)
            {
                DirectedEdge edge = new DirectedEdge((int)item[0], (int)item[1], item[2]);
                this.AddEdge(edge);
            }
        }

        /// <summary>
        /// 顶点个数
        /// </summary>
        /// <returns></returns>
        public int Vertices()
        {
            return V;
        }

        /// <summary>
        /// 边个数
        /// </summary>
        /// <returns></returns>
        public int Edges()
        {
            return E;
        }

        /// <summary>
        /// 添加边
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        public void AddEdge(DirectedEdge edge)
        {
            adj[edge.From()].Add(edge);
            E++;
        }

        /// <summary>
        /// 和 v 相邻的所有顶点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<DirectedEdge> Adj(int v)
        {
            return adj[v];
        }

        /// <summary>
        /// 所有边
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DirectedEdge> EdgeList()
        {
            List<DirectedEdge> edges = new List<DirectedEdge>();
            for (int i = 0; i < Vertices(); i++)
            {
                foreach (var edge in Adj(i))
                {
                    edges.Add(edge);
                }
            }
            return edges;
        }
    }
}
