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
            //TestSolution1();
            TestSolution2();
            }

        private static void TestSolution2()
            {
            Solution2 solution2 = new Solution2();
            int[] prices = { 7,1,5,3,6,4 };
            var result = solution2.MaxProfit(prices);
            }

        private static void TestSolution1()
            {
            Solution1 solution1 = new Solution1();
            int[] nums = { 1, 1, 2 };
            var result = solution1.RemoveDuplicates(nums);
            }
        }
    }
