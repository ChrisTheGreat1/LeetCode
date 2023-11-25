using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an integer array nums, return the length of the longest strictly increasing subsequence


    Input: nums = [10,9,2,5,3,7,101,18]
    Output: 4
    Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.


    Input: nums = [0,1,0,3,2,3]
    Output: 4


    Input: nums = [7,7,7,7,7,7,7]
    Output: 1
 
    Constraints:

    1 <= nums.length <= 2500
    -10^4 <= nums[i] <= 10^4

    */
    internal class _0300_LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            Array.Fill(dp, 1);

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }
            }
            return dp.Max();
        }
    }
}
