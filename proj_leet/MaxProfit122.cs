using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-ii/
//122. 买卖股票的最佳时机 II

class MaxProfit122
{
    private int count = 0;
    public int MaxProfit(int[] prices)
    {
        int N = prices.Length;
        int[,] dp = new int[N, 2];
        for (int i = 0; i < N; i++)
        {
            if (i - 1 < 0) {
                dp[i, 0] = 0;
                dp[i, 1] = -prices[i];
                continue;
            }
            dp[i, 0] = Math.Max(dp[i-1, 0], dp[i-1, 1] + prices[i]);
            dp[i, 1] = Math.Max(dp[i-1, 0] - prices[i], dp[i-1, 1]);
        } 

        return dp[N-1, 0];
        // return MaxProfit(prices, N-1, 0);
    }


    public int MaxProfit(int[] prices, int i, int rest)
    {
        PrintTab(count++);
        Console.WriteLine("i: {0}, rest: {1}", i, rest);
        if (i - 1 < 0) {
            if (rest == 0) {
                PrintTab(--count);
                Console.WriteLine("i: {0}, rest: {1}, res:{2}", i, rest, 0);
                return 0;
            }

            PrintTab(--count);
            Console.WriteLine("i: {0}, rest: {1}, res:{2}", i, rest, -prices[i]);
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
            res = Math.Max(res, MaxProfit(prices, i-1, 0) - prices[i]);
            res = Math.Max(res, MaxProfit(prices, i-1, 1));
        } else {
            res = Math.Max(res, MaxProfit(prices, i-1, 0));
            res = Math.Max(res, MaxProfit(prices, i-1, 1) + prices[i]);
        }

        PrintTab(--count);
        Console.WriteLine("i: {0}, rest: {1}, res:{2}", i, rest, res);

        return res;
    }

    // static void Main(string[] args)
    // {
    //     MaxProfit122 instance = new MaxProfit122();
    //     int[] prices = new int[]{7,1,5,3,6,4};
    
    //     int res = instance.MaxProfit(prices);
    //     Console.WriteLine("122. 买卖股票的最佳时机 II: {0}", res);
    // }

    void PrintTab(int count) {
        for (int i = 0; i < count; i++)
        {
            Console.Write("    ");
        }
    }
}        

