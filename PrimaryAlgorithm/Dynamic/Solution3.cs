using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Dynamic
{
    class Solution3
    {
        /*
         你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。

给定一个代表每个房屋存放金额的非负整数数组，计算你 不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。
         */
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            int[,] dp = new int[nums.Length, 2];
            dp[1, 0] = nums[1]; //最后一家偷了
            dp[1, 1] = nums[0]; //最后一家没偷
            for (int i = 2; i < nums.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 1] + nums[i];
                dp[i, 1] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
            }

            return Math.Max(dp[nums.Length - 1, 0], dp[nums.Length - 1, 1]);
        }

    }
}
