using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily
{
    /*
     给你一个字符串 num ，表示一个大整数。如果一个整数满足下述所有条件，则认为该整数是一个 优质整数 ：

该整数是 num 的一个长度为 3 的 子字符串 。
该整数由唯一一个数字重复 3 次组成。
以字符串形式返回 最大的优质整数 。如果不存在满足要求的整数，则返回一个空字符串 "" 。

注意：

子字符串 是字符串中的一个连续字符序列。
num 或优质整数中可能存在 前导零 。
     
     */

    //三个指针一起扫效率更高

    internal class Solution1
    {
        public static void Run()
        {
            Solution1 solution1 = new Solution1();
            var result = solution1.LargestGoodInteger("222");
            Console.WriteLine(result);
        }

        public string LargestGoodInteger(string num)
        {
            char result = ' ';
            char preview = ' ';
            int count = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] != preview)
                {
                    preview = num[i];
                    count = 1;
                    continue;
                }
                else
                {
                    count++;
                    if (count >= 3)
                    {
                        UpdateResult(ref result, num[i]);
                        preview = ' ';
                        count = 0;
                    }
                }
            }
            if (result == ' ') return "";
            return new string(result, 3);
        }
        private void UpdateResult(ref char result, char current)
        {
            if (current > result)
            {
                result = current;
            }
        }
    }
}
