using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //287. 寻找重复数
    //https://leetcode.cn/problems/find-the-duplicate-number/
    class FindDuplicate287
    {
        public int FindDuplicate(int[] nums) 
        {
            int slow = 0;
            int fast = 0;
            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            } while (slow != fast);

            slow = 0;
            while(fast != slow) {
                slow = nums[slow];
                fast = nums[fast];
            }

            return slow;
        }
    }
}
