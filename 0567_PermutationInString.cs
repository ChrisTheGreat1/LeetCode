using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _0567_PermutationInString
    {
        /*
        
        Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.

        In other words, return true if one of s1's permutations is the substring of s2.

        Example 1:
        Input: s1 = "ab", s2 = "eidbaooo"
        Output: true
        Explanation: s2 contains one permutation of s1 ("ba").
        
        Example 2:
        Input: s1 = "ab", s2 = "eidboaoo"
        Output: false

        Constraints:

        1 <= s1.length, s2.length <= 10^4
        s1 and s2 consist of lowercase English letters.

        */

        //var s1 = "ab";
        //var s2 = "eidbaooo";

        //var s1 = "ab";
        //var s2 = "eidboaoo";

        public bool CheckInclusion(string s1, string s2)
        {
            {
                if (s1.Length > s2.Length) return false;

                var s1Count = Enumerable.Repeat(0, 26).ToArray(); // Create arrays of 26 0's
                var s2Count = Enumerable.Repeat(0, 26).ToArray();

                // Instead of calculating each permutation then brute forcing, you can just create a hashmap
                // of the string that you are checking permutations of, then tally the counts of each present character
                for (var i = 0; i < s1.Length; i++)
                {
                    s1Count[s1[i] - 'a']++;
                    s2Count[s2[i] - 'a']++;
                }

                // Now perform a sliding window then iterate through each hashmap calculation.
                // If there is ever a completely equal hashmap comparison, then a true condition has been found

                var matches = 0;
                for (var i = 0; i < 26; i++)
                {
                    if (s1Count[i] == s2Count[i]) matches++;
                }

                var left = 0;
                for (var right = s1.Length; right < s2.Length; right++)
                {
                    if (matches == 26) return true;

                    var index = s2[right] - 'a';
                    s2Count[index]++;
                    if (s1Count[index] == s2Count[index])
                    {
                        matches++;
                    }
                    else if (s1Count[index] + 1 == s2Count[index])
                    {
                        matches--;
                    }

                    index = s2[left] - 'a';
                    s2Count[index]--;
                    if (s1Count[index] == s2Count[index])
                    {
                        matches++;
                    }
                    else if (s1Count[index] - 1 == s2Count[index])
                    {
                        matches--;
                    }

                    left++;
                }

                return matches == 26;
            }
        }

    }
}
