using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Tree
{
    class Solution4
    {
        /*
         层序遍历
         */
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                int count = queue.Count;
                IList<int> layer = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    var current = queue.Dequeue();
                    if (current == null)
                    {
                        continue;
                    }
                    layer.Add(current.val);
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
                if (layer.Any()) result.Add(layer);
            }
            return result;
        }
    }
}
