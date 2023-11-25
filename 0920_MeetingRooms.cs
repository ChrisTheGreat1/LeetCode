using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), 
    determine if a person could attend all meetings.


    Input: intervals = [(0,30),(5,10),(15,20)]
    Output: false
    Explanation: 
    (0,30), (5,10) and (0,30),(15,20) will conflict


    Input: intervals = [(5,8),(9,15)]
    Output: true
    Explanation: 
    Two times will not conflict 

    */
    internal class _0920_MeetingRooms
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0] < b[0] ? -1 : 1);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < intervals[i - 1][1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
