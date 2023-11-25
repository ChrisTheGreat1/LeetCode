using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, 
    and return an array of the non-overlapping intervals that cover all the intervals in the input.


    Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
    Output: [[1,6],[8,10],[15,18]]
    Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].


    Input: intervals = [[1,4],[4,5]]
    Output: [[1,5]]
    Explanation: Intervals [1,4] and [4,5] are considered overlapping.
 

    Constraints:

    1 <= intervals.length <= 10^4
    intervals[i].length == 2
    0 <= starti <= endi <= 10^4

    */
    internal class _0056_MergeIntervals
    {

        public int[][] Merge(int[][] intervals)
        {
            var sortedInterval = intervals.Clone() as int[][];
            Array.Sort(sortedInterval, (a, b) => a[0] - b[0]);

            var mergedInterval = new List<int[]>();
            var lastInterval = sortedInterval[0];
            mergedInterval.Add(lastInterval);

            for (var i = 1; i < sortedInterval.Length; i++)
            {
                var current = sortedInterval[i];
                var lastIntervalEnd = lastInterval[1];
                var nextIntervalEnd = current[1];
                var nextIntervalStart = current[0];

                if (lastIntervalEnd >= nextIntervalStart)
                    lastInterval[1] = Math.Max(nextIntervalEnd, lastIntervalEnd);
                else
                {
                    lastInterval = current;
                    mergedInterval.Add(lastInterval);
                    //lastInterval = current;
                }
            }

            return mergedInterval.ToArray();
        }
    }
}
