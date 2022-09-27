using System;
using System.Collections.Generic;
using System.Linq;
namespace LC
{
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }

        public ListNode() {

      }
  }
    //147. 对链表进行插入排序
    //https://leetcode.cn/problems/insertion-sort-list/
    class InsertionSortList147
    {
        public ListNode InsertionSortList(ListNode head) 
        {
            ListNode dummy = new ListNode(Int32.MinValue, null);
            ListNode cur = head;
            ListNode sorted = dummy;
            while(cur != null) 
            {
                ListNode next = cur.next;
                cur.next = null;
                ListNode sortedH = dummy;
                ListNode sortedPre = dummy;
                while(sortedH != null) {
                    // Console.WriteLine("curVal: {0}, ")
                    if (cur.val <= sortedH.val) {
                        cur.next = sortedH;
                        sortedPre.next = cur;  
                        break;
                    }
                    sortedPre = sortedH;
                    sortedH = sortedH.next;
                }

                if (cur.next == null) {
                    sortedPre.next = cur;
                }

                cur = next;
            }
            return dummy.next;
        }

        // static void Main(string[] args)
        // {
        //     InsertionSortList147 instance = new InsertionSortList147();
            
        //     int[] head = new int[]{-1,5,3,4,0};
        //     ListNode h = GetListByArray(head);
        //     ListNode ret = instance.InsertionSortList(h);
        //     PrintList(ret);
        // }

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
