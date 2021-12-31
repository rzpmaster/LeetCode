using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Tree
{
    class Solution10
    {
        /*
         
// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
             
             */

        public class Codec
        {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                if (root == null)
                {
                    return string.Empty;
                }

                // 层序遍历
                List<String> result = new List<string>();

                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Any())
                {
                    TreeNode current = queue.Dequeue();
                    if (current == null)
                    {
                        result.Add("null");
                    }
                    else
                    {
                        result.Add(current.val.ToString());
                        queue.Enqueue(current.left);
                        queue.Enqueue(current.right);
                    }
                }

                return string.Join(",", result.ToArray());

            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                if (string.IsNullOrEmpty(data))
                {
                    return null;
                }

                // builder tree
                List<String> array = data.Split(',').ToList();
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

                    // 先挂左边
                    if (index < array.Count)//保证不越界
                    {
                        current.left = CreateNode(array[index++]);
                        queue.Enqueue(current.left);
                    }

                    // 再挂右边
                    if (index < array.Count)//保证不越界
                    {
                        current.right = CreateNode(array[index++]);
                        queue.Enqueue(current.right);
                    }

                }//end while
                return root;
            }

            private TreeNode CreateNode(string val)
            {
                if (string.IsNullOrEmpty(val))
                {
                    return null;
                }
                if (val == "null")
                {
                    return null;
                }
                if (int.TryParse(val, out int number))
                {
                    return new TreeNode(number);
                }
                return null;
            }
        }
    }
}
