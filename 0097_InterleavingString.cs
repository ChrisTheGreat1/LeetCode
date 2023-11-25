﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.

    An interleaving of two strings s and t is a configuration where s and t are divided into n and m 
    substrings respectively, such that:

    s = s1 + s2 + ... + sn
    t = t1 + t2 + ... + tm
    |n - m| <= 1

    The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...
    Note: a + b is the concatenation of strings a and b.

    Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
    Output: true
    Explanation: One way to obtain s3 is:
    Split s1 into s1 = "aa" + "bc" + "c", and s2 into s2 = "dbbc" + "a".
    Interleaving the two splits, we get "aa" + "dbbc" + "bc" + "a" + "c" = "aadbbcbcac".
    Since s3 can be obtained by interleaving s1 and s2, we return true.


    Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
    Output: false
    Explanation: Notice how it is impossible to interleave s2 with any other string to obtain s3.


    Input: s1 = "", s2 = "", s3 = ""
    Output: true
 

    Constraints:

    0 <= s1.length, s2.length <= 100
    0 <= s3.length <= 200
    s1, s2, and s3 consist of lowercase English letters.

    */

    internal class _0097_InterleavingString
    {

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;

            var dp = new bool[s1.Length + 1, s2.Length + 1];
            dp[s1.Length, s2.Length] = true;

            for (var i = s1.Length; i >= 0; i--)
            {
                for (var j = s2.Length; j >= 0; j--)
                {
                    if (i < s1.Length && s1[i] == s3[i + j] && dp[i + 1, j])
                    {
                        dp[i, j] = true;
                    }
                    if (j < s2.Length && s2[j] == s3[i + j] && dp[i, j + 1])
                    {
                        dp[i, j] = true;
                    }
                }

            }

            return dp[0, 0];
        }
    }
}
