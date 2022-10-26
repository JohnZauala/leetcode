using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/house-robber/description/
//198. 打家劫舍

class Rob198
{
    public int Rob(int[] nums)
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
    //0...i-1  已经确定 i 
    public int Rob(int[] nums, int cur, int state)
    {
        if (cur >= nums.Length)
            return 0;

        int res = 0;
        if (state == 1) {
            res = Math.Max(Rob(nums, cur+1, 0) + nums[cur], Rob(nums, cur+1, 0));
        } else {
            res = Math.Max(Rob(nums, cur+1, 1), Rob(nums, cur+1, 0));
        }

        return res;
    }

    // static void Main(string[] args)
    // {
    //     Rob198 instance = new Rob198();
    //     int[] prices = new int[]{1,2,3,1};
    
    //     int res = instance.Rob(prices);
    //     Console.WriteLine("198. 打家劫舍: {0}", res);
    // }
}        

