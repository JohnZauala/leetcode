using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //44. 通配符匹配
    //https://leetcode.cn/problems/wildcard-matching/?favorite=2ckc81c
    class IsMatch44
    {
        public bool IsMatch(string s, string p) 
        {
            int n = s.Length;
            int m = p.Length;
            bool[,] dp = new bool[n+1, m+1];
            dp[0, 0] = true;
            //i,j 长度字符能否匹配 ,最后一个字符是i-1, j-1
            for (int j = 1; j <= m; j++)
            {
                if (p[j-1] == '*')
                {
                    dp[0, j] = dp[0, j-1];
                }
                else 
                {
                     dp[0, j] = false;
                }
            }

            for (int i = 1; i <= n; i++)
            {
                dp[i, 0]= false;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    //dp[i, j] = ?
                    if (s[i-1] == p[j-1] || p[j-1] == '?')
                    {
                        dp[i,j] = dp[i-1,j-1];
                    }
                    else if (p[j-1] == '*')
                    {
                        dp[i, j] = dp[i,j-1] || dp[i-1, j];
                    }
                }
            }

            return dp[n, m];
        }

        // static void Main(string[] args)
        // {
        //     IsMatch44 instance = new IsMatch44();
        //     string s = "adceb";
        //     string p = "*a*b";

        //     // string s = "a";
        //     // string p ="a*";
           
        //     Console.WriteLine("44. 通配符匹配:{0}", instance.IsMatch(s, p));
        
        // }
    }
}
