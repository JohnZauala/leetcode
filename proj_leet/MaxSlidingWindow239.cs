using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/sliding-window-maximum/
//239. 滑动窗口最大值
class MaxSlidingWindow239
{
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        int N = nums.Length;
        int[] res = new int[N-k+1];

        LinkedList<int> queue = new LinkedList<int>();
        for (int i = 0; i < k; i++)
        {
            while(queue.Count > 0 && nums[queue.Last.Value] <= nums[i])
            {
                queue.RemoveLast();
            }
            queue.AddLast(i);
        }

        int index = 0;
        res[index++] = nums[queue.First.Value];

        for (int i = k; i < N; i++)
        {
            while(queue.Count > 0 && queue.First.Value <= i-k)
            {
                queue.RemoveFirst();
            }
     
            while(queue.Count > 0 && nums[queue.Last.Value] <= nums[i])
            {
                queue.RemoveLast();
            }

            queue.AddLast(i);

            res[index++] = nums[queue.First.Value];
        
        }

        return res;
    }
    static void Main(string[] args)
    {

        // int[] nums = new int[]{1,3,-1,-3,5,3,6,7};
        // int k = 3;

        int[] nums = new int[]{1};
        int k = 1;
        var instance = new MaxSlidingWindow239();
        Console.WriteLine("FindOrder210: {0}", string.Join(",", instance.MaxSlidingWindow(nums, k)) );
        
    }
}