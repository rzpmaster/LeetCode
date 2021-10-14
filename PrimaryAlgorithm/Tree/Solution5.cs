using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Tree
{
    class Solution5
    {
        /*
         给你一个整数数组 nums ，其中元素已经按 升序 排列，请你将其转换为一棵 高度平衡 二叉搜索树。

        高度平衡 二叉树是一棵满足「每个节点的左右两个子树的高度差的绝对值不超过 1 」的二叉树。

            nums 按 严格递增 顺序排列
             */
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return null;
            }

            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBST(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            if (start == end)
            {
                return new TreeNode(nums[start]);
            }
            int mid = (end - start) / 2 + start;
            TreeNode node = new TreeNode(nums[mid]);
            node.left = SortedArrayToBST(nums, start, mid - 1);
            node.right = SortedArrayToBST(nums, mid + 1, end);
            return node;
        }
    }
}
