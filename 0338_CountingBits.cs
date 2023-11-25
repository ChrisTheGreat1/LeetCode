using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), 
    ans[i] is the number of 1's in the binary representation of i.

    Input: n = 2
    Output: [0,1,1]
    Explanation:
    0 --> 0
    1 --> 1
    2 --> 10


    Input: n = 5
    Output: [0,1,1,2,1,2]
    Explanation:
    0 --> 0
    1 --> 1
    2 --> 10
    3 --> 11
    4 --> 100
    5 --> 101
 

    Constraints:

    0 <= n <= 10^5

    */
    internal class _0338_CountingBits
    {
        public int[] CountBits(int n)
        {
            var hammingWeights = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                var binary = Convert.ToString(i, 2);
                var hammingWeight = 0;
                for (int j = 0; j < binary.Length; j++)
                {
                    hammingWeight += binary[j] - '0';
                }

                hammingWeights[i] = hammingWeight;
            }
            return hammingWeights;
        }
    }
}
