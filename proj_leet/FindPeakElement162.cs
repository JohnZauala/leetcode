using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //162. 寻找峰值
    //https://leetcode.cn/problems/find-peak-element/?favorite=2ckc81c
    class FindPeakElement162
    {
        public int FindPeakElement(int[] nums) 
        {
            int N = nums.Length;
            if (N == 1) {
                return 0;
            } 
            
            int left = 0;
            int right = N - 1;
            if (nums[left] > nums[left+1]) 
            {
                return left;
            } else if (nums[right] > nums[right-1]) 
            {
                return right;   
            }

            while(left <= right) {
                
                int mid = left + (right-left)/2;
            
                Console.WriteLine("left: {0}, mid : {1}, right:{2}", left, mid, right);
                if (nums[mid] > nums[mid-1] && nums[mid] > nums[mid+1]) {
                    return mid;
                } else if (nums[left] < nums[left+1] && nums[mid] < nums[mid-1]) {
                    right = mid - 1;
                } else if (nums[right] < nums[right-1] && nums[mid] < nums[mid+1]) {
                    left = mid + 1;
                } else {
                    if (nums[left] < nums[left+1]) {
                        while(left < mid) {
                            if (nums[mid] > nums[mid-1] && nums[mid] > nums[mid+1]) {
                                 return mid;
                            } else if (nums[mid] < nums[mid]-1){
                                right = mid;
                            }
                            mid--;
                        }
                    }
                }
            }
            return -1;
        }

        // static void Main(string[] args)
        // {
        //     FindPeakElement162 instance = new FindPeakElement162();
        //     // int[] nums = new int[]{1,2,1,3,5,6,4};
        //     // int[] nums = new int[]{1,2,3,1};
        //     int[] nums = new int[]{3,4,3,2,1};
           
        //     Console.WriteLine("峰值元素:{0}", instance.FindPeakElement(nums));

        
        // }
    }
}
