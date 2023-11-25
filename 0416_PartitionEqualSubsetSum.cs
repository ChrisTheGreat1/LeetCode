using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an integer array nums, return true if you can partition the array into 
    two subsets such that the sum of the elements in both subsets is equal or false otherwise.


    Input: nums = [1,5,11,5]
    Output: true
    Explanation: The array can be partitioned as [1, 5, 5] and [11].


    Input: nums = [1,2,3,5]
    Output: false
    Explanation: The array cannot be partitioned into equal sum subsets.
 

    Constraints:

    1 <= nums.length <= 200
    1 <= nums[i] <= 100

    */

    internal class _0416_PartitionEqualSubsetSum
    {
        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();
            if (sum % 2 == 1)
            {
                return false;
            }
            int needsum = sum / 2;


            bool[] dp = new bool[needsum + 1];

            dp[0] = true;

            foreach (int num in nums)
            {
                for (int i = needsum; i > 0; i--)
                {
                    if (i >= num)
                    {
                        dp[i] = dp[i] || dp[i - num];
                    }
                }
            }

            return dp[needsum];
        }

        /*
        public bool CanPartition(int[] nums)
        {
            var sum = nums.Sum();
            if (sum % 2 != 0)
            {
                return false;
            }

            return subSetSum(nums, sum / 2);
        }

        private bool subSetSum(int[] nums, int target)
        {
            var dp = new bool[nums.Length + 1, target + 1];

            for (var i = 0; i < nums.Length + 1; i++)
            {
                for (var j = 0; j < target + 1; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = false;
                    }
                    if (j == 0)
                    {
                        dp[i, j] = true;
                    }
                }
            }

            for (var i = 1; i < nums.Length + 1; i++)
            {
                for (var j = 1; j < target + 1; j++)
                {
                    if (nums[i - 1] <= j)
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                    }
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }

            return dp[nums.Length, target];
        }

        */
    }
}
