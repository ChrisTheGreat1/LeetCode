using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    You are given an integer array nums and an integer target.

    You want to build an expression out of nums by adding one of the symbols '+' and '-' 
    before each integer in nums and then concatenate all the integers.

    For example, if nums = [2, 1], you can add a '+' before 2 and a '-' before 1 and concatenate them to build the expression "+2-1".
    Return the number of different expressions that you can build, which evaluates to target.

 
    Input: nums = [1,1,1,1,1], target = 3
    Output: 5
    Explanation: There are 5 ways to assign symbols to make the sum of nums be target 3.
    -1 + 1 + 1 + 1 + 1 = 3
    +1 - 1 + 1 + 1 + 1 = 3
    +1 + 1 - 1 + 1 + 1 = 3
    +1 + 1 + 1 - 1 + 1 = 3
    +1 + 1 + 1 + 1 - 1 = 3


    Input: nums = [1], target = 1
    Output: 1
 

    Constraints:

    1 <= nums.length <= 20
    0 <= nums[i] <= 1000
    0 <= sum(nums[i]) <= 1000
    -1000 <= target <= 1000

    */
    internal class _0494_TargetSum
    {
        public int FindTargetSumWays(int[] nums, int target)
        {
            return Find(nums, target, nums.Length - 1, 0);
        }

        private int Find(int[] nums, int target, int l, int sum)
        {
            if (l < 0 & sum != target) return 0;
            if (l < 0 && sum == target) return 1;

            int m1t, m2t;

            int m1 = Find(nums, target, l - 1, sum + nums[l]);

            if (m1 == 0)
            {
                m1t = 0;
            }
            else
            {
                m1t = m1;
            }

            int m2 = Find(nums, target, l - 1, sum - nums[l]);

            if (m2 == 0)
            {
                m2t = 0;
            }
            else
            {
                m2t = m2;
            }

            return m1t + m2t;
        }

    }
}
