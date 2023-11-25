using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given a string s, return the longest palindromic substring in s.

    Input: s = "babad"
    Output: "bab"
    Explanation: "aba" is also a valid answer.


    Input: s = "cbbd"
    Output: "bb"
 

    Constraints:

    1 <= s.length <= 1000
    s consist of only digits and English letters.

    */

    internal class _0005_LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {
            // Check if the input string is empty, return an empty string if so
            if (string.IsNullOrEmpty(s))
                return "";

            // Initialize variables to store the indices of the longest palindrome found
            int[] longestPalindromeIndices = { 0, 0 };

            // Loop through the characters in the input string
            for (int i = 0; i < s.Length; ++i)
            {
                // Find the indices of the longest palindrome centered at character i
                int[] currentIndices = ExpandAroundCenter(s, i, i);

                // Compare the length of the current palindrome with the longest found so far
                if (currentIndices[1] - currentIndices[0] > longestPalindromeIndices[1] - longestPalindromeIndices[0])
                {
                    // Update the longest palindrome indices if the current one is longer
                    longestPalindromeIndices = currentIndices;
                }

                // Check if there is a possibility of an even-length palindrome centered at character i and i+1
                if (i + 1 < s.Length && s[i] == s[i + 1])
                {
                    // Find the indices of the longest even-length palindrome centered at characters i and i+1
                    int[] evenIndices = ExpandAroundCenter(s, i, i + 1);

                    // Compare the length of the even-length palindrome with the longest found so far
                    if (evenIndices[1] - evenIndices[0] > longestPalindromeIndices[1] - longestPalindromeIndices[0])
                    {
                        // Update the longest palindrome indices if the even-length one is longer
                        longestPalindromeIndices = evenIndices;
                    }
                }
            }

            // Extract and return the longest palindrome substring using the indices
            return s.Substring(longestPalindromeIndices[0], longestPalindromeIndices[1] - longestPalindromeIndices[0] + 1);
        }

        // Helper function to find and return the indices of the longest palindrome
        // extended from s[i..j] (inclusive) by expanding around the center
        private int[] ExpandAroundCenter(string s, int i, int j)
        {
            // Expand the palindrome by moving outward from the center while the characters match
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                i--; // Move the left index to the left
                j++; // Move the right index to the right
            }
            // Return the indices of the longest palindrome found
            return new int[] { i + 1, j - 1 };
        }






        /*
        public string LongestPalindrome(string s)
        {
            var l = 0;
            var h = 0;
            var len1 = 0;

            for (var i = 0; i < s.Length; i++)
            {
                len1 = Math.Max(LengthOfPalindrome(s, i, i), LengthOfPalindrome(s, i, i + 1));

                if (len1 > h - l)
                {
                    l = i - (len1 - 1) / 2;
                    h = i + len1 / 2;
                }
            }

            return s.Substring(l, h - l + 1);
        }

        private int LengthOfPalindrome(string s, int L, int H)
        {
            while (L >= 0 && H < s.Length && s[L] == s[H])
            {
                L--;
                H++;
            }
            return H - L - 1;
        }
        */
    }
}
