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
            Queue<long> queue = new Queue<long>();
            long pre = long.MinValue;
            return MidTravel(root, ref pre);
        }

        private bool MidTravel(TreeNode node, ref long preValue)
        {
            if (node == null)
            {
                return true;
            }

            //MidTravel(node.left, queue);
            //queue.Enqueue(node.val);
            //MidTravel(node.right, queue);

            if (!MidTravel(node.left, ref preValue)) return false;

            if (preValue < node.val)
            {
                preValue = node.val;
            }
            else
            {
                return false;
            }

            if (!MidTravel(node.right, ref preValue)) return false;

            return true;
        }
    }
}
