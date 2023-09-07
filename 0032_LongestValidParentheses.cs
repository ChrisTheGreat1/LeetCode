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
            Stack<int> index = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    index.Push(i);
                }
                else
                {
                    if (index.Any() && s[index.Peek()] == '(')
                    {
                        index.Pop();
                    }
                    else
                    {
                        index.Push(i);
                    }
                }
            }
            if (!index.Any())
            {
                return s.Length;
            }
            int length = s.Length, unwanted = 0;
            int result = 0;
            while (index.Any())
            {
                unwanted = index.Peek();
                index.Pop();
                result = Math.Max(result, length - unwanted - 1);
                length = unwanted;
            }
            result = Math.Max(result, length);
            return result;
        }
    }
}