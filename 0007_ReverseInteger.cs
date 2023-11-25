using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

    Assume the environment does not allow you to store 64-bit integers (signed or unsigned).


    Input: x = 123
    Output: 321


    Input: x = -123
    Output: -321


    Input: x = 120
    Output: 21

    */
    internal class _0007_ReverseInteger
    {
        public int Reverse(int x)
        {
            int rev = 0;

            while (x != 0)
            {
                var digit = x % 10;
                x = x / 10;
                if (rev > Int32.MaxValue / 10 ||
                  // since max value is 2,147,483,647, 
                  // last digit greater than 7 will overflow
                  (rev == Int32.MaxValue / 10 && digit > 7))
                    return 0;

                if (rev < Int32.MinValue / 10 ||
                    // since min value is  -2,147,483,648
                    (rev == Int32.MinValue / 10 && digit < -8))
                    return 0;

                rev = rev * 10 + digit;
            }

            return rev;
        }
    }
}
