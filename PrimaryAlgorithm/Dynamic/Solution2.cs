using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Dynamic
{
    class Solution2
    {
        /*
         给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。
         */
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i], nums[i] + dp[i - 1]);
            }

            return dp.Max();
        }
    }
}
