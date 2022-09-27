using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
    //148. 排序链表
    //https://leetcode.cn/problems/sort-list/?favorite=2ckc81c
    class SortList148
    {
        public ListNode SortList(ListNode head) 
        {
            if (head == null || head.next == null)
                return head;

            ListNode mid = FindMid(head);
            // Console.WriteLine("mid:{0}", mid.val);
            ListNode tmp = mid.next;
            mid.next = null;
            ListNode h1 = SortList(head);
            ListNode h2 = SortList(tmp);
            // PrintList(h1);
            // PrintList(h2);
           
            return SortListMerge(h1, h2);
        }

        public ListNode SortListMerge(ListNode h1, ListNode h2)
        {   
            //合并
            ListNode dummy = new ListNode();
            ListNode h = dummy;
            ListNode tH1 = h1;
            ListNode tH2 = h2;
          
            while(tH1 != null && tH2 != null)
            {
                if (tH1.val <= tH2.val)
                {
                    h.next = tH1;
                    tH1 = tH1.next;
                } else {
                    h.next = tH2;
                    tH2 = tH2.next;
                }
                h = h.next;
                
            }

            if (tH1 != null) 
            {
                h.next = tH1;
            }
            if (tH2 != null)
            {
                h.next = tH2;
            }

            // PrintList(h1);
            // PrintList(h2);

            return dummy.next;
        }

        public ListNode FindMid(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while(fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

    //    static void Main(string[] args)
    //     {
    //         SortList148 instance = new SortList148();
            
    //         int[] head = new int[]{-1,3,4,0};
    //         ListNode h = GetListByArray(head);
    //         ListNode ret = instance.SortList(h);
    //         PrintList(ret);
    //     }

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
