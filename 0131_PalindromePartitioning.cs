using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _0131_PalindromePartitioning
    {
        /*
        
        Given a string s, partition s such that every substring of the partition is a 
        palindrome. Return all possible palindrome partitioning of s.

        Input: s = "aab"
        Output: [["a","a","b"],["aa","b"]]

        Input: s = "a"
        Output: [["a"]]
 
        Constraints:

        1 <= s.length <= 16
        s contains only lowercase English letters.

        */
        public IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            var stack = new List<string>();

            dfs(0);

            return result;

            void dfs(int i)
            {
                if (i >= s.Length)
                {
                    result.Add(stack.ToList());
                    return;
                }

                for (var j = i; j < s.Length; j++)
                {
                    if (IsPalindrome(s, i, j))
                    {
                        stack.Add(s.Substring(i, j - i + 1));
                        dfs(j + 1);
                        stack.RemoveAt(stack.Count - 1);
                    }
                }
            }
        }

        public bool IsPalindrome(string s, int l, int r)
        {
            while (l < r)
            {
                if (s[l] != s[r])
                    return false;
                l++;
                r--;
            }

            return true;
        }
    }
}
