using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class BST<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node root;
        private class Node
        {
            internal TKey key;
            internal TValue val;
            internal Node left, right;
            internal int N;

            public Node(TKey key, TValue value, int n)
            {
                this.key = key;
                this.val = value;
                this.N = n;
            }
        }

        public int Size()
        {
            return size(root);
        }

        private int size(Node x)
        {
            if (x == null)
            {
                return 0;
            }

            return x.N;
        }

        public TValue Get(TKey key)
        {
            return get(root, key);
        }

        private TValue get(Node x, TKey key)
        {
            if (x == null)
            {
                return default(TValue);
            }

            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                return get(x.left, key);
            }
            else if (cmp > 0)
            {
                return get(x.right, key);
            }

            return x.val;
        }

        public void Put(TKey key, TValue value)
        {
            root = put(root, key, value);
        }

        private Node put(Node x, TKey key, TValue value)
        {
            if (x == null)
            {
                return new Node(key, value, 1);
            }

            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                x.left = put(x.left, key, value);
            }
            else if (cmp > 0)
            {
                x.right = put(x.right, key, value);
            }
            else
            {
                x.val = value;
            }

            x.N = size(x.left) + size(x.right) + 1;
            return x;
        }

        public TKey Min()
        {
            return min(root).key;
        }

        private Node min(Node x)
        {
            if (x.left == null)
            {
                return x;
            }

            return min(x.left);
        }

        public TKey Floor(TKey key)
        {
            var node = floor(root, key);
            if (node == null)
            {
                return default(TKey);
            }
            return node.key;
        }

        private Node floor(Node x, TKey key)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
            {
                return x;
            }
            else if (cmp < 0)
            {
                return floor(x.left, key);
            }
            else /* if (cmp > 0)*/
            {
                Node tmp = floor(x.right, key);
                if (tmp != null)
                {
                    return tmp;
                }
                return x;
            }
        }

        public TKey Select(int k)
        {
            return select(root, k).key;
        }

        private Node select(Node x, int k)
        {// 返回排名为k的节点
            if (x == null)
            {
                return null;
            }

            int tmp = size(x.left);
            if (tmp == k)
            {
                return x;
            }
            else if (tmp > k)
            {
                return select(x.left, k);
            }
            else /* if (tmp < k)*/
            {
                return select(x.right, k - tmp - 1);
            }
        }

        public int Rank(TKey key)
        {
            return rank(root, key);
        }

        private int rank(Node x, TKey key)
        {// 返回以x为根节点的子树中小于x.key的键的个数
            if (x == null)
            {
                return 0;
            }

            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
            {
                return size(x.left);
            }
            else if (cmp < 0)
            {
                return rank(x.left, key);
            }
            else /* if (cmp > 0)*/
            {
                return 1 + size(x.left) + rank(x.right, key);
            }
        }
    }
}
