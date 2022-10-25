using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/best-time-to-buy-and-sell-stock/
//121. 买卖股票的最佳时机

class MaxProfit121
{
    private int count = 0;
    public int MaxProfit(int[] prices)
    {
        // return MaxProfit(prices, prices.Length - 1, 1, 0);
        int N = prices.Length;
        int[,,] dp = new int[N, 2, 2];
        for (int i = 0; i < N; i++)
        {
            if (i - 1 < 0) {
                dp[i, 1, 0] = 0;
                dp[i, 1, 1] = -prices[i];
                continue;

            }
            dp[i, 1, 0] = Math.Max(dp[i-1, 1, 0], dp[i-1, 1, 1] + prices[i]);
            dp[i, 1, 1] = Math.Max(-prices[i], dp[i-1, 1, 1]);
        } 

        return dp[N-1, 1, 0];
    }


    public int MaxProfit(int[] prices, int i, int k, int rest)
    {
        PrintTab(count++);
        Console.WriteLine("i: {0}, k: {1}, rest: {2}", i, k, rest);
        if (i - 1 < 0) {
            if (rest == 0) {
                PrintTab(--count);
                Console.WriteLine("i: {0}, k: {1}, rest: {2}, res:{3}", i, k, rest, 0);
                return 0;
            }

            PrintTab(--count);
            Console.WriteLine("i: {0}, k: {1}, rest: {2}, res:{3}", i, k, rest, -prices[i]);
            return -prices[i];
        }

        // if (k == 0) {
        //     if (rest == 0) {
        //         PrintTab(--count);
        //         Console.WriteLine("i: {0}, k: {1}, rest: {2}, res:{3}", i, k, rest, 0);
        //         return 0;
        //     } else {
        //         PrintTab(--count);
        //         Console.WriteLine("i: {0}, k: {1}, rest: {2}, res:{3}", i, k, rest, Int32.MinValue);
        //         return Int32.MinValue;
        //     }
        // }

        int res = Int32.MinValue;
        if (rest == 1) { //当前有
            res = Math.Max(res, 0 - prices[i]);
            res = Math.Max(res, MaxProfit(prices, i-1, 1, 1));
        } else {
            res = Math.Max(res, MaxProfit(prices, i-1, 1, 0));
            res = Math.Max(res, MaxProfit(prices, i-1, 1, 1) + prices[i]);
        }

        PrintTab(--count);
         Console.WriteLine("i: {0}, k: {1}, rest: {2}, res:{3}", i, k, rest, res);

        return res;
    }

    // static void Main(string[] args)
    // {
    //     MaxProfit121 instance = new MaxProfit121();
    //     int[] prices = new int[]{1,2};
    
    //     int res = instance.MaxProfit(prices);
    //     Console.WriteLine("121. 买卖股票的最佳时机: {0}", res);
    // }

    void PrintTab(int count) {
        for (int i = 0; i < count; i++)
        {
            Console.Write("    ");
        }
    }
}        

