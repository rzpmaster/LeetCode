using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Tree
{
    class Solution3
    {
        /*
         给定一个二叉树，检查它是否是镜像对称的。
         */
        public bool IsSymmetric(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                int count = queue.Count;
                Stack<int> stack = new Stack<int>();
                Stack<bool> stack2 = new Stack<bool>();
                for (int i = 0; i < count; i++)
                {// 一层,并且节点都不为空
                    var current = queue.Dequeue();
                    if (!PushStack(stack2, current == null, i, count == 1 ? 1 : count / 2)) return false;
                    if (current == null)
                    {
                        continue;
                    }
                    if (!PushStack(stack, current.val, i, count == 1 ? 1 : count / 2)) return false;
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }

            }

            return true;
        }

        private bool PushStack<T>(Stack<T> stack, T val, int index, int count) where T : IComparable<T>
        {
            if (index < count)
            {
                stack.Push(val);
                return true;
            }
            else
            {
                return val.CompareTo(stack.Pop()) == 0;
            }
        }

        public bool IsSymmetric_Std(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            return IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if (left == null)
            {
                return false;
            }
            if (right == null)
            {
                return false;
            }

            // all not null
            return IsSymmetric(left.left, left.right) && IsSymmetric(right.left, right.right);
        }
    }
}
