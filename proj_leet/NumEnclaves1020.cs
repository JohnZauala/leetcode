using System;
using System.Collections.Generic;

class NumEnclaves1020
{
    public int NumEnclaves(int[][] grid)
    {
        int N = grid.Length;
        int M = grid[0].Length;
        for (int i = 0; i < N; i++)
        {
            Dfs(grid, i, 0);
            Dfs(grid, i, M-1);
        }
        for (int j = 0; j < M; j++)
        {
            Dfs(grid, 0, j);
            Dfs(grid, N-1, j);
        }

        int ans = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (grid[i][j] == '1') {
                    ans += Dfs(grid, i, j);
                }
            }
        }
        return ans;
    }

    public int Dfs(int[][] grid, int i, int j)
    {
        int N = grid.Length;
        int M = grid[0].Length;
        if (i < 0 || j < 0 || i >= N || j >= M || grid[i][j] == '0') {
            return 0;
        }

        grid[i][j] = '0';
        return 1 + Dfs(grid, i+1, j) + Dfs(grid, i-1, j) + Dfs(grid, i, j-1) + Dfs(grid, i, j+1);
    }

    

    // static void Main(string[] args)
    // {
    //     var tokens = ["2","1","+","3","*"];
    //     var instance = new EvalRPN150();
    //     Console.WriteLine("word break: {0}", instance.EvalRPN(tokens));
        
    // }
}