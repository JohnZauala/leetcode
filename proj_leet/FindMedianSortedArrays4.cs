using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //4. 寻找两个正序数组的中位数
    //https://leetcode.cn/problems/median-of-two-sorted-arrays/
    class FindMedianSortedArrays4
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int left = (m + n + 1)/2;
            int right = (m + n + 2)/2;
            int l = FindElementK(nums1, 0, m-1, nums2, 0, n-1, left);
            int r = FindElementK(nums1, 0, m-1, nums2, 0, n-1, right);
            return (l+r)/2.0d;
        }

        public int FindElementK(int[] nums1, int start1, int end1, int[] nums2, int start2, int end2, int k)
        {
            int len1 = end1-start1+1;
            int len2 = end2-start2+1;
            
            if (len1 == 0) return nums2[start2+k-1];
            if (len2 == 0) return nums1[start1+k-1];

            if (k == 1) {
                return Math.Min(nums1[start1], nums2[start2]);
            }
            
            int i = start1 + Math.Min(k/2, len1) - 1;
            int j = start2 + Math.Min(k/2, len2) - 1;
            if (nums1[i] < nums2[j]) {
                return FindElementK(nums1, i+1, end1, nums2, start2, end2, k - (i-start1+1));
            } else {
                return FindElementK(nums1, start1, end1, nums2, j+1, end2, k - (j-start2+1));
            }
            
        }

        // static void Main(string[] args)
        // {
        //     FindMedianSortedArrays4 instance = new FindMedianSortedArrays4();
        //     int[] nums1 = new int[]{1,2,5,6};
        //     int[] nums2 = new int[]{3,4};
           
        //     Console.WriteLine("寻找两个正序数组的中位数:{0}", instance.FindMedianSortedArrays(nums1, nums2));
        
        // }
    }
}
