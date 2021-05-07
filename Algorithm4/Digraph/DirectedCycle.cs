using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digraph
{
    class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> cycle;   // 存储找出的一个环
        private bool[] onStack;     // 递归调用栈上的所有顶点

        public DirectedCycle(Digraph digraph)
        {
            this.onStack = new bool[digraph.Vertices()];
            this.marked = new bool[digraph.Vertices()];
            this.edgeTo = new int[digraph.Vertices()];
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
            onStack[v] = true;
            marked[v] = true;
            foreach (var item in digraph.Adj(v))
            {
                if (this.HasCycle())
                {
                    return;
                }
                else if (!marked[item])
                {
                    edgeTo[item] = v;
                    dfs(digraph, item);
                }
                else if (onStack[item])
                {
                    // find cycle!
                    // ...item -> ... -> v ->item
                    cycle = new Stack<int>();
                    for (int i = v; i != item; i = edgeTo[i])
                    {
                        cycle.Push(i);
                    }
                    cycle.Push(item);
                    cycle.Push(v);
                }
            }
            onStack[v] = false;
        }

        public bool HasCycle()
        {
            return cycle != null;
        }

        public IEnumerable<int> Cycle()
        {
            return cycle;
        }
    }
}
