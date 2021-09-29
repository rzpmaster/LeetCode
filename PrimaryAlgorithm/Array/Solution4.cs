using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryAlgorithm.Array
    {
    class Solution4
        {
        public int[] Intersect(int[] nums1, int[] nums2)
            {
            if (nums1 == null || nums2 == null || !nums1.Any() || !nums2.Any())
                {
                return new int[] { };
                }
            Array.Sort(nums1);
            Array.Sort(nums2);

            List<int> result = new List<int>();
            int i = 0, j = 0;
            while (i < nums1.Length && j < nums2.Length)
                {
                if (nums1[i] == nums2[j])
                    {
                    result.Add(nums1[i]);
                    i++; j++;
                    }
                else if (nums1[i] > nums2[j])
                    {
                    j++;
                    }
                else //nums1[i] < nums2[j]
                    {
                    i++;
                    }
                }
            return result.ToArray();

            }

        public int[] Intersect_Std(int[] nums1, int[] nums2)
            {
            if (nums1 == null || nums2 == null || !nums1.Any() || !nums2.Any())
                {
                return new int[] { };
                }
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
                {
                if (map.ContainsKey(nums1[i]))
                    {
                    map[nums1[i]]++;
                    }
                else
                    {
                    map.Add(nums1[i], 1);
                    }
                }
            List<int> result = new List<int>();
            for (int i = 0; i < nums2.Length; i++)
                {
                if (map.ContainsKey(nums2[i]))
                    {
                    if (map[nums2[i]] > 0)
                        {
                        result.Add(nums2[i]);
                        map[nums2[i]]--;
                        }
                    }
                }
            return result.ToArray();

            }
        }

    }
