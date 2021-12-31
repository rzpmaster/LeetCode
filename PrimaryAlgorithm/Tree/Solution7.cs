using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Tree
{
    class Solution7
    {
        /*
     给定一棵树的前序遍历 preorder 与中序遍历  inorder。请构造二叉树并返回其根节点。

     preorder 和 inorder 均无重复元素
     inorder 均出现在 preorder
     preorder 保证为二叉树的前序遍历序列
     inorder 保证为二叉树的中序遍历序列
         */

        // 中序 前 根 后
        // 前续 根 前 后 
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder == null || !inorder.Any())
            {
                return null;
            }

            int length = inorder.Length;

            return dfs(preorder, inorder, 0, length - 1, 0, length - 1);
        }

        /*
                                3

                            9       20
                        
                                15      7
             
             
             */

        // preorder     3   9   20  15  7
        // inorder      9   3   15  20  7
        private TreeNode dfs(int[] preorder, int[] inorder, int head_pre, int tail_pre, int head_in, int tail_in)
        {
            if (head_pre > tail_pre)
            {
                return null;
            }

            // 前序遍历，第一个就是根节点
            int val = preorder[head_pre];
            TreeNode root = new TreeNode(val);

            if (head_pre == tail_pre)
            {
                return root;
            }

            // 中序遍历的特殊性：可以根据根节点区分左右子树
            int mid = 0;
            while (inorder[head_in + mid] != val)
            {
                mid++;
            }

            // 左子树  preorder  : head_pre+1,head_pre+mid
            //         inoder    : head_in,head_in+mid-1
            root.left = dfs(preorder, inorder, head_pre + 1, head_pre + mid, head_in, head_in + mid - 1);

            // 右子树  preorder  : head_pre+mid+1,tail_pre
            //         inoder    : head_in+mid+1,tail_in
            root.right = dfs(preorder, inorder, head_pre + mid + 1, tail_pre, head_in + mid + 1, tail_in);

            // 注意：inorder 每次排除的是中间节点，postorder 每次排除的是最前的节点

            return root;
        }
    }
}
