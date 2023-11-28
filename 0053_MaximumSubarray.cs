using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an integer array nums, find the 
    subarray with the largest sum, and return its sum.


    Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
    Output: 6
    Explanation: The subarray [4,-1,2,1] has the largest sum 6.


    Input: nums = [1]
    Output: 1
    Explanation: The subarray [1] has the largest sum 1.


    Input: nums = [5,4,-1,7,8]
    Output: 23
    Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
 

    Constraints:

    1 <= nums.length <= 10^5
    -10^4 <= nums[i] <= 10^4

    */
    internal class _0053_MaximumSubarray
    {
        // Basically a sliding window. Whenever accumulated sum goes negative, shift over to the next positive element and start counting again
        public int MaxSubArray(int[] nums)
        {
            int maxSub = nums[0];
            int curSum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (curSum < 0)
                {
                    curSum = 0;
                }
                curSum += nums[i];
                maxSub = Math.Max(maxSub, curSum);
            }
            return maxSub;
        }
    }
}
