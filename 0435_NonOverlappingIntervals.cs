using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array of intervals intervals where intervals[i] = [starti, endi], 
    return the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.


    Input: intervals = [[1,2],[2,3],[3,4],[1,3]]
    Output: 1
    Explanation: [1,3] can be removed and the rest of the intervals are non-overlapping.


    Input: intervals = [[1,2],[1,2],[1,2]]
    Output: 2
    Explanation: You need to remove two [1,2] to make the rest of the intervals non-overlapping.


    Input: intervals = [[1,2],[2,3]]
    Output: 0
    Explanation: You don't need to remove any of the intervals since they're already non-overlapping.
 

    Constraints:

    1 <= intervals.length <= 10^5
    intervals[i].length == 2
    -5 * 10^4 <= starti < endi <= 5 * 10^4

    */
    internal class _0435_NonOverlappingIntervals
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            var sortedIntervals = intervals.Clone() as int[][];
            Array.Sort(sortedIntervals, (a, b) => a[0] - b[0]);

            var result = 0;
            var prevEnd = sortedIntervals[0][1];

            for (var i = 1; i < sortedIntervals.Length; i++)
            {
                var curr = sortedIntervals[i];

                if (prevEnd > curr[0])
                {
                    result++;
                    prevEnd = Math.Min(prevEnd, curr[1]);
                }
                else
                {
                    prevEnd = curr[1];
                }
            }

            return result;
        }
    }
}
