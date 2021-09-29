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
            TreeNode root = new TreeNode(array[0].Value);
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
                    current.left = new TreeNode(index++);
                    queue.Enqueue(current.left);
                    }
                if (index < array.Length)
                    {
                    current.right = new TreeNode(index++);
                    queue.Enqueue(current.right);
                    }

                }//end while
            return root;
            }
        }
    }
