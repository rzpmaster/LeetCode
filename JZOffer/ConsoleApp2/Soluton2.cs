using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Soluton2
    {
        public int solution(string s)
        {
            // "BALLOON"
            if (s == null || s.Length < 7)
            {
                return 0;
            }

            int[] flag = new int[7];

            for (int i = 0; i < s.Length; i++)
            {
                var curChar = s[i];
                if (curChar.Equals('B'))
                {
                    flag[0]++;
                }
                else if (curChar.Equals('A'))
                {
                    flag[1]++;
                }
                else if (curChar.Equals('L'))
                {// 2 3
                    if (flag[2] > flag[3])
                    {
                        flag[3]++;
                    }
                    else
                    {
                        flag[2]++;
                    }
                }
                else if (curChar.Equals('O'))
                {// 4 5
                    if (flag[4] > flag[5])
                    {
                        flag[5]++;
                    }
                    else
                    {
                        flag[4]++;
                    }
                }
                else if (curChar.Equals('N'))
                {
                    flag[6]++;
                }

            }

            return flag.Min();
        }
    }
}
