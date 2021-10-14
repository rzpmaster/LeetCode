using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Sort
{
    class Solution2 : VersionControl
    {
        /*
         你是产品经理，目前正在带领一个团队开发新的产品。不幸的是，你的产品的最新版本没有通过质量检测。由于每个版本都是基于之前的版本开发的，所以错误的版本之后的所有版本都是错的。

假设你有 n 个版本 [1, 2, ..., n]，你想找出导致之后所有版本出错的第一个错误的版本。

你可以通过调用 bool isBadVersion(version) 接口来判断版本号 version 是否在单元测试中出错。实现一个函数来查找第一个错误的版本。你应该尽量减少对调用 API 的次数。
         */
        public int FirstBadVersion(int n)
        {
            int left = 1, right = n;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;

        }

        int binary_search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 直接返回
                    return mid;
                }
            }
            // 直接返回
            return -1;
        }

        int left_bound(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 别返回，锁定左侧边界
                    right = mid - 1;
                }
            }
            // 最后要检查 left 越界的情况
            if (left >= nums.Length || nums[left] != target)
                return -1;
            return left;
        }


        int right_bound(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 别返回，锁定右侧边界
                    left = mid + 1;
                }
            }
            // 最后要检查 right 越界的情况
            if (right < 0 || nums[right] != target)
                return -1;
            return right;
        }

    }

    class VersionControl
    {
        protected bool IsBadVersion(int version)
        {
            return version >= 4;
        }
    }
}
