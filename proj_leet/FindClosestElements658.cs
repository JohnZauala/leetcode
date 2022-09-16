using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //658. 找到 K 个最接近的元素
    //https://leetcode.cn/problems/find-k-closest-elements/
    class FindClosestElements658
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x) 
        {
            int bigIdx = FindClosest(arr, x);
            int left = bigIdx-1;
            int right = bigIdx;
            List<int> res = new List<int>();
            while(res.Count < k) {
                if (left >= 0 && right<arr.Length) {
                    if (Math.Abs(arr[left] - x) <= Math.Abs(arr[right]-x)) {
                        res.Add(arr[left]);
                        left--;
                    } else {
                        res.Add(arr[right]);
                        right++;
                    }
                } else if (left >= 0) {
                    res.Add(arr[left]);
                    left--;
                } else if (right<arr.Length) {
                    res.Add(arr[right]);
                    right++;
                }
               
            }
            res.Sort();
            return res;
        }

        public int FindClosest(int[] arr, int x) {
            int left = 0;
            int right = arr.Length - 1;
            int ans = 0;
            while(left <= right) {
                int mid = left + (right-left)/2;
                if (arr[mid] == x) {
                    return mid;
                } else if(arr[mid] < x) {
                    left = mid+1;
                } else {
                    ans = mid;
                    right = mid-1;
                }
            }
           
            if (left-1<0) return 0;
            if (left >= arr.Length) return arr.Length-1;
            // if (ans == 0) return arr.Length-1;

            return ans;
        }

        static void Main(string[] args)
        {
            FindClosestElements658 instance = new FindClosestElements658();
            int[] nums = new int[]{1,2,2,2,5,5,5,8,9,9};
            int k = 4;
            int x = 15;
            
            Console.WriteLine("找到 K 个最接近的元素:{0}", string.Join(",", instance.FindClosestElements(nums, k, x)));

        
        }
    }
}
