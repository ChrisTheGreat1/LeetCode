using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

     Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

    '.' Matches any single character.​​​​
    '*' Matches zero or more of the preceding element.
    The matching should cover the entire input string (not partial).

    Solution explanation: the method returns a boolean value indicating whether the regular expression
    pattern p matches the entire input string s. The regular expression pattern is constructed by concatenating
    the start-of-string anchor ^, the pattern p, and the end-of-string anchor $. This ensures that the entire input
    string must match the pattern, rather than just a substring of it. The Regex.IsMatch method is then used to
    determine if there is a match.

    */

    internal class _0010_RegularExpressionMatching
    {
        public bool IsMatch(string s, string p)
        {
            return Regex.IsMatch(s, "^" + p + "$");
        }
    }
}