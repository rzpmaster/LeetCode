using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class TreeHelper
    {
        public static TreeNode BuildTree(int?[] array)
        {
            if (array == null || array.Length == 0 || array[0] == null)
            {
                return null;
            }
            TreeNode root = CreateNode(array[0]);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int index = 1;
            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (current == null)
                {
                    continue;
                }
                if (index < array.Length)
                {
                    current.left = CreateNode(array[index++]);
                    queue.Enqueue(current.left);
                }
                if (index < array.Length)
                {
                    current.right = CreateNode(array[index++]);
                    queue.Enqueue(current.right);
                }

            }//end while
            return root;
        }

        public static TreeNode BuildTree(int[] array)
        {
            int?[] nums = new int?[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                nums[i] = array[i];
            }
            return BuildTree(nums);
        }

        private static TreeNode CreateNode(int? val)
        {
            if (val == null)
            {
                return null;
            }
            return new TreeNode(val.Value);
        }
    }
}
