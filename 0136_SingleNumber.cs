using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.

    You must implement a solution with a linear runtime complexity and use only constant extra space.


    Input: nums = [2,2,1]
    Output: 1


    Input: nums = [4,1,2,1,2]
    Output: 4


    Input: nums = [1]
    Output: 1
 

    Constraints:

    1 <= nums.length <= 3 * 10^4
    -3 * 10^4 <= nums[i] <= 3 * 10^4
    Each element in the array appears twice except for one element which appears only once.

    */
    internal class _0136_SingleNumber
    {
        public int SingleNumber(int[] nums)
        {
            var x = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                x ^= nums[i]; // XOR
            }
            return x;
        }
    }
}
