using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
     
    Given two strings s and t, return true if t is an anagram of s, and false otherwise.

    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

    Input: s = "anagram", t = "nagaram"
    Output: true

    Input: s = "rat", t = "car"
    Output: false

    */
    internal class _0242_ValidAnagram
    {
        /*
            string s = "anagram";
            string t = "nagaram";

            string s = "rat";
            string t = "car";
        */

        //public bool IsAnagram(string s, string t)
        //{
        //    var sOrdered = new string(s.ToCharArray().Order().ToArray());
        //    var tOrdered = new string(t.ToCharArray().Order().ToArray());

        //    return String.Equals(sOrdered, tOrdered, StringComparison.OrdinalIgnoreCase);
        //}

        public bool IsAnagram(string s, string t)
        {
            s = String.Concat(s.OrderBy(c => c));
            t = String.Concat(t.OrderBy(c => c));
            return String.Equals(s, t, StringComparison.OrdinalIgnoreCase);
        }
    }
}
