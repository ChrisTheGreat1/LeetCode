using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

    Input: x = 2.00000, n = 10
    Output: 1024.00000


    Input: x = 2.10000, n = 3
    Output: 9.26100


    Input: x = 2.00000, n = -2
    Output: 0.25000
    Explanation: 2-2 = 1/22 = 1/4 = 0.25

    */
    internal class _0050_Pow_x_n
    {
        public double MyPow(double x, long n)
        {
            var result = helper(x, Math.Abs(n));
            return n > 0 ? result : 1 / result;
        }

        private double helper(double x, long n)
        {
            if (x == 0) return 0;
            if (n == 0) return 1;

            var result = helper(x, n / 2);
            result = result * result;
            return n % 2 == 1 ? x * result : result;
        }
    }
}
