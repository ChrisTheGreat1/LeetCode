using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    // Given two integers a and b, return the sum of the two integers without using the operators + and -.
    internal class _0371_SumOfTwoIntegers
    {
        public int GetSum(int a, int b)
        {
            // The loop continues until there is no carry left.
            while (b != 0)
            {
                // The carry is the common set bits of a and b. (AND operation)
                var carry = a & b;

                // Sum of bits of a and b where at least one of the bits is not set. (XOR operation)
                a = a ^ b;

                // Carry is shifted by one so that adding it to a gives the required sum. (BIT SHIFT LEFT)
                b = carry << 1;
            }

            // Return the sum.
            return a;
        }
    }
}
