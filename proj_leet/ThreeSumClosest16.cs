using System;
using System.Collections.Generic;

class ThreeSumClosest16
{
    public int ThreeSumClosest(int[] nums, int target) 
    {
        Array.Sort(nums);

        int N = nums.Length;
        int sum = nums[0] + nums[1] + nums[2];
        for (int i = 0; i < N; i++)
        {
            int left = i + 1;
            int right = N - 1;
            while(left < right) {
                int curSum = nums[i] + nums[left] + nums[right];
                if (curSum == target)
                    return curSum;

                if (Math.Abs(curSum - target) < Math.Abs(sum - target))
                    sum = curSum;

                if (curSum < target) {
                    left++;
                }

                if (curSum > target) {
                    right--;
                }

            }
        }

        return sum;
    }

    static void Main(string[] args)
    {
        int[] nums = new int[]{-1,2,1,-4};
        int target = 1;
        var instance = new ThreeSumClosest16();
        Console.WriteLine("ThreeSumClosest16: {0}", instance.ThreeSumClosest(nums, target));
        
    }
}