using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    /*
     *给你一个整数数组 cost ，其中 cost[i] 是从楼梯第 i 个台阶向上爬需要支付的费用。一旦你支付此费用，即可选择向上爬一个或者两个台阶。

你可以选择从下标为 0 或下标为 1 的台阶开始爬楼梯。

请你计算并返回达到楼梯顶部的最低花费。

    示例 1：

输入：cost = [10,15,20]
输出：15
解释：你将从下标为 1 的台阶开始。
- 支付 15 ，向上爬两个台阶，到达楼梯顶部。
总花费为 15 。
示例 2：

输入：cost = [1,100,1,1,1,100,1,1,100,1]
输出：6
解释：你将从下标为 0 的台阶开始。
- 支付 1 ，向上爬两个台阶，到达下标为 2 的台阶。
- 支付 1 ，向上爬两个台阶，到达下标为 4 的台阶。
- 支付 1 ，向上爬两个台阶，到达下标为 6 的台阶。
- 支付 1 ，向上爬一个台阶，到达下标为 7 的台阶。
- 支付 1 ，向上爬两个台阶，到达下标为 9 的台阶。
- 支付 1 ，向上爬一个台阶，到达楼梯顶部。
总花费为 6 。
 
     *
     * */

    internal class Solution2
    {
        public static void Run()
        {
            Solution2 solution = new Solution2();
            //int result = solution.MinCostClimbingStairs([10, 15, 20]);
            int result = solution.MinCostClimbingStairs([1, 100, 1, 1, 1, 100, 1, 1, 100, 1]);
            Console.WriteLine(result);
        }


        // 2 <= cost.length <= 1000
        public int MinCostClimbingStairs(int[] cost)
        {
            int[] dp = new int[cost.Length + 1];
            // dp表 表示到达下标的位置时需要的花费
            // 需要注意的时，dp[n]并不是n阶台阶的最小花费，他代表到达最后一个台阶所需要的花费，最小花费有可能是到达倒数第二个台阶然后跨两个台阶上去
            // 所以n阶台阶的最小化非是 min(dp[n],dp[n-1])

            dp[0] = 0;
            dp[1] = cost[0];
            for (int i = 2; i <= cost.Length; i++)
            {
                // 跨越2步到达i， 跨越1步到达i
                dp[i] = Math.Min(dp[i - 2] + cost[i - 1], dp[i - 1] + cost[i - 1]);
            }

            return Math.Min(dp[cost.Length], dp[cost.Length - 1]);
        }
    }
}
