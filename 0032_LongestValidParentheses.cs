using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

    Given a string containing just the characters '(' and ')', return the length of the longest valid (well-formed) parentheses
    substring

    Input: s = "(()"
    Output: 2
    Explanation: The longest valid parentheses substring is "()".

    Input: s = ")()())"
    Output: 4
    Explanation: The longest valid parentheses substring is "()()".

    Input: s = ""
    Output: 0

    Constraints:

    0 <= s.length <= 3 * 10^4
    s[i] is '(', or ')'.

    */

    internal class _0032_LongestValidParentheses
    {
        public int LongestValidParentheses(string s)
        {
            int longest = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                CheckLength(i, s, longest, 0, 0);
            }

            return longest;
        }

        private void CheckLength(int i, string s, int longest, int numOpen, int numClosed)
        {
            //if (i >= s.Length - 1)
            //{
            //    longest
            //}

            if (s[i] == '(')
            {
                CheckLength(i + 1, s, longest, ++numOpen, numClosed);
            }
            else
            {
                longest++;
                CheckLength(i + 1, s, longest, numOpen, ++numClosed);
            }
        }
    }
}