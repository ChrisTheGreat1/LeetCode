using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace LeetCode
{
    /*
     *
    You are given two non-empty linked lists representing two non-negative integers.
    The digits are stored in reverse order, and each of their nodes contains a single digit.
    Add the two numbers and return the sum as a linked list.

    You may assume the two numbers do not contain any leading zero, except the number 0 itself.

    ***************************************************************************************************

    Linked lists have several advantages over regular lists in C#. Some of these advantages include:

    Dynamic size: Linked lists do not have a fixed size, so you can add or remove elements as needed, without having to worry about the size of the list1.

    Efficient Insertion and Deletion: Inserting or deleting elements in a linked list is fast and efficient, as you only need to modify the reference of the next node, which is an O(1) operation1.

    Memory efficiency: Linked lists can be more memory-efficient than arrays, especially when dealing with large data sets1.

    Easy implementation of abstract data types: Linked lists can be used to implement abstract data types such as stacks, queues, and associative arrays1.

    More efficient sorting in some cases: Linked lists can be more efficient than arrays when sorting data in certain situations1.

    */

    internal class _0002_AddTwoNumbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();
            ListNode head = result;
            int sum = 0;
            while (l1 != null || l2 != null || sum > 0) // to keep running if we hava a value in l1, l2 or carry
            {
                // two if statments because l1 and l2 can be of different sizes
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                result.next = new ListNode(sum % 10); //digit
                sum /= 10; //carry
                result = result.next;
            }
            return head.next; //we don't want to return head as it will add a node=0 at the start so -> wrong answer
        }

        internal class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}