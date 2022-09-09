using System;
using System.Collections.Generic;
using System.Linq;
//https://leetcode.cn/problems/shuffle-an-array/
class Shuffle384
{
    int[] original;
    int[] _nums;
    int N = 0;
    public Shuffle384(int[] nums) {
        N = nums.Length;
        original = new int[N];
        _nums = nums;
        Array.Copy(nums, original, N);
        
    }
    
    public int[] Reset() {
        Array.Copy(original, _nums, N)
        return _nums;
    }
    
    public int[] Shuffle() {
        int[] nums = _nums;
        Random rd = new Random();
        for (int i = 0; i < N; i++)
        {
            int j = rd.Next(i, N);
            Swap(nums, i, j);
        }
        return nums;
    }

    public void Swap(int[] arr, int i, int j) {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
    }

    static void Main(string[] args)
    {
       
        
    }
}