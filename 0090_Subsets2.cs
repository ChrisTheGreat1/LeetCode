using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an integer array nums that may contain duplicates, return all possible 
    subsets (the power set).

    The solution set must not contain duplicate subsets. Return the solution in any order.

    Input: nums = [1,2,2]
    Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]

    Input: nums = [0]
    Output: [[],[0]]
 
    Constraints:

    1 <= nums.length <= 10
    -10 <= nums[i] <= 10

    */

    // Could also solve by using solution for 0078_Subsets then just returning the distinct results?

    internal class _0090_Subsets2
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var list = new List<IList<int>>();
            Array.Sort(nums);
            backTrack(list, new List<int>(), nums, 0);
            return list;
        }

        private void backTrack(List<IList<int>> list, List<int> curr, int[] nums, int start)
        {
            list.Add(new List<int>(curr));
            for (var i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue;
                curr.Add(nums[i]);
                backTrack(list, curr, nums, i + 1);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }
}
