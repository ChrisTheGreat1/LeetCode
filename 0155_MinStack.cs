using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

    Implement the MinStack class:

    MinStack() initializes the stack object.
    void push(int val) pushes the element val onto the stack.
    void pop() removes the element on the top of the stack.
    int top() gets the top element of the stack.
    int getMin() retrieves the minimum element in the stack.
    You must implement a solution with O(1) time complexity for each function.

    Input
    ["MinStack","push","push","push","getMin","pop","top","getMin"]
    [[],[-2],[0],[-3],[],[],[],[]]

    Output
    [null,null,null,null,-3,null,0,-2]

    Explanation
    MinStack minStack = new MinStack();
    minStack.push(-2);
    minStack.push(0);
    minStack.push(-3);
    minStack.getMin(); // return -3
    minStack.pop();
    minStack.top();    // return 0
    minStack.getMin(); // return -2

    Constraints:

    -2^31 <= val <= 2^31 - 1
    Methods pop, top and getMin operations will always be called on non-empty stacks.
    At most 3 * 10^4 calls will be made to push, pop, top, and getMin.

    */
    internal class _0155_MinStack
    {
        public class MinStack
        {

            /** initialize your data structure here. */
            private Node _head;
            private int min = int.MaxValue;

            public MinStack()
            {

            }

            public void Push(int x)
            {
                if (min > x)
                {
                    min = x;
                }

                if (_head == null)
                {
                    _head = new Node(x);
                    return;
                }

                var oldHead = _head;
                _head = new Node(x);
                _head.next = oldHead;
            }

            public void Pop()
            {
                if (_head.val == min)
                {
                    min = int.MaxValue;
                }

                var oldHead = _head;
                _head = oldHead.next;

                var current = _head;
                while (current != null)
                {
                    if (current.val < min)
                    {
                        min = current.val;
                    }
                    current = current.next;
                }
            }

            public int Top()
            {
                return _head.val;
            }

            public int GetMin()
            {
                return min;
            }
        }

        public class Node
        {
            public int val;
            public Node next;

            public Node(int val)
            {
                this.val = val;
            }
        }
    }
}
