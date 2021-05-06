using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    abstract class Paths
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph">图</param>
        /// <param name="s">起点</param>
        public Paths(Graph graph, int s)
        {

        }

        /// <summary>
        /// 是否存在s到v的路径
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public abstract bool HasPathTo(int v);

        /// <summary>
        /// s到v的路径，不存在返回null
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public abstract IEnumerable<int> PathTo(int v);
    }


    class DepthFirstPaths : Paths
    {
        private bool[] marked;
        private int[] edgeTo;   // 前驱节点表
        private int s;          // 起点

        public DepthFirstPaths(Graph graph, int s) : base(graph, s)
        {
            this.marked = new bool[graph.Vertices()];
            this.edgeTo = new int[graph.Vertices()];
            this.s = s;
            dfs(graph, s);
        }

        private void dfs(Graph graph, int v)
        {
            marked[v] = true;
            foreach (var item in graph.Adj(v))
            {
                if (!marked[item])
                {
                    edgeTo[item] = v;   // 记录item的前驱节点为v
                    dfs(graph, item);
                }
            }
        }

        public override bool HasPathTo(int v)
        {
            return marked[v];
        }

        public override IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for (int i = v; i != s; i = edgeTo[i])
            {
                path.Push(i);
            }
            path.Push(s);
            return path;
        }
    }

    class BreadthFirstPaths : Paths
    {
        private bool[] marked;
        private int[] edgeTo;   // 前驱节点表
        private int s;          // 起点
        public BreadthFirstPaths(Graph graph, int s) : base(graph, s)
        {
            this.marked = new bool[graph.Vertices()];
            this.edgeTo = new int[graph.Vertices()];
            this.s = s;
            bfs(graph, s);
        }

        private void bfs(Graph graph, int s)
        {
            Queue<int> queue = new Queue<int>();
            marked[s] = true;
            queue.Enqueue(s);

            while (queue.Any())
            {
                int v = queue.Dequeue();
                foreach (var item in graph.Adj(v))
                {
                    if (!marked[item])
                    {
                        edgeTo[item] = v;   // 记录前驱节点
                        marked[item] = true;
                        queue.Enqueue(item);
                    }
                }
            }
        }

        public override bool HasPathTo(int v)
        {
            return marked[v];
        }

        public override IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for (int i = v; i != s; i = edgeTo[i])
            {
                path.Push(i);
            }
            path.Push(s);
            return path;
        }
    }
}
