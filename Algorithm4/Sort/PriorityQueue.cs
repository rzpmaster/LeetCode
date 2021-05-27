using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class PriorityQueue<TKey> where TKey : IComparable<TKey>
    {
        private TKey[] pq;  // 注意 pq[0] 不使用
        private int N;

        public PriorityQueue()
        {

        }

        public PriorityQueue(int max)
        {
            pq = new TKey[max + 1];
        }

        public PriorityQueue(TKey[] a)
        {
            pq = new TKey[a.Length + 1];
            foreach (var item in a)
            {
                Insert(item);
            }
        }

        public void Insert(TKey v)
        {
            pq[++N] = v;
            Swim(N);
        }

        public TKey DeleteMax()
        {
            TKey max = Max();
            Exchange(1, N--);
            pq[N + 1] = default(TKey);
            Sink(1);
            return max;
        }

        public TKey Max()
        {
            return pq[1];
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
            while (k > 1 && Less(k / 2, k))
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
                if (j < N && Less(j, j + 1))
                {
                    j++;    // 保证 j 指向两个子节点中较大的
                }
                // 如果 k 比 j 大，说明父节点大于比较小的子节点了，就不需要再下沉了
                if (!Less(k, j))
                {
                    break;
                }
                // 否则，需要继续下沉
                Exchange(k, j);
                k = j;
            }
        }

        private bool Less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) > 0;
        }

        private void Exchange(int i, int j)
        {
            TKey temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
        }

    }
}
