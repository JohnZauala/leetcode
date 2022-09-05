/**
完全背包问题
*/
using System;
public class AllPack 
{
    public static int maxValue(int N, int C, int[] v, int[] w) {
        int[,] dp = new int[N,C + 1];
        
        // 先预处理第一件物品
        for (int j = 0; j <= C; j++) {
            // 显然当只有一件物品的时候，在容量允许的情况下，能选多少件就选多少件
            int maxK = j / v[0];
            dp[0,j] = maxK * w[0];
        }
        
        // 处理剩余物品
        for (int i = 1; i < N; i++) {
            for (int j = 0; j <= C; j++) {
                // 不考虑第 i 件物品的情况（选择 0 件物品 i）
                int n = dp[i - 1,j];
                // 考虑第 i 件物品的情况
                int y = 0;
                for (int k = 1 ;; k++) {
                    if (j < v[i] * k) {
                        break;
                    }
                    y = Math.Max(y, dp[i - 1,j - k * v[i]] + k * w[i]);
                }
                dp[i,j] = Math.Max(n, y);
            }
        }
        return dp[N - 1,C];
    }


    //dp[] i ... 自由选择， 不超过最大容量rest ，所得最大价值
    //v 是大小
    //w 是价值
    public static int Dp1(int N, int[] v, int[] w, int index, int rest) 
    {
        if (index == N) {
            return 0;
        }

        if (rest < 0) {
            return -1;
        }

        int res = Int32.MinValue;
        for (int i = 0; i*v[index] <= rest; i++)
        {
            int p1 = Dp1(N, v, w, index+1, rest-i*v[index]) + w[index]*i;
            res = Math.Max(p1, res);
        }

        return res;
    }

    //N, v, w, V
    //dp[] i ... 自由选择， 不超过最大容量rest ，所得最大价值
    //v[] 是大小
    //w[] 是价值
    public static int Dp2(int N, int[] v, int[] w, int rest) 
    {
        int[,] dp = new int[2, rest+1];

        int prev = 0;
        int curr = 0;
        prev = N&1;
        for (int i = 0; i < rest+1; i++)
        {
            dp[prev, i] = 0;
        }
        for (int i = N-1; i >= 0; i--)
        {
            for (int j = 0; j < rest+1; j++)
            {
                prev = i&1;
                curr = 1 - i&1;
             
                //dp[i, j] = ?
                int p1 = Int32.MinValue;
                for (int k = 0; k <= j/v[i]; k++)
                {
                    p1 = Math.Max(dp[prev, j-k*v[i]] + w[i]*k, p1);
                }

                dp[curr, j] = p1;
            }
        }

        // for (int i = 0; i*v[index] <= rest; i++)
        // {
        //     int p1 = Dp1(N, v, w, index+1, rest-i*v[index]) + w[index]*i;
        //     res = Math.Max(p1, res);
        // }

        return dp[0, rest];
    }
}