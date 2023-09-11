using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, 
    return the area of the largest rectangle in the histogram.

    Input: heights = [2,1,5,6,2,3]
    Output: 10
    Explanation: The above is a histogram where width of each bar is 1.
    The largest rectangle is shown in the red area, which has an area = 10 units.

    Input: heights = [2,4]
    Output: 4

    Constraints:
    1 <= heights.length <= 10^5
    0 <= heights[i] <= 10^4

    */
    internal class _0084_LargestRectangleInHistogram
    {
        public int getMaxArea(int[] hist, int n)
        {
            // Create an empty stack. The stack
            // holds indexes of hist[] array
            // The bars stored in stack are always
            // in increasing order of their heights.
            Stack<int> s = new Stack<int>();

            int max_area = 0; // Initialize max area
            int tp; // To store top of stack
            int area_with_top; // To store area with top
                               // bar as the smallest bar

            // Run through all bars of
            // given histogram
            int i = 0;
            while (i < n)
            {
                // If this bar is higher than the
                // bar on top stack, push it to stack
                if (s.Count == 0 || hist[s.Peek()] <= hist[i])
                {
                    s.Push(i++);
                }

                // If this bar is lower than top of stack,
                // then calculate area of rectangle with
                // stack top as the smallest (or minimum
                // height) bar. 'i' is 'right index' for
                // the top and element before top in stack
                // is 'left index'
                else
                {
                    tp = s.Peek(); // store the top index
                    s.Pop(); // pop the top

                    // Calculate the area with hist[tp]
                    // stack as smallest bar
                    area_with_top
                        = hist[tp]
                          * (s.Count == 0 ? i
                                          : i - s.Peek() - 1);

                    // update max area, if needed
                    if (max_area < area_with_top)
                    {
                        max_area = area_with_top;
                    }
                }
            }

            // Now pop the remaining bars from
            // stack and calculate area with every
            // popped bar as the smallest bar
            while (s.Count > 0)
            {
                tp = s.Peek();
                s.Pop();
                area_with_top
                    = hist[tp]
                      * (s.Count == 0 ? i : i - s.Peek() - 1);

                if (max_area < area_with_top)
                {
                    max_area = area_with_top;
                }
            }

            return max_area;
        }
    }
}
