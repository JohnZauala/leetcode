using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //5. 最长回文子串
    //https://leetcode.cn/problems/longest-palindromic-substring/
    class LongestPalindrome5
    {
        public string LongestPalindrome(string s) 
        {
            char[] chars = s.ToCharArray();
            int N = chars.Length;

            bool[,] dp = new bool[N, N];
            for (int i = 0; i < N; i++)
            {
                dp[i,i] = true;
            }
   
            int maxLength = 1;
            int start = 0;
            for (int Length = 2; Length <= N; Length++)
            {
                for (int i = 0; i < N; i++)
                {
                    int j = i + Length - 1;
                    if (j >= N) {
                        break;
                    }
                    if (Length == 2) {
                        dp[i,j] = chars[i] == chars[j] ? true : false;
                    } else {
                        if (chars[i] == chars[j]) {
                            dp[i,j] = dp[i+1, j-1]?true:false;
                        } else {
                             dp[i,j] = false;
                        }
                    }

                    if (dp[i,j] && j-i+1 > maxLength) {
                        start = i;
                        maxLength = j-i+1;
                    }
                }
            }
            return s.Substring(start, maxLength);
        }

        // static void Main(string[] args)
        // {
        //     LongestPalindrome5 instance = new LongestPalindrome5();
        //     string s = "cbbd";
           
        //     Console.WriteLine("最长回文子串:{0}", instance.LongestPalindrome(s));
        
        // }
    }
}
