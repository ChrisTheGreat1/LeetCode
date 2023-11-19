using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCode._0002_AddTwoNumbers;

namespace LeetCode
{

    /*
    
    Given the head of a singly linked list, reverse the list, and return the reversed list.

    Input: head = [1,2,3,4,5]
    Output: [5,4,3,2,1]

    Input: head = [1,2]
    Output: [2,1]

    Input: head = []
    Output: []

    The number of nodes in the list is the range [0, 5000].
    -5000 <= Node.val <= 5000

    */

    internal class _0206_ReverseLinkedList
    {
        public void Result()
        {
            var node1 = new ListNode(5);
            var node2 = new ListNode(4, node1);
            var node3 = new ListNode(3, node2);
            var node4 = new ListNode(2, node3);
            var node5 = new ListNode(1, node4);

            var result = ReverseList(node5);
        }

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode prev = null, curr = head;

            // Simply break the chain and reverse the directions. But you first need to save the "next" node in temp
            while (curr != null)
            {
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }

            return prev;
        }
    }
}
