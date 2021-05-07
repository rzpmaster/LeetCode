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
    /// <remarks>
    /// <para>有向图 G 的传递闭包是由相同的一组顶点组成的另一幅有向图，
    /// 在传递闭包中存在一条从 v 指向 w 的边当且仅当在 G 中 w 是从 v 可达的。</para>
    /// <para>一般来说，一幅有向图的传递闭包中所含的边都比原图中多得多，
    /// 一幅稀疏图的传递闭包却是一幅稠密图也是很常见的</para>
    /// <para>因为传递闭包一般都很稠密，我们通常都将它们表示为一个布尔值矩阵，
    /// 其中 v 行 w 列的值为 true 当且仅当 w 是从v 可达的</para>
    /// <para>本质上，TransitiveClosure 通过计算 G 的传递闭包来支持常数时间的查询——传递闭包矩阵中的第 v 行就是 TransitiveClosure 类中的 DirectedDFS[]数组的第 v 个元素的 marked[] 数组。</para>
    /// </remarks>
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
