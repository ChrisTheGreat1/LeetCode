using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _0647_PalindromicSubstrings
    {
        /*
        
        Given a string s, return the number of palindromic substrings in it.

        A string is a palindrome when it reads the same backward as forward.

        A substring is a contiguous sequence of characters within the string.


        Input: s = "abc"
        Output: 3
        Explanation: Three palindromic strings: "a", "b", "c".


        Input: s = "aaa"
        Output: 6
        Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
 

        Constraints:

        1 <= s.length <= 1000
        s consists of lowercase English letters.

        */

        // See Leetcode question #5 for detailed explanation of helper methods.

        public int CountSubstrings(string s)
        {
            var count = 0;

            for (var i = 0; i < s.Length; i++)
            {
                count += getPalindromeCount(s, i, i); // Count odd number of substrings
                count += getPalindromeCount(s, i, i + 1); // Count even number of substrings
            }

            return count;
        }

        public int getPalindromeCount(string s, int l, int r)
        {
            var count = 0;

            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                count++;
                l--;
                r++;
            }

            return count;
        }
    }
}
