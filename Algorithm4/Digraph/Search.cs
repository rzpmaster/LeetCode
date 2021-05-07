using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digraph
{
    abstract class Search
    {
        public abstract bool Marked(int v);
    }

    class DirectedDFS : Search
    {
        private bool[] marked;

        /// <summary>
        /// 找出从s可达的点
        /// </summary>
        /// <param name="digraph"></param>
        /// <param name="s"></param>
        public DirectedDFS(Digraph digraph, int s)
        {
            this.marked = new bool[digraph.Vertices()];
            dfs(digraph, s);
        }

        /// <summary>
        /// 找出从sources中的所有顶点都可达的点
        /// </summary>
        /// <param name="digraph"></param>
        /// <param name="sources"></param>
        public DirectedDFS(Digraph digraph, IEnumerable<int> sources)
        {
            this.marked = new bool[digraph.Vertices()];
            foreach (var item in sources)
            {
                if (!marked[item])
                {
                    dfs(digraph, item);
                }
            }
        }

        private void dfs(Digraph digraph, int v)
        {
            marked[v] = true;
            foreach (var item in digraph.Adj(v))
            {
                if (!marked[item])
                {
                    dfs(digraph, item);
                }
            }
        }

        public override bool Marked(int v)
        {
            return marked[v];
        }
    }
}
