using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm
    {
    /*
     * 给定一个数组 prices ，其中 prices[i] 是一支给定股票第 i 天的价格。

设计一个算法来计算你所能获取的最大利润。你可以尽可能地完成更多的交易（多次买卖一支股票）。
     */
    class Solution2
        {
        public int MaxProfit(int[] prices)
            {
            if (prices == null || prices.Length <= 1)
                {
                return 0;
                }

            return GetIncome(prices, prices.Length);
            }

        private int GetIncome(int[] prices, int len)
            {
            if (len <= 1)
                {
                return 0;
                }

            int diff = prices[prices.Length - len + 1] - prices[prices.Length - len];

            return diff > 0 ? diff + GetIncome(prices, len - 1) : GetIncome(prices, len - 1);
            }

        // 动态规划
        public int MaxProfit_Std(int[] prices)
            {
            if (prices == null || prices.Length < 2)
                return 0;
            int length = prices.Length;
            int[,] dp = new int[length, 2];
            //初始条件
            dp[0, 1] = -prices[0];//买了股票
            dp[0, 0] = 0;//没买股票
            for (int i = 1; i < length; i++)
                {
                //递推公式
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
                }
            //最后一天肯定是手里没有股票的时候，利润才会最大，
            //只需要返回dp[length - 1][0]即可
            return dp[length - 1, 0];

            }

        // 贪心
        public int MaxProfit_Std2(int[] prices)
            {
            int ans = 0;
            int n = prices.Length;
            for (int i = 1; i < n; ++i)
                {
                ans += Math.Max(0, prices[i] - prices[i - 1]);
                }
            return ans;
            }
        }
    }
