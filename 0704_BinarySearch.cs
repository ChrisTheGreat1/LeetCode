using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.

    You must write an algorithm with O(log n) runtime complexity.

    Input: nums = [-1,0,3,5,9,12], target = 9
    Output: 4
    Explanation: 9 exists in nums and its index is 4

    Input: nums = [-1,0,3,5,9,12], target = 2
    Output: -1
    Explanation: 2 does not exist in nums so return -1

    Constraints:

    1 <= nums.length <= 10^4
    -10^4 < nums[i], target < 10^4
    All the integers in nums are unique.
    nums is sorted in ascending order.

    */
    internal class _0704_BinarySearch
    {
        //var nums = new int[] {-1,0,3,5,9,12}; 
        //var target = 9;
        //var target = 2;

        public int Search(int[] nums, int target)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2; // Integer division rounds down

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] > target)
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }

            return -1;
        }
    }
}
