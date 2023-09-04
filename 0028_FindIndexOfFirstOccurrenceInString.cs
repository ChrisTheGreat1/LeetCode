using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

    Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

    Input: haystack = "sadbutsad", needle = "sad"
    Output: 0
    Explanation: "sad" occurs at index 0 and 6.
    The first occurrence is at index 0, so we return 0.

    Input: haystack = "leetcode", needle = "leeto"
    Output: -1
    Explanation: "leeto" did not occur in "leetcode", so we return -1.

    Constraints:

    1 <= haystack.length, needle.length <= 10^4
    haystack and needle consist of only lowercase English characters.

    */

    internal class _0028_FindIndexOfFirstOccurrenceInString
    {
        //string haystack = "sadbutsad";
        //string needle = "sad";

        //string haystack = "leetcode";
        //string needle = "leeto";

        public int StrStr(string haystack, string needle)
        {
            if (haystack.Contains(needle))
            {
                return haystack.IndexOf(needle);
            }

            return -1;
        }
    }
}