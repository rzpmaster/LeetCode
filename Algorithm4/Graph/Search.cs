using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    abstract class Search
    {
        public Search(Graph graph, int s)
        {

        }

        /// <summary>
        /// v 和 s 是联通的吗
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public abstract bool Marked(int v);

        /// <summary>
        /// 和 s 联通的顶点个数
        /// </summary>
        /// <returns></returns>
        public abstract int Count();
    }

    class DepthFirstSearch : Search
    {
        private bool[] marked;
        private int count;

        public DepthFirstSearch(Graph graph, int s) : base(graph, s)
        {
            this.marked = new bool[graph.Vertices()];
            dfs(graph, s);
        }

        private void dfs(Graph graph, int v)
        {
            marked[v] = true;
            count++;
            foreach (var item in graph.Adj(v))
            {
                if (!marked[item])
                {
                    dfs(graph, item);
                }
            }
        }

        public override int Count()
        {
            return count;
        }

        public override bool Marked(int v)
        {
            return marked[v];
        }
    }
}
