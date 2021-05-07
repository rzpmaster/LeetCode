using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digraph
{
    /// <summary>
    /// 传递闭包解决有向图顶点对的可达性
    /// </summary>
    class TransitiveClosure
    {
        private DirectedDFS[] all;
        public TransitiveClosure(Digraph digraph)
        {
            this.all = new DirectedDFS[digraph.Vertices()];
            for (int i = 0; i < digraph.Vertices(); i++)
            {
                all[i] = new DirectedDFS(digraph, i);
            }
        }

        public bool Reachable(int v, int w)
        {
            return all[v].Marked(w);
        }
    }
}
