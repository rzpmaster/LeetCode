﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayTest1();
            //ArrayTest2();
            //ArrayTest3();
            //ArrayTest4();

            //TreeTest1();
            //TreeTest2();
            //TreeTest3();

            //SortTest1();
            //SortTest2();

            //LinkListTest1();
            //LinkListTest2();
            LinkListTest3();
        }

        private static void LinkListTest3()
        {
            int[] nums = { 1, 2 };
            var solution = new LinkList.Solution3();
            var result = solution.HasCycle(LinkList.LinkListHelp.BuildLinkList(nums));
        }

        private static void LinkListTest2()
        {
            int[] nums = { 1, 2, 2, 1 };
            var solution = new LinkList.Solution2();
            //var result = solution.IsPalindrome(LinkList.LinkListHelp.BuildLinkList(nums));
            var result = solution.IsPalindrome_Std(LinkList.LinkListHelp.BuildLinkList(nums));
        }

        private static void LinkListTest1()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            var solution = new LinkList.Solution1();
            var node = solution.ReverseList(LinkList.LinkListHelp.BuildLinkList(nums));
            //var node = solution.ReverseList2(LinkList.LinkListHelp.BuildLinkList(nums));
            var result = LinkList.LinkListHelp.ToArray(node);
        }

        private static void SortTest2()
        {
            var solution = new Sort.Solution2();
            var result = solution.FirstBadVersion(5);
        }

        private static void SortTest1()
        {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = { 2, 5, 6 };
            var solution = new Sort.Solution1();
            solution.Merge(nums1, 3, nums2, 3);
        }

        private static void TreeTest3()
        {
            var solution = new Tree.Solution5();
            int[] nums = { -10, -3, 0, 5, 9 };
            var result = solution.SortedArrayToBST(nums);
        }

        private static void TreeTest2()
        {
            var solution = new Tree.Solution3();
            int?[] nums = { 2, 3, 3, 4, 5, 5 };
            var root = Tree.TreeHelper.BuildTree(nums);
            var result = solution.IsSymmetric(root);
        }

        private static void TreeTest1()
        {
            var solution = new Tree.Solution2();
            int?[] nums = { 1, 1 };
            var root = Tree.TreeHelper.BuildTree(nums);
            var result = solution.IsValidBST_Std(root);
        }

        private static void ArrayTest4()
        {
            var solution = new Array.Solution4();
            var result = solution.Intersect(new int[] { 1, 2, 3 }, new int[] { 3, 4, 5 });
        }

        private static void ArrayTest3()
        {
            var solution = new Array.Solution3();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            solution.Rotate(nums, k);
            solution.Rotate_Std2(nums, k);
        }

        private static void ArrayTest2()
        {
            var solution = new Array.Solution2();
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            var result = solution.MaxProfit(prices);
        }

        private static void ArrayTest1()
        {
            var solution = new Array.Solution1();
            int[] nums = { 1, 1, 2 };
            var result = solution.RemoveDuplicates(nums);
        }
    }
}
