using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an integer array nums, find a subarray that has the largest product, and return the product.

    The test cases are generated so that the answer will fit in a 32-bit integer.


    Input: nums = [2,3,-2,4]
    Output: 6
    Explanation: [2,3] has the largest product 6.


    Input: nums = [-2,0,-1]
    Output: 0
    Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
 

    Constraints:

    1 <= nums.length <= 2 * 10^4
    -10 <= nums[i] <= 10
    The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

    */
    internal class _0152_MaximumProductSubarray
    {

        public int MaxProduct(int[] nums)
        {
            var maxProduct = nums.Max();
            (int curMin, int curMax) = (1, 1);

            foreach (var num in nums)
            {
                var tmp = curMax * num;

                curMax = new int[] { num, num * curMin, num * curMax }.Max();
                curMin = new int[] { num, num * curMin, tmp }.Min(); // Keep track of min products to account for negative values that will negate if another negative is multiplied in.

                maxProduct = Math.Max(maxProduct, curMax);
            }

            return maxProduct;
        }
    }
}
