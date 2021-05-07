using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    /// <summary>
    /// 连通分量
    /// </summary>
    class ConnectedComponent
    {
        private bool[] marked;
        private int[] id;
        private int count;
        public ConnectedComponent(Graph graph)
        {
            this.marked = new bool[graph.Vertices()];
            this.id = new int[graph.Vertices()];
            for (int i = 0; i < graph.Vertices(); i++)
            {
                if (!marked[i])
                {
                    dfs(graph, i);
                    count++;    // 从某个顶点出发，遍历所有与它连接的顶点后，连通分量数加1
                }
            }
        }

        private void dfs(Graph graph, int v)
        {
            marked[v] = true;
            id[v] = count;  // 记录v所属的连通分量id
            foreach (var item in graph.Adj(v))
            {
                if (!marked[item])
                {
                    dfs(graph, item);
                }
            }
        }

        public bool Connected(int v, int w)
        {
            return id[v] == id[w];
        }

        /// <summary>
        /// 联通分量标识
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int Id(int v)
        {
            return id[v];
        }

        /// <summary>
        /// 联通分量个数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count;
        }
    }
}
