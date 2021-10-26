using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Dynamic
{
    class Solution1
    {
        /*
         给定一个数组 prices ，它的第 i 个元素 prices[i] 表示一支给定股票第 i 天的价格。

你只能选择 某一天 买入这只股票，并选择在 未来的某一个不同的日子 卖出该股票。设计一个算法来计算你所能获取的最大利润。

返回你可以从这笔交易中获取的最大利润。如果你不能获取任何利润，返回 0 。
         */
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            int[,] dp = new int[prices.Length, 2];

            // base case
            dp[0, 0] = -prices[0];  //持有
            dp[0, 1] = 0;           //不持有

            // do select
            for (int i = 1; i < prices.Length; i++)
            {
                // 持有
                // 错误只能买卖一次
                //dp[i, 0] = Math.Max(
                //    dp[i - 1, 0],                   // 前一天持有，今天持有，相当于今天未操作，等于前一天持有的收益 
                //    dp[i - 1, 1] - prices[i]);      // 前一天不持有，今天持有，相当于今天买入，等于前一天不持有的收益减去今天的价格
                dp[i, 0] = Math.Max(
                    dp[i - 1, 0],                   // 前一天持有，今天持有，相当于今天未操作，等于前一天持有的收益 
                    -prices[i]);                    // 前一天不持有，今天持有，相当于今天买入，只能买卖一次的话，等于-今天的价格
                // 不持有
                dp[i, 1] = Math.Max(
                    dp[i - 1, 0] + prices[i],       // 前一天持有，今天不持有，相当于今天卖出，等于前一天持有的收益加上今天的价格
                    dp[i - 1, 1]                    // 前一天不持有，今天不持有，相当于今天未操作，等于前一天不持有的收益
                    );
            }

            return dp[prices.Length - 1, 1];
        }

    }
}
