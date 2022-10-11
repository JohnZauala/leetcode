using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/linked-list-cycle-ii/?favorite=ex0k24j
//142. 环形链表 II

  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) {
          val = x;
          next = null;
     }
  }

class DetectCycle142
{
   public ListNode DetectCycle(ListNode head) {
        ListNode fast = head;
        ListNode slow = head;

        bool isCycle = false;
        while(fast != null && fast.next != null) 
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) {
                isCycle = true;
                break;
            }
                
        }


        if (isCycle) 
        {
            slow = head;
            while (slow != fast) {
                slow = slow.next;
                fast = fast.next;
            }

            return slow;
        }

        return null;
    

    }

    


    // public ListNode RotateRightOne(ListNode head)
    // {
    //     ListNode dummy = new ListNode(0, head);
    //     ListNode h = head;
    //     while()
    // }
    // static void Main(string[] args)
    // {

    //     // int[] nums = new int[]{1,3,-1,-3,5,3,6,7};
    //     // int k = 3;

    //     int[] nums = new int[]{1};
    //     int k = 1;
    //     var instance = new MaxSlidingWindow239();
    //     Console.WriteLine("FindOrder210: {0}", string.Join(",", instance.MaxSlidingWindow(nums, k)) );
        
    // }
}