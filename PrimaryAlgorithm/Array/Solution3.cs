using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Array
    {
    /*给定一个数组，将数组中的元素向右移动 k 个位置，其中 k 是非负数。
   
进阶：

尽可能想出更多的解决方案，至少有三种不同的方法可以解决这个问题。
你可以使用空间复杂度为 O(1) 的 原地 算法解决这个问题吗？
     */
    class Solution3
        {
        public void Rotate(int[] nums, int k)
            {
            if (nums == null || nums.Length <= 1 || k == 0)
                {
                return;
                }

            int len = nums.Length;
            bool[] visited = new bool[len];
            int hold = nums[0];
            int index = 0;

            for (int i = 0; i < len; i++)
                {
                index = (index + k) % len;  // 找到第二个索引
                if (!visited[index])
                    {
                    visited[index] = true;

                    // 交换 index 和 hold
                    int temp = nums[index];
                    nums[index] = hold;
                    hold = temp;
                    }
                else
                    {
                    // 去下一个
                    index = (index + 1) % len;
                    // 更新 hodl
                    hold = nums[index];
                    i--;
                    }
                }
            }

        public void Rotate_Std(int[] nums, int k)
            {
            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
            }

        private void Reverse(int[] nums, int start, int end)
            {
            while (start < end)
                {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start += 1;
                end -= 1;
                }
            }

        public void Rotate_Std2(int[] nums, int k)
            {
            int len = nums.Length;
            k = k % len;
            int count = Gcd(k, len);
            for (int start = 0; start < count; ++start)
                {
                int current = start;
                int prev = nums[start];
                do
                    {
                    int next = (current + k) % len;
                    int temp = nums[next];
                    nums[next] = prev;
                    prev = temp;
                    current = next;
                    } while (start != current);
                }
            }

        // 最大公约数
        private int Gcd(int a, int b)
            {
            return b > 0 ? Gcd(b, a % b) : a;
            }

        }
    }
