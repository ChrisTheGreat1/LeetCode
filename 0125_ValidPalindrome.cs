using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
     
    A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

    Given a string s, return true if it is a palindrome, or false otherwise.

    Input: s = "A man, a plan, a canal: Panama"
    Output: true
    Explanation: "amanaplanacanalpanama" is a palindrome.

    Input: s = "race a car"
    Output: false
    Explanation: "raceacar" is not a palindrome.

    Input: s = " "
    Output: true
    Explanation: s is an empty string "" after removing non-alphanumeric characters.
    Since an empty string reads the same forward and backward, it is a palindrome.
 
    Constraints:

    1 <= s.length <= 2 * 10^5
    s consists only of printable ASCII characters.

    */
    internal class _0125_ValidPalindrome
    {
        //var s = "A man, a plan, a canal: Panama";
        //var s = "race a car";
        //var s = " ";

        public bool IsPalindrome(string s)
        {
            var scrubbedString = Regex.Replace(s.ToLower(), "[^a-z0-9]", "");

            if (scrubbedString.Length == 0) return true;

            return scrubbedString == new string(scrubbedString.Reverse().ToArray());
        }

        /*
        // If Regex not available:
        public bool IsPalindrome(string s)
        {
            var clean = s.ToLower().Where(x => char.IsLetterOrDigit(x));
            return clean.Reverse().SequenceEqual(clean);
        }
        */

        /*
        // Two-pointer method:
        public bool IsPalindrome(string s)
        {

            if (s.Length == 1 && char.IsLetterOrDigit(s[0]))
                return true;

            char[] lowerChars = s.ToLower().ToCharArray();
            StringBuilder palinString = new StringBuilder();

            foreach (char element in lowerChars)
            {
                if (char.IsLetterOrDigit(element))
                {
                    palinString.Append(element);
                }
            }
            int rightPointer = palinString.Length - 1;
            int leftPointer = 0;

            while (rightPointer - leftPointer > 0)
            {
                if (palinString[rightPointer] != palinString[leftPointer])
                    return false;
                rightPointer -= 1;
                leftPointer += 1;
            }
            return true;
        }
        */
    }
}
