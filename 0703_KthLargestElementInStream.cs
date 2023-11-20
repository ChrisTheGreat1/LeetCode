using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Design a class to find the kth largest element in a stream. Note that it is the kth largest 
    element in the sorted order, not the kth distinct element.

    Implement KthLargest class:

    KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
    int add(int val) Appends the integer val to the stream and returns the element representing the kth largest element in the stream.

    Input
    ["KthLargest", "add", "add", "add", "add", "add"]
    [[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
   
    Output
    [null, 4, 5, 5, 8, 8]

    Explanation
    KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
    kthLargest.add(3);   // return 4
    kthLargest.add(5);   // return 5
    kthLargest.add(10);  // return 5
    kthLargest.add(9);   // return 8
    kthLargest.add(4);   // return 8
 
    Constraints:

    1 <= k <= 10^4
    0 <= nums.length <= 10^4
    -10^4 <= nums[i] <= 10^4
    -10^4 <= val <= 10^4
    At most 10^4 calls will be made to add.
    It is guaranteed that there will be at least k elements in the array when you search for the kth element.

    */

    /**
     * Your KthLargest object will be instantiated and called as such:
     * KthLargest obj = new KthLargest(k, nums);
     * int param_1 = obj.Add(val);
     */

    internal class _0703_KthLargestElementInStream
    {
        public class KthLargest
        {
            PriorityQueue<int, int> data = new PriorityQueue<int, int>();
            int k;

            public KthLargest(int k, int[] nums)
            {
                this.k = k;
                foreach (var num in nums)
                    Add(num);
            }

            public int Add(int val)
            {
                data.Enqueue(val, val);

                if (data.Count > k)
                    data.Dequeue();

                return data.Peek();
            }
        }

        // Valid but time limit exceeds.
        /*
        public class KthLargest
        {
            private int _k;
            private List<int> _nums;

            public KthLargest(int k, int[] nums)
            {
                _k = k;
                _nums = nums.ToList();
            }

            public int Add(int val)
            {
                _nums.Add(val);
                _nums = _nums.OrderByDescending(x => x).ToList();
                return _nums[_k - 1];
            }
        }
        */
    }
}

