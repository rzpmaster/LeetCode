using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digraph
{
    /// <summary>
    /// 强联通分量
    /// </summary>
    abstract class StrongConnectedComponent
    {
        public abstract bool StronglyConnected(int v, int w);

        /// <summary>
        /// 强连通分量个数
        /// </summary>
        /// <returns></returns>
        public abstract int Count();

        /// <summary>
        /// 联通分量标识
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public abstract int Id(int v);
    }

    /// <summary>
    /// Kosaraju 算法
    /// </summary>
    /// <remarks>
    /// <para>先计算反向图的逆后续排序</para>
    /// <para>深度优先搜索该图，顺序为上一步排序的顺序，依次访问未被标记的顶点</para>
    /// <para>构造函数中，同一次递归调用的dfs中的所有顶点位于同一个强联通分量中</para>
    /// </remarks>
    class KosarajuSCC : StrongConnectedComponent
    {
        private bool[] marked;
        private int[] id;
        private int count;

        public KosarajuSCC(Digraph digraph)
        {
            this.marked = new bool[digraph.Vertices()];
            this.id = new int[digraph.Vertices()];

            DepthFirstOrder order = new DepthFirstOrder(digraph.Reverse());
            foreach (var item in order.ReversePost())
            {
                if (!marked[item])
                {
                    dfs(digraph, item);
                    count++;
                }
            }
        }

        private void dfs(Digraph digraph, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (var item in digraph.Adj(v))
            {
                if (!marked[item])
                {
                    dfs(digraph, item);
                }
            }
        }

        public override int Count()
        {
            return count;
        }

        public override int Id(int v)
        {
            return id[v];
        }

        public override bool StronglyConnected(int v, int w)
        {
            return id[v] == id[w];
        }
    }
}
