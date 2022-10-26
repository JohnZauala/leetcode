using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/house-robber-ii/
//213. 打家劫舍 II

class Rob213
{
    public int Rob(int[] nums) 
    {
        int n = nums.Length;
        int[] nums1 = new int[n-1];
        Array.Copy(nums, 0, nums1, 0, n-1);

        int[] nums2 = new int[n-1];
        Array.Copy(nums, 1, nums2, 0, n-1);

        return Math.Max(RobHelp(nums1), RobHelp(nums2));
    }

    public int RobHelp(int[] nums)
    {
        int n = nums.Length;
        int[,] dp = new int[n+1, 2];

        dp[n, 1] = 0;
        dp[n, 0] = 0;
        for (int i = n-1; i >= 0; i--)
        {
            dp[i, 1] = Math.Max(dp[i+1, 0] + nums[i], dp[i+1, 0]);
            dp[i, 0] = Math.Max(dp[i+1, 1], dp[i+1, 0]);
        }

        return Math.Max(dp[0, 1], dp[0, 0]);

    }
    
    // static void Main(string[] args)
    // {
    //     Rob213 instance = new Rob213();
    //     int[] prices = new int[]{2,3,2};
    
    //     int res = instance.Rob(prices);
    //     Console.WriteLine("213. 打家劫舍 II: {0}", res);
    // }
}        

