using System;
using System.Collections.Generic;

class NumIslands200
{
    public int NumIslands(char[][] grid) 
    {

        int N = grid.Length;
        int M = grid[0].Length;
        int ans = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (grid[i][j] == '1') {
                    Dfs(grid, i, j);
                    ans++;
                }
            }
        }
        return ans;
    }

    //深度优先搜索（depth first search）
    public void Dfs(char[][] grid, int i, int j) 
    {
        int N = grid.Length;
        int M = grid[0].Length;
        if (i < 0 || j < 0 || i >= N || j >= M || grid[i][j] != '1')
            return;

        grid[i][j] = '0';
        Dfs(grid, i-1, j);
        Dfs(grid, i+1, j);
        Dfs(grid, i, j-1);
        Dfs(grid, i, j+1);
    }

    // static void Main(string[] args)
    // {
    //     var tokens = ["2","1","+","3","*"];
    //     var instance = new EvalRPN150();
    //     Console.WriteLine("word break: {0}", instance.EvalRPN(tokens));
        
    // }
}