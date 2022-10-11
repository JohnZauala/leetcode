using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/rotate-list/?favorite=ex0k24j
//61. 旋转链表

 public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }

class RotateRight61
{
    public ListNode RotateRight(ListNode head, int k) 
    {
        List<ListNode> list = new List<ListNode>();
        ListNode h = head;
    
        while(h != null) {
            list.Add(h);
            h = h.next;
        }

        int len  = list.Count;
        k = k % len;
        if (k == 0)
            return head;

        ListNode last = list[len-k-1];
        last.next = null;

        ListNode h = list[len-l];
        while(h.next != null) {
            h = h.next;
        }

        h.next = head;
        return head;
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