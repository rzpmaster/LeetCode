using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Sort
{
    /*
     给你两个按 非递减顺序 排列的整数数组 nums1 和 nums2，另有两个整数 m 和 n ，分别表示 nums1 和 nums2 中的元素数目。

请你 合并 nums2 到 nums1 中，使合并后的数组同样按 非递减顺序 排列。

注意：最终，合并后数组不应由函数返回，而是存储在数组 nums1 中。为了应对这种情况，nums1 的初始长度为 m + n，其中前 m 个元素表示应合并的元素，后 n 个元素为 0 ，应忽略。nums2 的长度为 n 。
*/
    class Solution1
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
            {
                return;
            }

            int i = 0, j = 0, z = 0;
            int[] result = new int[m + n];
            while (i < m || j < n)
            {
                if (i < m && j < n && nums1[i] <= nums2[j])
                {
                    result[z++] = nums1[i++];
                }
                else if (j < n)
                {
                    result[z++] = nums2[j++];
                }
                else
                {
                    result[z++] = nums1[i++];
                }
            }
            for (int k = 0; k != m + n; ++k)
            {
                nums1[k] = result[k];
            }
        }
    }
}
