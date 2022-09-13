using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //https://leetcode.cn/problems/find-first-and-last-position-of-element-in-sorted-array/
    class SearchRange34
    {
        public int[] SearchRange(int[] nums, int target) {
            int left = LeftBound(nums, target);
            int right = RightBound(nums, target);
            return new int[]{left, right};
        }

        public int LeftBound(int[] nums, int target) {
            int left = 0;
            int right = nums.Length;
            while (left < right)
            {
                int mid = left + ((right - left)/2);
                if (nums[mid] < target) 
                {
                    left = mid + 1;
                }else
                {
                    right = mid;
                }
            }
            

            return left < nums.Length && nums[left] == target ? left : -1;
        }

        public int RightBound(int[] nums, int target) {
            int left = 0, right = nums.Length;
    
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target) {
                    left = mid + 1; // 注意
                } else if (nums[mid] < target) {
                    left = mid + 1;
                } else if (nums[mid] > target) {
                    right = mid;
                }
            }
            
            if (left - 1 < 0) return -1;
            return nums[left-1] == target ? left-1 : -1;
        }

        static void Main(string[] args)
        {
            SearchRange34 instance = new SearchRange34();
            int[] nums = new int[0];
            int target = 0;
            Console.WriteLine("left bound: {0}", instance.LeftBound(nums, target));  
            Console.WriteLine("right bound: {0}", instance.RightBound(nums, target));  
            
        }
    }
}
