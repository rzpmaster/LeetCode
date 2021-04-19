using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class DepthFirstSearch
    {
        private bool[] marked;
        private int count;

        public DepthFirstSearch(Graph graph, int source)
        {
            this.marked = new bool[graph.Vertices()];
            dfs(graph, source);
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

        public int Count()
        {
            return count;
        }

        public bool Marked(int v)
        {
            return marked[v];
        }
    }

    class DepthFirstSearchPaths
    {
        private bool[] marked;
        private int[] edgeTo;   // 从起点到一个顶点的已知路径上的最后一个顶点
        private int source;

        public DepthFirstSearchPaths(Graph graph, int source)
        {
            this.marked = new bool[graph.Vertices()];
            this.edgeTo = new int[graph.Vertices()];
            this.source = source;
            dfs(graph, source);
        }
        public DepthFirstSearchPaths(Graph graph, int source, bool model3)
        {
            this.marked = new bool[graph.Vertices()];
            this.edgeTo = new int[graph.Vertices()];
            this.source = source;
            dfs3(graph, source);
        }


        private void dfs(Graph graph, int v)
        {
            marked[v] = true;
            foreach (var item in graph.Adj(v))
            {
                if (!marked[item])
                {
                    edgeTo[item] = v;
                    dfs(graph, item);
                }
            }
        }

        private void dfs3(Graph graph, int v)
        {
            Stack<int> queue = new Stack<int>();
            queue.Push(v);
            while (queue.Count != 0)
            {
                int current = queue.Pop();
                if (!marked[current])
                {
                    marked[current] = true;
                    foreach (var item in graph.Adj(current))
                    {
                        if (!marked[item])
                        {
                            edgeTo[item] = current;
                            queue.Push(item);
                        }
                    }
                }

            }//end while
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            Stack<int> path = new Stack<int>();
            if (!HasPathTo(v))
            {
                return path;
            }

            for (int x = v; x != source; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(source);
            return path;
        }
    }

    class BreadthFirstSearchPaths
    {
        private bool[] marked;
        private int[] edgeTo;   // 从起点到一个顶点的一致路径上的最后一个顶点
        private int source;

        public BreadthFirstSearchPaths(Graph graph, int source)
        {
            this.marked = new bool[graph.Vertices()];
            this.edgeTo = new int[graph.Vertices()];
            this.source = source;
            bfs(graph, source);
        }

        private void bfs(Graph graph, int v)
        {
            Queue<int> queue = new Queue<int>();
            marked[v] = true;
            queue.Enqueue(v);
            while (queue.Count != 0)
            {
                int current = queue.Dequeue();
                foreach (var item in graph.Adj(current))
                {
                    if (!marked[item])
                    {
                        edgeTo[item] = current;
                        marked[item] = true;
                        queue.Enqueue(item);
                    }
                }
            }//end while
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            Stack<int> path = new Stack<int>();
            if (!HasPathTo(v))
            {
                return path;
            }

            for (int x = v; x != source; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(source);
            return path;
        }
    }
}
