using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digraph
{
    /// <summary>
    /// 拓扑排序
    /// </summary>
    /// <remarks>
    /// <para>一幅有向无环图的拓扑顺序即为所有顶点的逆后序排列</para>
    /// </remarks>
    class Topological
    {
        private IEnumerable<int> order;
        public Topological(Digraph digraph)
        {
            DirectedCycle directedCycle = new DirectedCycle(digraph);
            if (!directedCycle.HasCycle())
            {
                DepthFirstOrder dfs = new DepthFirstOrder(digraph);
                order = dfs.ReversePost();
            }
        }

        /// <summary>
        /// 是否为有向无环图
        /// </summary>
        /// <returns></returns>
        public bool IsDAG()
        {
            return order != null;
        }

        /// <summary>
        /// 拓扑排序
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Sort()
        {
            return order;
        }
    }

    class DepthFirstOrder
    {
        private bool[] marked;
        private Queue<int> pre;     // 前序排序
        private Queue<int> post;    // 后续排序
        private Stack<int> reversePost;     // 逆后续排序

        public DepthFirstOrder(Digraph digraph)
        {
            this.pre = new Queue<int>();
            this.post = new Queue<int>();
            this.reversePost = new Stack<int>();
            this.marked = new bool[digraph.Vertices()];

            for (int i = 0; i < digraph.Vertices(); i++)
            {
                if (!marked[i])
                {
                    dfs(digraph, i);
                }
            }
        }

        private void dfs(Digraph digraph, int v)
        {
            pre.Enqueue(v);

            marked[v] = true;
            foreach (var item in digraph.Adj(v))
            {
                if (!marked[item])
                {
                    dfs(digraph, item);
                }
            }

            post.Enqueue(v);
            reversePost.Push(v);
        }

        public IEnumerable<int> Pre()
        {
            return pre;
        }

        public IEnumerable<int> Post()
        {
            return post;
        }

        public IEnumerable<int> ReversePost()
        {
            return reversePost;
        }
    }
}
