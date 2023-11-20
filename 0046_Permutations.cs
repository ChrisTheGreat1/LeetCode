using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

    Input: nums = [1,2,3]
    Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

    Input: nums = [0,1]
    Output: [[0,1],[1,0]]

    Input: nums = [1]
    Output: [[1]]
 
    Constraints:

    1 <= nums.length <= 6
    -10 <= nums[i] <= 10
    All the integers of nums are unique.

    */


    internal class _0046_Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Backtrack(nums, new List<int>(), result);
            return result;
        }

        private void Backtrack(int[] nums, List<int> path, IList<IList<int>> result)
        {
            if (path.Count == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }
            foreach (int num in nums)
            {
                if (path.Contains(num)) continue;
                path.Add(num);
                Backtrack(nums, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
