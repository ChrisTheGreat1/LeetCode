using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array of distinct integers candidates and a target integer target, return a list of all unique 
    combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

    The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the 
    frequency of at least one of the chosen numbers is different.

    The test cases are generated such that the number of unique combinations that sum up to target is less 
    than 150 combinations for the given input.


    Input: candidates = [2,3,6,7], target = 7
    Output: [[2,2,3],[7]]
    Explanation:
    2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
    7 is a candidate, and 7 = 7.
    These are the only two combinations.


    Input: candidates = [2,3,5], target = 8
    Output: [[2,2,2,2],[2,3,3],[3,5]]


    Input: candidates = [2], target = 1
    Output: []
 

    Constraints:

    1 <= candidates.length <= 30
    2 <= candidates[i] <= 40
    All elements of candidates are distinct.
    1 <= target <= 40

    */
    internal class _0039_CombinationSum
    {
        private IList<IList<int>> result = new List<IList<int>>();

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            backtrack(0, new List<int>(), 0, candidates, target);
            return result;
        }

        private void backtrack(int index, List<int> path, int total, int[] candidates, int target)
        {
            if (total == target)
            {
                result.Add(path.ToList());
                return;
            }

            if (total > target || index >= candidates.Length) return;

            // Always a 2-decision tree, take one path where you are adding candidates[index] to path,
            // and take other path where you are not adding candidates[index] to path but incrementing the pointer
            // to the next member of the array

            path.Add(candidates[index]);

            backtrack(index,
                      path,
                      total + candidates[index],
                      candidates,
                      target);

            path.Remove(path.Last());

            backtrack(index + 1,
                      path,
                      total,
                      candidates,
                      target);
        }
    }
}
