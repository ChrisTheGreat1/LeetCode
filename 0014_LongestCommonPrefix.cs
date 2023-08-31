using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

     Write a function to find the longest common prefix string amongst an array of strings.

    If there is no common prefix, return an empty string "".

    Input: strs = ["flower","flow","flight"]
    Output: "fl"

    Input: strs = ["dog","racecar","car"]
    Output: ""
    Explanation: There is no common prefix among the input strings.

    Constraints:

    1 <= strs.length <= 200
    0 <= strs[i].length <= 200
    strs[i] consists of only lowercase English letters.

    */

    internal class _0014_LongestCommonPrefix
    {
        //var strs = new string[] { "flower", "flow", "flight" };
        //var strs = new string[] { "dog", "racecar", "car" };

        public string LongestCommonPrefix(string[] strs)
        {
            var result = new StringBuilder("");
            var sortedStrs = strs.OrderBy(str => str.Length).ToArray();

            for (int i = 0; i < sortedStrs.First().Length; i++)
            {
                char initial = sortedStrs.First()[i];
                bool sameChar = true;

                for (int j = 1; j < sortedStrs.Length; j++)
                {
                    if (sortedStrs[j][i] != initial)
                    {
                        sameChar = false;
                        break;
                    }
                }

                if (sameChar)
                {
                    result.Append(initial);
                }
                else break;
            }

            return result.ToString();
        }

        /* LINQ solution (slightly faster):

        public string LongestCommonPrefix(string[] ss)
        {
        string shortest = ss.OrderBy(s => s.Length).First();

        for (int i = 0; i < shortest.Length; i++)
        {
            if (ss.Select(s => s[i]).Distinct().Count() > 1) return shortest[..i];
        }

        return shortest;
        }

        */
    }
}