using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    A message containing letters from A-Z can be encoded into numbers using the following mapping:

    'A' -> "1"
    'B' -> "2"
    ...
    'Z' -> "26"
    To decode an encoded message, all the digits must be grouped then mapped back into letters 
    using the reverse of the mapping above (there may be multiple ways). For example, "11106" can be mapped into:

    "AAJF" with the grouping (1 1 10 6)
    "KJF" with the grouping (11 10 6)
    Note that the grouping (1 11 06) is invalid because "06" cannot be mapped into 'F' since "6" is different from "06".

    Given a string s containing only digits, return the number of ways to decode it.

    The test cases are generated so that the answer fits in a 32-bit integer.


    Input: s = "12"
    Output: 2
    Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).


    Input: s = "226"
    Output: 3
    Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).


    Input: s = "06"
    Output: 0
    Explanation: "06" cannot be mapped to "F" because of the leading zero ("6" is different from "06").
 

    Constraints:

    1 <= s.length <= 100
    s contains only digits and may contain leading zero(s).

    */

    internal class _0091_DecodeWays
    {
        // Treat problem like a decision tree. Iterate through each string index and perform decision on whether you will
        // take just the next single character string or the next 2-character string.
        // Then you just have to account for the edge cases of looking for strings "10", "20", as well as if the
        // 2-character string is less than 27

        /*

        We can look at this using a Bottom-Up Dynamic Programming (DP) approach.
        We'll be iterating character by character over the input string in reverse, 
        keeping track of how many different ways we can decode the string so far in an array called dp.
        When doing this, there are a couple of cases that we need to consider:

        Number at index is equal to 0
        - Since 0 isn't a valid number to start with, we set dp[i] = 0 if s[i] == 0.
        - If this isn't the case, then we know the number at s[i] is valid, and we set dp[i] = dp[i+1].

        Check whether we can create a valid 2 digit number
        - Since the range of valid numbers to decode is 1-26 we need to check whether our current number 
        can be combined into a valid 2 digit number.
        - Our two sets of valid 2 digit numbers are 10-19 and 20-26 and we can check this by looking at 
        whether s[i] == 1, or whether s[i] == 2 && 0 <= s[i+1] <= 6
        - If we have a valid two digit number, then we can add dp[i+1] to dp[i]

        These cases, especially the second, may not seem completely intuitive at first, but the explanation below should clear up any confusion.

        Explanation
        The first case is the simpler of the two, but may not make sense initally. 
        We can think of this case as being If there is a valid number, then we 
        maintain the previous number of different ways to decode the string.

        The second case is where it gets more complicated. We can think of this case 
        as being If we can form a valid 2 digit number, then the number ways to decode 
        the string will increase by the number of ways to decode the substring that 
        begins after the second digit of our 2 digit number. To give an example:

        string s = "12235"
        i = 4, dp = {0, 0, 0, 0, 0, 1}
        Current permutations: []
        5 is valid, so set dp[4] = dp[5]
        No 2 digit number can be made
        Current permutations: [5]

        i = 3, dp = {0, 0, 0, 0, 1, 1}
        Current permutations: [5]
        5 is valid, so set dp[3] = dp[4]
        A 2 digit number can be made but it isn't valid
        Current permutations: [35]

        i = 2, dp = {0, 0, 0, 1, 1, 1}
        Current permutations: [35]
        2 is valid, so set dp[2] = dp[3]
        A 2 digit number can be made, and it is valid, so increase dp[2] by dp[4]
        Current permutations: [235, [23]5]

        i = 1, dp = {0, 0, 2, 1, 1, 1}
        Current permutations: [235, [23]5]
        2 is valid, so set dp[1] = dp[2]
        A 2 digit number can be made, and it is valid, so increase dp[1] by dp[3]
        Current permutations: [2235, 2[23]5, [22]35]

        i = 0, dp = {0, 3, 2, 1, 1, 1}
        Current permutations: [2235, 2[23]5, [22]35]
        1 is valid, so set dp[0] = dp[1]
        A 2 digit number can be made, and it is valid, so increase dp[0] by dp[2]
        Current permutations: [12235, 12[23]5, 1[22]35, [12]235, [12][23]5]

        Final dp = {5, 3, 2, 1, 1, 1}
        Result = 5
        We can see in the above that by adding a valid number, e.g. 1, on it's own, 
        we maintain the number of permutations we had before (dp[i+1]), but by using 
        a valid two digit number, e.g. 12, we also add all the ways that the remaining substring, e.g. [235] can be made (dp[i+2]).

                */

        //var s = "226";

        public int NumDecodings(string s)
        {
            List<int> dp = Enumerable.Repeat(1, s.Length + 1).ToList();

            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '0')
                    dp[i] = 0;
                else
                    dp[i] = dp[i + 1];

                if (i + 1 < s.Length && (
                    s[i] == '1' ||
                    (s[i] == '2' && "0123456".Contains(s[i + 1]))
                ))
                    dp[i] += dp[i + 2];
            }

            return dp[0];
        }
    }
}
