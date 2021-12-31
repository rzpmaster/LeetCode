using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Tree
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    /*
     填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。

初始状态下，所有 next 指针都被设置为 NULL。
*/
    class Solution8
    {
        public Node ConvertTo(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            Node node = new Node();
            node.val = root.val;
            node.left = ConvertTo(root.left);
            node.right = ConvertTo(root.right);
            return node;
        }

        public Node Connect(TreeNode root)
        {
            return Connect(ConvertTo(root));
        }

        public Node Connect(Node root)
        {
            if (root == null)
            {
                return root;
            }

            // BFS
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    Node current = queue.Dequeue();
                    current.next = i + 1 < count ? queue.Peek() : null;
                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }
                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }
            }
            return root;
        }

        public Node Connect_Std(Node root)
        {
            Dfs(root, null);
            return root;
        }

        private void Dfs(Node node, Node next)
        {
            if (node == null)
            {
                return;
            }
            node.next = next;
            Dfs(node.left, node.right);
            Dfs(node.right, node.next == null ? null : node.next.left);
        }
    }
}
