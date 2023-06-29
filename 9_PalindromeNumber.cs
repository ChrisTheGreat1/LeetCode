using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    // Given an integer x, return true if x is a palindrome, and false otherwise.
    internal class _9_PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            var xString = x.ToString();
            string xStringReversedString = "";
            var xStringReversed = xString.Reverse();

            foreach (var elem in xStringReversed)
            {
                xStringReversedString += elem;
            }

            if (xString.Equals(xStringReversedString)) return true;

            return false;
        }

        /*
         
        // Optimal solution:

        var y = x.ToString().ToCharArray();
        Array.Reverse(y); //Reverses char array.
        return x.ToString() == new string (y);
        //Checks if original string is equal to its reverse.

        */
    }
}
