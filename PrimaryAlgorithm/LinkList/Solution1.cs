using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.LinkList
{
    class Solution1
    {
        /*
         给你单链表的头节点 head ，请你反转链表，并返回反转后的链表。
         */

        // 递归
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode next = head.next;
            ListNode reverse = ReverseList(next);
            // reverse 是反转之后的链表，next肯定是最后一个节点
            head.next = null;//将当前节点的后一个节点清空
            next.next = head;//将当前节点挂在 reverse 的最后一个节点的后面
            return reverse;
        }

        // 双链表
        public ListNode ReverseList2(ListNode head)
        {
            ListNode newHead = null;
            ListNode current = head;
            while (current != null)
            {
                ListNode temp = current.next;
                // 当前节点的后一个节点挂新链表（摘一个新节点，挂在新链表的前面）
                current.next = newHead;
                // 更新新链表
                newHead = current;

                current = temp;
            }
            return newHead;
        }
    }
}
