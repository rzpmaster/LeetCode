using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Solution
    {
        public int solution(string s)
        {
            if (s == null || s.Length <= 2)
            {
                return 0;
            }

            if (s.Length == 3)
            {
                if (s[0].Equals(s[1]) && s[1].Equals(s[2]))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            // length>=4
            int aCount = s.Count(e => e.Equals('a'));
            if (aCount == 0)
            {
                return Split3Part(s.Length);
            }

            if (aCount % 3 != 0)
            {
                return 0;
            }

            return Split3PartMain(s, s.Length, s.Length / aCount);
        }

        private int Split3PartMain(string s, int length, int v)
        {
            List<int> indexs = new List<int>();
            for (int i = 0; i < length; i++)
            {
                if (s[i].Equals('a'))
                {
                    indexs.Add(i);
                }
            }

            if (v == 1)
            {
                return AllPartsHasOneA(indexs[1] - indexs[0] - 1, indexs[2] - indexs[1] - 1);
            }
            else
            {
                return AllPartsHasOneA(indexs[v] - indexs[v - 1] - 1, indexs[2 * v] - indexs[2 * v - 1] - 1);
            }
        }

        private int AllPartsHasOneA(int v1, int v2)
        {
            return (v1 + 1) * (v2 + 1);
        }

        private int Split3Part(int length)
        {
            int count = 0;
            int i = 1;
            while (length - i >= 2)
            {
                count += Split2Part(length - i);
                i++;
            }

            return count;
        }

        private int Split2Part(int length)
        {
            if (length >= 2)
            {
                return length - 1;
            }
            return 0;
        }
    }
}
