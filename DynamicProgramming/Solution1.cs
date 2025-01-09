using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    /*
     *假设你正在爬楼梯。需要 n 阶你才能到达楼顶。

每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
     *
     */

    // 递推公式 f(n)=f(n-1)+f(n-2)
    // 为啥？
    /*
     * n个台阶不管什么走法，最后一步要么是走1个台阶，要么是走2个台阶。最后一步是1个台阶的话，前面n-1个台阶有f(n-1)种走法，最后一步是2个台阶的话，前面n-2个台阶有f(n-2)种走法，
     * ∴f(n)=f(n-1)+f(n-2)
     * */

    internal class Solution1
    {
        public static void Run()
        {
            Solution1 solution1 = new Solution1();
            int result = solution1.ClimbStairs(45);
            Console.WriteLine(result);
        }

        public int ClimbStairs(int n)
        {
            // 这个不是动态规划
            //if (n == 0) return 0;
            //if (n == 1) return 1;
            //if (n == 2) return 2;
            //return ClimbStairs(n - 1) + ClimbStairs(n - 2);


            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
    }
}
