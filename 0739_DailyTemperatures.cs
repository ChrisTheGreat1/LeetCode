using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. If there is no future day for which this is possible, keep answer[i] == 0 instead.

    Input: temperatures = [73,74,75,71,69,72,76,73]
    Output: [1,1,4,2,1,1,0,0]

    Input: temperatures = [30,40,50,60]
    Output: [1,1,1,0]

    Input: temperatures = [30,60,90]
    Output: [1,1,0]
 
    Constraints:

    1 <= temperatures.length <= 10^5
    30 <= temperatures[i] <= 100

    */
    internal class _0739_DailyTemperatures
    {
        //var temperatures = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
        //var temperatures = new int[] { 30, 40, 50, 60 };
        //var temperatures = new int[] { 30, 60, 90 };

        /*
        public int[] DailyTemperatures(int[] temperatures)
        {
            var result = new int[temperatures.Length];

            for(int i = 0; i < temperatures.Length - 1; i++)
            {
                var current = temperatures[i];

                for(int j = i + 1; j < temperatures.Length; j++)
                {
                    if (temperatures[j] > current)
                    {
                        result[i] = j - i;
                        break;
                    }
                }
            }

            return result;
        }
        */

        // Note: conceptually it makes more sense to start at the end of the array and work backwards
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] res = new int[temperatures.Length];

            Stack<int> tempIndex = new Stack<int>();

            tempIndex.Push(0);

            for (int i = 1; i < temperatures.Length; i++)
            {
                while (tempIndex.Count != 0)
                {
                    if (temperatures[tempIndex.Peek()] < temperatures[i])
                    {
                        res[tempIndex.Peek()] = i - tempIndex.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
                tempIndex.Push(i);
            }

            return res;
        }
    }
}
