using System;
using System.Collections.Generic;
using System.Linq;
//https://leetcode.cn/problems/longest-substring-with-at-least-k-repeating-characters/
//395. 至少有 K 个重复字符的最长子串
class LongestSubstring395
{
    public int LongestSubstring(string s, int k) {
        if (s.Length < k) 
            return 0;

        int[] map = new int[26];
        char[] chars = s.ToCharArray();
        foreach (var ch in chars)
        {
            map[ch-'a']++;
        }

        bool isAll = true;
        List<char> list = new List<char>();
        for (int i = 0; i < 26; i++)
        {
            if (map[i] > 0 && map[i] < k) {
                list.Add((char)(i + 'a'));
                isAll = false;
            }
        }
        if (isAll) {
            return s.Length;
        }

        int ans = 0;
        string[] sArray = s.Split(list.ToArray());
        foreach (var split in sArray)
        {
            ans = Math.Max(ans, LongestSubstring(split, k));
        }
        return ans;
    }

    static void Main(string[] args)
    {
       var s = "ababbc";
       var k = 2;
       var instance = new LongestSubstring395();
       Console.WriteLine($"LongestSubstring: {instance.LongestSubstring(s, k)}");
        
    }
}