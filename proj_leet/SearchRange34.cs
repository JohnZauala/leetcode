using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //https://leetcode.cn/problems/find-first-and-last-position-of-element-in-sorted-array/
    class SearchRange34
    {
        public int[] SearchRange(int[] nums, int target) {
            
        }

        public int LeftBound(int[] nums, int target) {
            int left = 0;
            int right = nums.Length;
            while (left < right)
            {
                int mid = left + (right - left)>>2;
                if (nums[mid] < target) 
                {
                    left = mid + 1;
                }else
                {
                    right = mid;
                }
            }
            

            return nums[left] == target ? left : -1;
        }

        public int RightBound(int[] nums, int target) {

        }

        static void Main(string[] args)
        {
            SearchRange34 instance = new SearchRange34();
            int[] arr = new int[]{5,7,7,8,8,10};
            int target = 8;
            Console.WriteLine("left bound: {0}", instance.LeftBound());  
            
        }
    }
}
