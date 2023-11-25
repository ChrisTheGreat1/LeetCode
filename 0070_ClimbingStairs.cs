using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    You are climbing a staircase. It takes n steps to reach the top.

    Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

    Input: n = 2
    Output: 2
    Explanation: There are two ways to climb to the top.
    1. 1 step + 1 step
    2. 2 steps


    Input: n = 3
    Output: 3
    Explanation: There are three ways to climb to the top.
    1. 1 step + 1 step + 1 step
    2. 1 step + 2 steps
    3. 2 steps + 1 step
 

    Constraints:

    1 <= n <= 45

    */

    internal class _0070_ClimbingStairs
    {
        // Solution is related to fibonacci sequence so use dynamic programming. (reuse old result sets)

        public int ClimbStairs(int n)
        {
            int n2 = 1;
            int n1 = 1;

            for (int i = 0; i < n - 1; i++)
            {
                int temp = n2;
                n2 = n2 + n1;
                n1 = temp;
            }

            return n2;

            /*

            // Time limit exceeds since you are calculating ClimbStairs(3) twice for example.

            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            return ClimbStairs(n - 1) + ClimbStairs(n - 2);

            */
        }
    }
}
