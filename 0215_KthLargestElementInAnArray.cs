using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an integer array nums and an integer k, return the kth largest element in the array.

    Note that it is the kth largest element in the sorted order, not the kth distinct element.

    Can you solve it without sorting?

    Input: nums = [3,2,1,5,6,4], k = 2
    Output: 5

    Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
    Output: 4

    Constraints:

    1 <= k <= nums.length <= 10^5
    -10^4 <= nums[i] <= 10^4

    */

    internal class _0215_KthLargestElementInAnArray
    {
        public int FindKthLargest(int[] nums, int k)
        {
            var queue = new PriorityQueue<int, int>();

            foreach(var num in nums) 
            {
                if (queue.Count < k)
                {
                    queue.Enqueue(num, num);
                }
                    
                else
                {
                    if (num <= queue.Peek()) continue;

                    queue.Dequeue();
                    queue.Enqueue(num, num);
                }
            }

            return queue.Dequeue();
        }
    }
}
