using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/largest-rectangle-in-histogram/description/
//84. 柱状图中最大的矩形

class LargestRectangleArea84
{
    public int LargestRectangleArea(int[] heights) 
    {
        int N = heights.Length;
        int[] r = new int[N];
        int[] l = new int[N];
        Array.Fill(r, N);
        Array.Fill(l, -1);

        Stack<int> s = new Stack<int>();
        for (int i = 0; i < N; i++)
        {
            while(s.Count > 0 && heights[s.Peek()] > heights[i]) {
                r[s.Pop()] = i;
            } 

            s.Push(i); 
        }

        s.Clear();
        for (int i = N-1; i >= 0; i--)
        {
            while(s.Count > 0 && heights[s.Peek()] > heights[i]) {
                l[s.Pop()] = i;
            }
            s.Push(i);
        }

        int ans = 0;
        for (int i = 0; i < N; i++)
        {   
            ans = Math.Max(ans, heights[i]*(r[i]-l[i]-1));
        }

        return ans;
    }

    
    // static void Main(string[] args)
    // {
    //     // int[] heights = new int[]{2,1,5,6,2,3};
    //     int[] heights = new int[]{2, 4};
    //     var instance = new LargestRectangleArea84();
    //     Console.WriteLine("柱状图中最大的矩形: {0}",instance.LargestRectangleArea(heights) );
        
    // }
}