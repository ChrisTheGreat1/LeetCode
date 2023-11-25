using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.)


    Input: intervals = [(0,30),(5,10),(15,20)]
    Output: 2
    Explanation:
    We need two meeting rooms
    room1: (0,30)
    room2: (5,10),(15,20)


    Input: intervals = [(2,7)]
    Output: 1
    Explanation: 
    Only need one meeting room
    */
    internal class _0919_MeetingRooms2
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return 0;

            int result = 0;
            int[] start = new int[intervals.Length];
            int[] end = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i][0];
                end[i] = intervals[i][1];
            }

            Array.Sort(start);
            Array.Sort(end);

            for (int s = 0, e = 0; s < start.Length; s++)
                if (start[s] < end[e])
                    result++;
                else
                    e++;

            return result;
        }
    }
}
