using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Tree
{
    class Solution6
    {
        /*
         根据一棵树的中序遍历 inorder 与后序遍历 postorder 构造二叉树。

注意:
你可以假设树中没有重复的元素。
*/
        // 中序 前 根 后
        // 后续 前 后 根
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (postorder == null || !postorder.Any())
            {
                return null;
            }

            int length = inorder.Length;

            return dfs(inorder, postorder, 0, length - 1, 0, length - 1);
        }

        /*
                                3

                            9       20
                        
                                15      7
             
             
             */

        // inorder      9   3   15  20  7
        // postorder    9   15  7   20  3
        private TreeNode dfs(int[] inorder, int[] postorder, int head_in, int tail_in, int head_post, int tail_post)
        {
            if (head_in > tail_post)
            {
                return null;
            }

            // 后序遍历，最后一个就是根节点
            int val = postorder[tail_post];
            TreeNode root = new TreeNode(val);

            if (head_post == tail_post)
            {
                return root;
            }

            // 中序遍历的特殊性：可以根据根节点区分左右子树
            int mid = 0;
            while (inorder[head_in + mid] != val)
            {
                mid++;
            }

            // 左子树  inorder     : head_in,head_in+mid-1
            //         postorder   : head_post,head_post+mid-1 
            root.left = dfs(inorder, postorder, head_in, head_in + mid - 1, head_post, head_post + mid - 1);

            // 右子树  inoder      : head_in+mid+1,tail_in
            //         postorder   : head_post+mid,tail_post-1
            root.right = dfs(inorder, postorder, head_in + mid + 1, tail_in, head_post + mid, tail_post - 1);

            // 注意：inorder 每次排除的是中间节点，postorder 每次排除的是最后的节点

            return root;
        }
    }
}
