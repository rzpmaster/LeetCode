using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeWeightedGraph
{
    public class EdgeWeightedGraph
    {
        private readonly int V;     // 顶点个数
        private int E;              // 边个数
        private List<Edge>[] adj;    // 邻接表

        public EdgeWeightedGraph(int v)
        {
            this.V = v;
            this.E = 0;
            this.adj = new List<Edge>[v];
            for (int i = 0; i < Vertices(); i++)
            {
                adj[i] = new List<Edge>();
            }
        }

        public EdgeWeightedGraph(List<double[]> edges, int v) : this(v)
        {
            foreach (var item in edges)
            {
                Edge edge = new Edge((int)item[0], (int)item[1], item[2]);
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
        public void AddEdge(Edge edge)
        {
            int v = edge.Either();
            int w = edge.Other(v);
            adj[v].Add(edge);
            adj[w].Add(edge);
            E++;
        }

        /// <summary>
        /// 和 v 相邻的所有顶点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<Edge> Adj(int v)
        {
            return adj[v];
        }

        /// <summary>
        /// 所有边
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Edge> EdgeList()
        {
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < Vertices(); i++)
            {
                foreach (var edge in Adj(i))
                {
                    if (edge.Other(i) > i)
                    {
                        edges.Add(edge);
                    }
                }
            }
            return edges;
        }
    }
}
