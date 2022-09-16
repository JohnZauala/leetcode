using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //611. 有效三角形的个数
    //https://leetcode.cn/problems/valid-triangle-number/
    class TriangleNumber611
    {
        public int TriangleNumber(int[] nums) 
        {
            int N = nums.Length;
            Array.Sort(nums);
            int ans = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i+1; j < N; j++)
                {
                    int left = j+1;
                    int right = N-1;
                    while(left <= right) {
                        int mid = left + (right-left)/2;
                        // Console.WriteLine("left : {0}, mid: {1}, right: {2}", left, mid, right);
                        
                        if (nums[i] + nums[j] <= nums[mid]) {
                            right = mid - 1;
                        } else
                        {
                            left = mid+1;
                        }
                    }

                    
                    ans += Math.Max(right-(j+1)+1, 0);
                }
            }
            return ans;
        }

        // static void Main(string[] args)
        // {
        //     TriangleNumber611 instance = new TriangleNumber611();
        //     int[] nums = new int[]{4,2,3,4};
            
        //     Console.WriteLine("有效三角形的个数:{0}", instance.TriangleNumber(nums));

        
        // }
    }
}
