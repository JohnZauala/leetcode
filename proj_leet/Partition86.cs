using System;
using System.Collections.Generic;

//https://leetcode.cn/problems/partition-list/
//86. 分隔链表
namespace Partition86
{
    public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
    }

    class Partition86
    {
        public ListNode Partition(ListNode head, int x) 
        {
            ListNode dummyL = new ListNode();
           
            ListNode dummyG = new ListNode();
            ListNode hG = dummyG, hL = dummyL;
            ListNode h = head;
            while(h != null) {
                if (h.val < x) {
                    hL.next = h;
                    hL = hL.next;
                } else
                {
                    hG.next = h;
                    hG = hG.next;   
                }

                h = h.next;
            }

            hL.next = dummyG.next;
            hG.next = null;
            return dummyL.next;
        }

        static void Main(string[] args)
        {
            Partition86 instance = new Partition86();
            
            int[] head = new int[]{2, 1};
            int x = 2;
            ListNode h = GetListByArray(head);
            ListNode ret = instance.Partition(h, x);
            PrintList(ret);
        }

    static ListNode GetListByArray(int[] arr)
    {
        ListNode dummy = new ListNode();
        ListNode head = dummy;
        for (int i = 0; i < arr.Length; i++)
        {
        head.next = new ListNode(arr[i], null);
        head = head.next;
        }
        return dummy.next;
    }

    static void PrintList(ListNode head)
    {
        Console.WriteLine("链表：");
        while(head != null) 
        {
            Console.Write("{0},", head.val);
            head = head.next;
        }
        Console.WriteLine("");
    }
    }

        
    
        
}
