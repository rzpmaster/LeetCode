using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class IndexPriorityQueue<TKey> where TKey : IComparable<TKey>
    {
        // 使用 pq[] 保存索引，添加一个数组 keys[] 来保存元素，再添加一个数组 qp[] 来保存 pq[] 的逆序——qp[i] 的值是 i 在 pq[] 中的位置（即索引 j，pq[j]=i）。

        // 若 i 不在队列之中，则总是令 qp[i] = -1 并添加一个方法 contains() 来检测这种情况。

        private int[] pq;   // 索引二叉堆
        private int[] qp;   // 索引逆序二叉堆：qp[pq[i]]=pq[qp[i]]=i
        private TKey[] keys;
        private int N;

        public IndexPriorityQueue(int max)
        {
            keys = new TKey[max + 1];

            pq = new int[max + 1];
            qp = new int[max + 1];
            for (int i = 0; i <= max; i++)
            {
                qp[i] = -1;
            }
        }

        public void Insert(int k, TKey key)
        {
            N++;
            qp[k] = N;
            pq[N] = k;
            keys[k] = key;
            Swim(N);
        }

        public void Change(int k, TKey key)
        {
            keys[k] = key;
            Swim(qp[k]);
            Sink(qp[k]);
        }

        public bool Contains(int k)
        {
            return qp[k] != -1;
        }

        public void Delete(int k)
        {
            int index = qp[k];
            Exchange(index, N--);
            Swim(index);
            Sink(index);
            keys[k] = default(TKey);
            qp[k] = -1;
        }

        public int DelMin()
        {
            int indexOfMin = pq[1];
            Exchange(1, N--);
            Sink(1);
            Debug.Assert(indexOfMin == pq[N + 1], "wrong");
            keys[pq[N + 1]] = default(TKey);
            qp[pq[N + 1]] = -1;
            pq[N + 1] = -1;
            return indexOfMin;
        }

        public TKey Min()
        {
            return keys[pq[1]];
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public int Size()
        {
            return N;
        }

        private void Swim(int k)
        {
            while (k > 1 && Greater(k / 2, k))
            {
                // 当一个节点 k 比他的父节点 k/2 还大时，交换它和它的父节点，
                // 直到遇到一个更大的父节点，或者已经到达顶部

                Exchange(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= N)  // 注意判断条件，是带等号的
            {
                int j = 2 * k;
                // j j+1 都是 k 的子节点
                if (j < N && Greater(j, j + 1))
                {
                    j++;    // 保证 j 指向两个子节点中较大的
                }
                // 如果 k 比 j 大，说明父节点大于比较小的子节点了，就不需要再下沉了
                if (!Greater(k, j))
                {
                    break;
                }
                // 否则，需要继续下沉
                Exchange(k, j);
                k = j;
            }
        }

        private bool Greater(int i, int j)
        {
            return keys[pq[i]].CompareTo(keys[pq[j]]) > 0;
        }

        private void Exchange(int i, int j)
        {
            int temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }
    }
}
