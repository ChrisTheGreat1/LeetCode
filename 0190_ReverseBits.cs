using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Reverse bits of a given 32 bits unsigned integer.

    Input: n = 00000010100101000001111010011100
    Output:    964176192 (00111001011110000010100101000000)
    Explanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596, so return 964176192 which its binary representation is 00111001011110000010100101000000.


    Input: n = 11111111111111111111111111111101
    Output:   3221225471 (10111111111111111111111111111111)
    Explanation: The input binary string 11111111111111111111111111111101 represents the unsigned integer 4294967293, so return 3221225471 which its binary representation is 10111111111111111111111111111111.
 

    Constraints:

    The input must be a binary string of length 32

    */
    internal class _0190_ReverseBits
    {
        public uint reverseBits(uint n)
        {
            // Initialize result to 0. This will hold the reversed bits.
            uint result = 0;

            // Loop over each bit in n.
            for (int i = 0; i < 32; i++)
            {
                // Extract the least significant bit of n.
                uint temp = (n & 1);

                // Shift the bits in result to the left to make room for the new bit, and add the extracted bit.
                result = (result << 1) + temp;

                // Shift the bits in n to the right to process the next bit in the next iteration.
                n >>= 1;
            }

            // Return the result, which is the binary representation of n reversed.
            return result;
        }

    }
}
