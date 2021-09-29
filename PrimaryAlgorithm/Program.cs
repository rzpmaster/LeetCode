using System;
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
            }

        private static void ArrayTest4()
            {
            var solution4 = new Array.Solution4();
            var result = solution4.Intersect(new int[] { 1, 2, 3 }, new int[] { 3, 4, 5 });
            }

        private static void ArrayTest3()
            {
            var solution3 = new Array.Solution3();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            solution3.Rotate(nums, k);
            solution3.Rotate_Std2(nums, k);
            }

        private static void ArrayTest2()
            {
            var solution2 = new Array.Solution2();
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            var result = solution2.MaxProfit(prices);
            }

        private static void ArrayTest1()
            {
            var solution1 = new Array.Solution1();
            int[] nums = { 1, 1, 2 };
            var result = solution1.RemoveDuplicates(nums);
            }
        }
    }
