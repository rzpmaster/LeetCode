using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class PriorityQueue<TKey> where TKey : IComparable<TKey>
    {
        private TKey[] pq;
        private int n = 0;

        public PriorityQueue(int maxN)
        {
            pq = new TKey[maxN + 1];
        }

        public bool IsEmpty()
        {
            return n == 0;
        }

        public int Size()
        {
            return n;
        }

        public void Insert(TKey v)
        {
            pq[++n] = v;
            Swim(n);
        }

        //public TKey DeleteMax()
        //{
        //    TKey max = pq[1];

        //}

        private void Swim(int n)
        {
            throw new NotImplementedException();
        }
    }
}
