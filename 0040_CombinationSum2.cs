using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given a collection of candidate numbers (candidates) and a target number (target), 
    find all unique combinations in candidates where the candidate numbers sum to target.

    Each number in candidates may only be used once in the combination.

    Note: The solution set must not contain duplicate combinations.

    Input: candidates = [10,1,2,7,6,1,5], target = 8
    Output: 
    [
    [1,1,6],
    [1,2,5],
    [1,7],
    [2,6]
    ]


    Input: candidates = [2,5,2,1,2], target = 5
    Output: 
    [
    [1,2,2],
    [5]
    ]
 

    Constraints:

    1 <= candidates.length <= 100
    1 <= candidates[i] <= 50
    1 <= target <= 30

    */
    internal class _0040_CombinationSum2
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(candidates);

            dfs(0, new Stack<int>(), target);
            return result;

            void dfs(int pos, Stack<int> current, int target)
            {
                if (target == 0)
                {
                    result.Add(current.ToList());
                }
                if (target <= 0)
                {
                    return;
                }

                var prev = -1;

                for (var i = pos; i < candidates.Length; i++)
                {
                    if (candidates[i] == prev)
                        continue;

                    current.Push(candidates[i]);
                    dfs(i + 1, current, target - candidates[i]);
                    current.Pop();
                    prev = candidates[i];
                }
            }
        }
    }
}
