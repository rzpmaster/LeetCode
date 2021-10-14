using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.LinkList
{
    /*
     给你一个单链表的头节点 head ，请你判断该链表是否为回文链表。如果是，返回 true ；否则，返回 false 。

     这题是让判断链表是否是回文链表，所谓的回文链表就是以链表中间为中心点两边对称。我们常见的有判断一个字符串是否是回文字符串，这个比较简单，可以使用两个指针，一个最左边一个最右边，两个指针同时往中间靠，判断所指的字符是否相等。

        但这题判断的是链表，因为这里是单向链表，只能从前往后访问，不能从后往前访问，所以使用判断字符串的那种方式是行不通的。
         */
    class Solution2
    {
        public bool IsPalindrome(ListNode head)
        {
            // 找到中间
            ListNode fast = head, slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            if (fast != null)
            {//说明是奇数个
                slow = slow.next;
            }

            slow = Reverse(slow);
            fast = head;
            while (slow != null)
            {
                if (slow.val != fast.val)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next;
            }

            return true;
        }

        private ListNode Reverse(ListNode node)
        {
            if (node == null || node.next == null)
            {
                return node;
            }
            ListNode next = node.next;
            ListNode reverse = Reverse(next);
            // reverse的最后一个必是next
            next.next = node;//reverse的最后一个节点挂上当前节点，并把当前节点的后一个清空
            node.next = null;
            return reverse;
        }

        private ListNode front;//必须是全局变量，否则递归途中无法更新
        // 递归
        public bool IsPalindrome_Std(ListNode head)
        {
            front = head;
            ListNode last = head;
            return isPalindrome(last);
        }

        private bool isPalindrome(ListNode last)
        {
            if (last != null)
            {
                // 递归压栈，
                if (!isPalindrome(last.next))
                {
                    return false;
                }

                // 开始弹栈
                if (last.val != front.val)
                {
                    return false;
                }

                front = front.next;
            }
            return true;
        }
    }
}
