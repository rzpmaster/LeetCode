using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digraph
{
    class Digraph
    {
        private readonly int V;     // 顶点个数
        private int E;              // 边个数
        private List<int>[] adj;    // 邻接表

        public Digraph(int v)
        {
            this.V = v;
            this.E = 0;
            this.adj = new List<int>[v];
            for (int i = 0; i < Vertices(); i++)
            {
                adj[i] = new List<int>();
            }
        }

        public Digraph(List<int[]> edges, int v) : this(v)
        {
            edges.Reverse();
            foreach (var item in edges)
            {
                this.AddEdge(item[0], item[1]);
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
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            E++;
        }

        /// <summary>
        /// 和 v 相邻的所有顶点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }

        /// <summary>
        /// 反向图
        /// </summary>
        /// <returns></returns>
        public Digraph Reverse()
        {
            Digraph digraph = new Digraph(Vertices());
            for (int i = 0; i < Vertices(); i++)
            {
                foreach (var item in Adj(i))
                {
                    digraph.AddEdge(item, i);
                }
            }
            return digraph;
        }
    }
}
