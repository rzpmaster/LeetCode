using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offer65
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var rst = solution.Add(9, 13);

            Console.WriteLine(rst);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int Add(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;

            int plus1 = a ^ b;          //不计进位求和
            int plus2 = (a & b) << 1;   //进位求和，要右移一位

            return Add(plus1, plus2);
        }
    }
}
