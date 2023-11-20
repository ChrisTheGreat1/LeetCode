using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an integer array nums of unique elements, return all possible 
    subsets (the power set).

    The solution set must not contain duplicate subsets. Return the solution in any order.

    Input: nums = [1,2,3]
    Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

    Input: nums = [0]
    Output: [[],[0]]

    Constraints:

    1 <= nums.length <= 10
    -10 <= nums[i] <= 10
    All the numbers of nums are unique.

    */

    // Total number of subsets is 2^n

    internal class _0078_Subsets
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            backtrack(0, nums);
            return result;
        }

        private List<int> subset = new();
        private List<IList<int>> result = new();
        private void backtrack(int i, int[] nums)
        {
            if (i >= nums.Length)
            {
                result.Add(new List<int>(subset));
                return;
            }
            subset.Add(nums[i]);
            backtrack(i + 1, nums);
            subset.Remove(nums[i]);
            backtrack(i + 1, nums);
        }
    }
}
