using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.LinkList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LinkListHelp
    {
        public static ListNode BuildLinkList(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return null;
            }
            ListNode root = new ListNode(array[0]);
            ListNode current = root;
            for (int i = 1; i < array.Length; i++)
            {
                ListNode node = new ListNode(array[i]);
                current.next = node;
                current = node;
            }
            return root;
        }

        public static int[] ToArray(ListNode node)
        {
            if (node == null)
            {
                return new int[] { };
            }
            List<int> result = new List<int>();
            ListNode current = node;
            while (current != null)
            {
                result.Add(current.val);
                current = current.next;
            }
            return result.ToArray();
        }
    }
}
