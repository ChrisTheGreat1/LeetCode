using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

    Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

    Input: n = 3
    Output: ["((()))","(()())","(())()","()(())","()()()"]

    Input: n = 1
    Output: ["()"]

    Constraints:

    1 <= n <= 8

    */

    internal class _0022_GenerateParentheses
    {
        List<string> result = new();

        public IList<string> GenerateParenthesis(int n)
        {
            GenerateAndCheck("", 0, 0, n);
            return result;
        }

        private void GenerateAndCheck(string str, int opened, int closed, int n)
        {
            if (opened == closed && opened == n)
            {
                result.Add(str);
                return;
            }

            if (opened < n)
                GenerateAndCheck(str + "(", opened + 1, closed, n);
            if (closed < opened)
                GenerateAndCheck(str + ")", opened, closed + 1, n);
        }
    }
}