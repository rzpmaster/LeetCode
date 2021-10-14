using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class RedBlackBST<TKey, TValue> where TKey : IComparable<TKey>
    {
        private static readonly bool RED = true;
        private static readonly bool BLACK = false;

        private Node root;
        private class Node
        {
            internal TKey key;
            internal TValue val;
            internal Node left, right;
            internal int N;
            internal bool color;

            public Node(TKey key, TValue value, int n, bool color)
            {
                this.key = key;
                this.val = value;
                this.N = n;
                this.color = color;
            }
        }

        private bool IsRed(Node x)
        {
            if (x == null)
            {
                return false;
            }

            return x.color == RED;
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

        private Node rotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = 1 + size(h.left) + size(h.right);
            return x;
        }

        private Node rotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = 1 + size(h.left) + size(h.right);
            return x;
        }

        private void flipColor(Node h)
        {
            h.color = RED;
            h.left.color = BLACK;
            h.right.color = BLACK;
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
            root.color = BLACK;
        }

        private Node put(Node h, TKey key, TValue value)
        {
            if (h == null)
            {
                return new Node(key, value, 1, RED);
            }

            int cmp = key.CompareTo(h.key);
            if (cmp < 0)
            {
                h.left = put(h.left, key, value);
            }
            else if (cmp > 0)
            {
                h.right = put(h.right, key, value);
            }
            else
            {
                h.val = value;
            }

            if (IsRed(h.right) && !IsRed(h.left))
            {
                h = rotateLeft(h);
            }
            if (IsRed(h.left) && h.right != null && IsRed(h.right.right))
            {
                h = rotateRight(h);
            }
            if (IsRed(h.left) && IsRed(h.right))
            {
                flipColor(h);
            }

            h.N = 1 + size(h.left) + size(h.right);
            return h;
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

        public TKey Max()
        {
            return max(root).key;
        }

        private Node max(Node x)
        {
            if (x.right == null)
            {
                return x;
            }

            return max(x.right);
        }

        public IEnumerable<TKey> Keys()
        {
            return Keys(Min(), Max());
        }

        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            Queue<TKey> queue = new Queue<TKey>();
            keys(root, queue, lo, hi);
            return queue;
        }

        private void keys(Node x, Queue<TKey> queue, TKey lo, TKey hi)
        {// 中序遍历
            if (x == null)
            {
                return;
            }

            int cmpLo = lo.CompareTo(x.key);
            int cmpHi = hi.CompareTo(x.key);
            if (cmpLo < 0)
            {//查找左子树
                keys(x.left, queue, lo, hi);
            }
            if (cmpLo <= 0 && cmpHi >= 0)
            {//当前节点
                queue.Enqueue(x.key);
            }
            if (cmpHi > 0)
            {//查找右子树
                keys(x.right, queue, lo, hi);
            }

        }
    }
}
