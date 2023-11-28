using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given a string s containing only three types of characters: '(', ')' and '*', return true if s is valid.

    The following rules define a valid string:

    Any left parenthesis '(' must have a corresponding right parenthesis ')'.
    Any right parenthesis ')' must have a corresponding left parenthesis '('.
    Left parenthesis '(' must go before the corresponding right parenthesis ')'.
    '*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string "".
 

    Input: s = "()"
    Output: true


    Input: s = "(*)"
    Output: true


    Input: s = "(*))"
    Output: true
 
    Constraints:

    1 <= s.length <= 100
    s[i] is '(', ')' or '*'.

    */

    internal class _0678_ValidParenthesisString
    {
        //T: O(N) , S: O(1)
        public bool CheckValidString(string s)
        {
            var leftMax = 0;
            var leftMin = 0;

            foreach (var ch in s)
            {
                if (ch == '(')
                {
                    leftMin++;
                    leftMax++;
                }
                else if (ch == ')')
                {
                    leftMax--;
                    leftMin--;
                }
                else
                {
                    leftMin--;
                    leftMax++;
                }

                if (leftMax < 0)
                    return false;

                if (leftMin < 0)
                    leftMin = 0;

            }

            return leftMin == 0;
        }
    }
}
