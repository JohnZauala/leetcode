using System;
class Solution {
        public static int maxValue(int N, int C, int[] v, int[] w) 
        {    
            int[,] dp = new int[N,C+1];
            // 先处理「考虑第一件物品」的情况
            for (int i = 0; i <= C; i++) {
                dp[0,i] = i >= v[0] ? w[0] : 0;
            }
            // 再处理「考虑其余物品」的情况
            for (int i = 1; i < N; i++) {
                for (int j = 0; j < C + 1; j++) {
                    // 不选该物品
                    int n = dp[i-1,j]; 
                    // 选择该物品，前提「剩余容量」大于等于「物品体积」
                    int y = j >= v[i] ? dp[i-1,j-v[i]] + w[i] : 0; 
                    dp[i,j] = Math.Max(n, y);
                }
            }
            return dp[N-1,C];
        }

    
        //i .. 自由选择   rest 容量，最大价值
        public static int Dp1(int N, int[] w, int[] v, int i, int rest)
        {
            if (rest < 0)
            {
                return -1;
            }
            
            if (i == N)
            {
                return 0;
            }

            int p1 = Dp1(N, w, v, i + 1, rest);
            int p2 = Dp1(N, w, v, i + 1, rest - v[i]);
            if (p2 != -1)
            {
                p2 = w[i] + p2;
            }

            return Math.Max(p1, p2);
        }
        
        // v 体积
        // w 价值
        public static int Dp2(int N, int Bag, int[] v, int[] w)
        {
            int[,] dp = new int[N+1, Bag+1];
            for (int i = 0; i < Bag+1; i++)
            {
                dp[N, i] = 0;
            }

            for (int i = N-1; i >= 0; i--)
            {
                for (int j = 0; j < Bag+1; j++)
                {
                    // dp[i, j] = ?
                    int p1 = dp[i+1, j];
                    int p2 = -1; 
                    if (j - v[i] >= 0) {
                        p2 = dp[i+1, j-v[i]] + w[i];
                    }

                    dp[i, j] = Math.Max(p1, p2);
                }
            }

            return dp[0, Bag];
        }

    
         // v 体积
        // w 价值
        public static int Dp3(int N, int Bag, int[] v, int[] w)
        {
            int[,] dp = new int[2, Bag+1];
            for (int i = 0; i < Bag+1; i++)
            {
                dp[0, i] = 0;
            }

            int prev = 0;
            int curr = 0;
            for (int i = N-1; i >= 0; i--)
            {
                for (int j = 0; j < Bag+1; j++)
                {
                    prev = i&1;
                    curr = 1 - i&1;
                    // dp[i, j] = ?
                    int p1 = dp[prev, j];
                    int p2 = -1; 
                    if (j - v[i] >= 0) {
                        p2 = dp[prev, j-v[i]] + w[i];
                    }

                    dp[curr, j] = Math.Max(p1, p2);
                }
            }

            return dp[curr, Bag];
        }

          // v 体积
        // w 价值
        public static int Dp4(int N, int Bag, int[] v, int[] w)
        {
            int[] dp = new int[Bag+1];

            for (int i = N-1; i >= 0; i--)
            {
                for (int j = Bag; j > 0; j--)
                {
                   
                    // dp[i, j] = ?
                    int p1 = dp[j];
                    int p2 = -1; 
                    if (j - v[i] >= 0) {
                        p2 = dp[j-v[i]] + w[i];
                    }

                    dp[j] = Math.Max(p1, p2);
                }
            }

            return dp[Bag];
        }
}