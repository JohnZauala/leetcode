using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-iii/
//123. 买卖股票的最佳时机 III

class MaxProfit123
{
    private int count = 0;
    public int MaxProfit(int[] prices)
    {
        int N = prices.Length;
        int K = 3;
        int[,,] dp = new int[N,K,2];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < K; j++)
            {
                if (i - 1 < 0) {
                    dp[i, j, 0] = 0;
                    dp[i, j, 1] = -prices[i];
                    continue;
                }

                if (j == 0) {
                    dp[i, j, 0] = 0;
                    dp[i, j, 1] = Int32.MinValue;
                    continue;
                }
                
                dp[i, j, 0] = Math.Max(dp[i-1, j, 0], dp[i-1, j, 1] + prices[i]);
                dp[i, j, 1] = Math.Max(dp[i-1, j-1, 0] - prices[i], dp[i-1, j, 1]);
            }  
        } 

        return dp[N-1, K-1, 0];
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
    //     MaxProfit123 instance = new MaxProfit123();
    //     int[] prices = new int[]{3,3,5,0,0,3,1,4};
    
    //     int res = instance.MaxProfit(prices);
    //     Console.WriteLine("123. 买卖股票的最佳时机 III: {0}", res);
    // }

    void PrintTab(int count) {
        for (int i = 0; i < count; i++)
        {
            Console.Write("    ");
        }
    }
}        

