using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //10. 正则表达式匹配
    //https://leetcode.cn/problems/regular-expression-matching/?favorite=2ckc81c
    class IsMatch10
    {
        public bool IsMatch(string s, string p) 
        {
            // return IsMatch(s.ToCharArray(), p.ToCharArray(), s.Length, p.Length, 0, 0);
            return IsMatchDp(s.ToCharArray(), p.ToCharArray());
        }

        public bool IsMatchDp(char[] sChars, char[] pChars)
        {
            int n = sChars.Length;
            int m = pChars.Length;
            bool[,] dp = new bool[n+1, m+1];

            dp[n,m] = true;
            for (int j = m-1; j >= 0; j--)
            {
                int rest = m - j;
                if (rest % 2 != 0) {
                    dp[n,j]= false;
                } else {
                    if (pChars[j+1] != '*')
                        dp[n, j] = false;
                    else
                        dp[n, j] = dp[n, j+2];
                }
            }

            for (int i = 0; i < n; i++)
            {
                dp[i, m] = false;
            }

            printDp(dp);
            for (int i = n-1; i>=0; i--)
            {
                for (int j = m-1; j >=0 ; j--)
                {
                    if (j+1 < m && pChars[j+1] == '*') {
                        int count = 0;
                        bool ans = false;
                        while (i+count<n && j+2<m && (sChars[i+count] ==  pChars[j] || pChars[j] == '.'))
                        {
                            count++;
                            ans |= dp[i+count, j+2];
                        }
                        dp[i, j] = ans;
                    } else if (sChars[i] == pChars[j] || pChars[j] == '.') {
                        dp[i, j] = dp[i+1, j+1];
                    } else {
                        dp[i, j] = false;
                    }
                } 
            }


            return dp[0, 0];
        }

        public void printDp(bool[,] dp) 
        {
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    Console.Write(" {0}", dp[i, j]);
                }
                Console.Write("\n");
            }
        }

        // i .. j .. 能否匹配
        // public bool IsMatch(char[] sChars, char[] pChars, int sLength, int pLength, int i, int j)
        // {
        //     // Console.WriteLine("i: {0}, j:{1}", i, j);
        //     //base case
        //     if (i == sLength && j == pLength) {
        //         return true;
        //     }

        //     if (i == sLength) {
        //         //    string s = "ab";
        //         //    string p =".*c";
        //         int rest = pLength - j;
        //         if (rest%2 != 0) {
        //             return false;
        //         }

        //         for (int m = j; m < pLength-1; m+=2)
        //         {
        //             if (pChars[m+1] != '*')
        //                 return false;
        //         }
                
        //         return true;
        //     }

        //     if (j == pLength) {
        //         return false;
        //     }

        //     bool ans = false;
        //     if (pChars[j] == '.' && (j+1<pLength && pChars[j+1] == '*')) 
        //     {
        //         int num = 0;
        //         while(num <= sLength-i)
        //         {
        //             ans |= IsMatch(sChars, pChars, sLength, pLength, i+num, j+2);
        //             num++;
        //         }
        //     } else if (pChars[j] == '.')
        //     {
        //         ans |= IsMatch(sChars, pChars, sLength, pLength, i+1, j+1);
        //     } else if (('a' <= pChars[j] && pChars[j] <= 'z') && (j+1<pLength && pChars[j+1] == '*')) 
        //     {
        //         ans |= IsMatch(sChars, pChars, sLength, pLength, i, j+2);
        //         int count = 0;
        //         while (i+count<sLength && (sChars[i+count] ==  pChars[j]))
        //         {
        //             count++;
        //             ans |= IsMatch(sChars, pChars, sLength, pLength, i+count, j+2);
        //         }
        //     } else {
        //         if (sChars[i] != pChars[j])
        //             return false;
        //         else {
        //             ans |= IsMatch(sChars, pChars, sLength, pLength, i+1, j+1);
        //         }
        //     }

        //     return ans;
        // }

        // static void Main(string[] args)
        // {
        //     IsMatch10 instance = new IsMatch10();
        //     // string s = "abcaaaaaaabaabcabac";
        //     // string p = ".*ab.a.*a*a*.*b*b*";
        //     // string s = "abdc";
        //     // string p ="abcd";

        //     string s = "a";
        //     string p ="a*";
           
        //     Console.WriteLine("正则表达式匹配:{0}", instance.IsMatch(s, p));
        
        // }
    }
}
