using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph
    {
        private readonly int V;     // 顶点个数
        private int E;              // 边个数
        private List<int>[] adj;    // 邻接表

        public Graph(int v)
        {
            this.V = v;
            this.E = 0;
            this.adj = new List<int>[v];
            for (int i = 0; i < Vertices(); i++)
            {
                adj[i] = new List<int>();
            }
        }

        public Graph(List<int[]> edges, int v) : this(v)
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
            adj[w].Add(v);
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Vertices()} vertices,{Edges()} edges.");
            for (int i = 0; i < Vertices(); i++)
            {
                sb.Append($"{i}:");
                foreach (var item in Adj(i))
                {
                    sb.Append($"{item} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }


        public static int Degree(Graph graph, int v)
        {
            int degree = 0;
            for (int i = 0; i < graph.Adj(v).Count(); i++)
            {
                degree++;
            }
            return degree;
        }

        public static int MaxDegree(Graph graph)
        {
            int max = 0;
            for (int i = 0; i < graph.Vertices(); i++)
            {
                var degree = Degree(graph, i);
                if (max < degree)
                {
                    max = degree;
                }
            }
            return max;
        }

        public static double AvgDegree(Graph graph)
        {
            return 2.0 * graph.Edges() / graph.Vertices();
        }

        public static int NumberOfSelfLoops(Graph graph)
        {
            int count = 0;
            for (int i = 0; i < graph.Vertices(); i++)
            {
                foreach (var item in graph.Adj(i))
                {
                    if (item == i)
                    {
                        count++;
                    }
                }
            }
            return count / 2;   // 每条边被计算了两遍
        }
    }
}
