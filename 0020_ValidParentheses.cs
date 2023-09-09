using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _0020_ValidParentheses
    {
        /*
         
        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

        An input string is valid if:

        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.


        Input: s = "()"
        Output: true

        Input: s = "()[]{}"
        Output: true

        Input: s = "(]"
        Output: false

        Constraints:
        1 <= s.length <= 10^4
        s consists of parentheses only '()[]{}'.

        */


        //var s = "()";
        //var s = "()[]{}";
        //var s = "(]";
        //var s = "(())";

        // Note: this solution allows parentheses within parentheses
        public bool IsValid(string s)
        {
            if (s.Length < 2) return false;

            var stack = new Stack<char>();   

            for(int i  = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stack.Push(s[i]);
                }
                else if (stack.Count == 0)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    var check = stack.Peek();

                    if (s[i] == ')')
                    {
                        if(check == '(') stack.Pop();
                        else stack.Push(s[i]);
                    }
                    else if (s[i] == ']')
                    {
                        if (check == '[') stack.Pop();
                        else stack.Push(s[i]);
                    }
                    else if (s[i] == '}')
                    {
                        if (check == '{') stack.Pop();
                        else stack.Push(s[i]);
                    }
                    else stack.Push(s[i]);
                }
            }

            return stack.Count == 0;
        }
    }
}
