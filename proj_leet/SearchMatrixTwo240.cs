using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //240. 搜索二维矩阵 II
    //https://leetcode.cn/problems/search-a-2d-matrix-ii/?favorite=2ckc81c
    class SearchMatrixTwo240
    {
        public bool SearchMatrix(int[][] matrix, int target) 
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            int i = 0;
            int j = m-1;
            while (i < n && j >= 0)
            {
                if (matrix[i][j] == target)
                {
                    return true;
                } else if (matrix[i][j] > target) {
                    j--; 
                } else
                {
                    i++;
                 
                }
            }
            return false;
        }

        // static void Main(string[] args)
        // {
        //     SearchMatrixTwo240 instance = new SearchMatrixTwo240();
        //     int[][] matrix = new int[][]{new int[]{1,4,7,11,15},
        //     new int[]{2,5,8,12,19},
        //     new int[]{3,6,9,16,22},
        //     new int[]{10,13,14,17,24},
        //     new int[]{18,21,23,26,30}};
        //     int target = 5;
            
        //     Console.WriteLine("找到 K 个最接近的元素:{0}", string.Join(",", instance.SearchMatrix(matrix, target)));

        
        // }
    }
}
