using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Array
{
    /*
     * 给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使每个元素 只出现一次 ，返回删除后数组的新长度。

不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。
     */

    class Solution1
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int slow = 0;
            for (int fast = 1; fast < nums.Length; fast++)
            {
                if (nums[slow] != nums[fast])
                {
                    nums[++slow] = nums[fast];
                }
            }
            return slow + 1;
        }
    }
}
