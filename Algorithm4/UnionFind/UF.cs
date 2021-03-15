using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    class UF
    {
        private int[] ids;
        private int count;

        // 改良
        // （由触点索引的）各个根节点所对应的分量的大小
        private int[] size;

        /// <summary>
        /// 初始化0到n-1个触点
        /// </summary>
        /// <param name="n">触点个数</param>
        public UF(int n)
        {
            this.count = n;
            this.ids = new int[n];
            this.size = new int[n];
            for (int i = 0; i < ids.Length; i++)
            {
                ids[i] = i;
                size[i] = i;
            }
        }

        /// <summary>
        /// p(0到n-1之间)所在分量的标识符
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Find(int p)
        {
            while (p != ids[p]) p = ids[p];
            return p;
        }

        /// <summary>
        /// 在p和q之间添加链接
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i == j) return;

            // 随意连接
            //ids[i] = j;
            //count--;

            // 将小树的根节点连接到大树的根节点（加权）
            if (size[i] < size[j])
            {
                ids[i] = j;
                size[j] += size[i];
            }
            else
            {
                ids[j] = i;
                size[i] += size[j];
            }
            count--;
        }

        /// <summary>
        /// p和q是否连接
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// 返回分量个数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.count;
        }

        public void Show()
        {
            for (int i = 0; i < ids.Length; i++)
            {
                Console.Write(ids[i]);
                Console.Write("\t");
            }
            Console.WriteLine();
        }
    }
}
