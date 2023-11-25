using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given two strings text1 and text2, return the length of their longest common subsequence. 
    If there is no common subsequence, return 0.

    A subsequence of a string is a new string generated from the original string with some 
    characters (can be none) deleted without changing the relative order of the remaining characters.

    For example, "ace" is a subsequence of "abcde".
    A common subsequence of two strings is a subsequence that is common to both strings.



    Input: text1 = "abcde", text2 = "ace" 
    Output: 3  
    Explanation: The longest common subsequence is "ace" and its length is 3.


    Input: text1 = "abc", text2 = "abc"
    Output: 3
    Explanation: The longest common subsequence is "abc" and its length is 3.


    Input: text1 = "abc", text2 = "def"
    Output: 0
    Explanation: There is no such common subsequence, so the result is 0.
 

    Constraints:

    1 <= text1.length, text2.length <= 1000
    text1 and text2 consist of only lowercase English characters.

    */
    internal class _1143_LongestCommonSubsequence
    {
        // Visualize a 2d grid where above the top row is the one string, and along the left column is the other string.
        // Then solve it like a 2d DP problem. If there is an overlap between the two string's characters, increment by 1 and move diagonal.
        // Otherwise move either right or down.

        /*

        Create a 2D array of size s1.Length+1 and s2.Length+1.

        Iterate through the 2D array and check if the characters are equal.

        If equal, then add 1 to the previous diagonal value.

        If not equal, then take the max of the previous row and previous column.

        Return the last value of the 2D array.

        Time complexity: O(m*n)
        Space complexity: O(m*n)

        */

        public int LongestCommonSubsequence(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[s1.Length, s2.Length];
        }
    }
}
