using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
     
    Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

    You must write an algorithm that runs in O(n) time.


    Input: nums = [100,4,200,1,3,2]
    Output: 4
    Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

    Input: nums = [0,3,7,2,5,8,4,6,0,1]
    Output: 9

    Constraints:

    0 <= nums.length <= 10^5
    -10^9 <= nums[i] <= 10^9

    */
    internal class _0128_LongestConsecutiveSequence
    {
        //var nums = new int[] { 100, 4, 200, 1, 3, 2 };
        //var nums = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }; 
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            int maxLength = 0;

            foreach (int num in nums)
            {
                if (set.Contains(num - 1)) continue;

                int length = 0;
                while (set.Contains(num + length)) length++;

                maxLength = Math.Max(maxLength, length);
            }

            return maxLength;
        }
    }
}
