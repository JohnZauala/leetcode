using System;
using System.Collections.Generic;

class KthSmallest378
{
    public int KthSmallest(int[][] matrix, int k) 
    {
       
        int n = matrix.Length;
        int m = matrix[0].Length;

        int left = matrix[0][0];
        int right = matrix[n-1][m-1];

        while(left < right)
        {
            int mid = left + (right-left)/2;
            if (check(matrix, mid, k)) {
                right = mid;
            } else {
                left = mid+1;
            }
        }

        return left;

    }

    public bool check(int[][] matrix, int mid, int k)
    {
        int i = matrix.Length-1;
        int m = matrix[0].Length;
        int j = 0;
        int num = 0;
        while (i >= 0 && j < m)
        {
            if (matrix[i][j] <= mid) {
                num += i + 1;
                j++;
            } else
            {
                i--;
            }
        }

        return num >= k;
    }

    static void Main(string[] args)
    {
        int[][] matrix = new int[][]{new int[]{1,5,9},new int[]{10,11,13},new int[]{12,13,15}};
        var instance = new KthSmallest378();
        Console.WriteLine("KthSmallest: {0}", instance.KthSmallest(matrix, 8));
        
    }
}