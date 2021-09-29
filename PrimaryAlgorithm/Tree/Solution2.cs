using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Tree
    {
    class Solution2
        {
        /*
         给你一个二叉树的根节点 root ，判断其是否是一个有效的二叉搜索树。

        有效 二叉搜索树定义如下：
        
        节点的左子树只包含 小于 当前节点的数。
        节点的右子树只包含 大于 当前节点的数。
        所有左子树和右子树自身必须也是二叉搜索树。
             */
        public bool IsValidBST(TreeNode root)
            {
            return IsValidNode(root, long.MinValue, long.MaxValue);
            }
        private bool IsValidNode(TreeNode node, long min, long max)
            {
            if (node == null)
                {
                return true;
                }
            if (node.val <= min || node.val >= max)
                {
                return false;
                }
            return IsValidNode(node.left, min, node.val) && IsValidNode(node.right, node.val, max);
            }

        // 中序遍历
        public bool IsValidBST_Std(TreeNode root)
            {
            Stack<long> stack = new Stack<long>();
            return IsValidNode(root, stack);
            }

        private bool IsValidNode(TreeNode node, Stack<long> stack)
            {
            if (node == null)
                {
                return true;
                }
            if (!IsValidNode(node.left, stack))
                {
                return false;
                }
            if (stack.Any())
                {
                var pre = stack.Pop();
                if (pre < node.val)
                    {
                    return true;
                    }
                stack.Push(node.val);
                }
            if (!IsValidNode(node.right, stack))
                {
                return false;
                }
            return true;
            }
        }
    }
