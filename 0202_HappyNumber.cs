using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Write an algorithm to determine if a number n is happy.

    A happy number is a number defined by the following process:

    Starting with any positive integer, replace the number by the sum of the squares of its digits.
    Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
    Those numbers for which this process ends in 1 are happy.
    Return true if n is a happy number, and false if not.


    Input: n = 19
    Output: true
    Explanation:
    12 + 92 = 82
    82 + 22 = 68
    62 + 82 = 100
    12 + 02 + 02 = 1


    Input: n = 2
    Output: false

    */
    internal class _0202_HappyNumber
    {
        public bool IsHappy(int n)
        {
            var set = new HashSet<int>();

            // Infinite loop will occur if one of the later-calculated numbers resolves down to a number that was seen once before.
            while (!set.Contains(n))
            {
                set.Add(n);
                n = SumOfSquare(n);
                if (n == 1) return true;
            }

            return false;
        }

        int SumOfSquare(int x)
        {
            int sum = 0;

            for (int i = x; i > 0; i /= 10)
            {
                int y = i % 10;
                sum += y * y;
            }

            return sum;
        }
    }
}
