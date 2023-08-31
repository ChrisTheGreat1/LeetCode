using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

    Given an integer array nums of length n and an integer target, find three integers in nums such that the sum is closest to target.

    Return the sum of the three integers.

    You may assume that each input would have exactly one solution.

    Input: nums = [-1,2,1,-4], target = 1
    Output: 2
    Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

    Input: nums = [0,0,0], target = 1
    Output: 0
    Explanation: The sum that is closest to the target is 0. (0 + 0 + 0 = 0).

    Constraints:

    3 <= nums.length <= 500
    -1000 <= nums[i] <= 1000
    -10^4 <= target <= 10^4

    */

    internal class _16_3SumClosest
    {
        //int[] nums = new int[] { -1, 2, 1, -4 };
        //int[] nums = new int[] { 0, 0, 0 };
        //int[] nums = new int[] { 1, 2, 3 };

        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length == 3) return (nums.ToList().Select(n => n).Sum());

            var sortedNums = nums;
            Array.Sort(sortedNums);

            int start = 0;
            int closest = int.MaxValue;
            int smallestDifference = int.MaxValue;
            int left, right, difference, testSum;

            while (start < nums.Length - 2)
            {
                left = start + 1;
                right = nums.Length - 1;

                while (left < right)
                {
                    testSum = sortedNums[left] + sortedNums[right] + sortedNums[start];

                    if (testSum > target)
                    {
                        --right;
                        difference = Math.Abs(testSum - target);
                    }
                    else if (testSum < target)
                    {
                        ++left;
                        difference = Math.Abs(testSum - target);
                    }
                    else // ie. testSum = target
                    {
                        return target;
                    }

                    if (difference < smallestDifference)
                    {
                        closest = testSum;
                        smallestDifference = difference;
                    }
                }

                ++start;
            }

            return closest;
        }
    }
}