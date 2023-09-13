using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _0875_KokoEatingBananas
    {
        /*
         

        Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.

        Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.

        Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.

        Return the minimum integer k such that she can eat all the bananas within h hours.


        Input: piles = [3,6,7,11], h = 8
        Output: 4

        Input: piles = [30,11,23,4,20], h = 5
        Output: 30

        Input: piles = [30,11,23,4,20], h = 6
        Output: 23

        Constraints:

        1 <= piles.length <= 10^4
        piles.length <= h <= 10^9
        1 <= piles[i] <= 10^9

        */

        private bool IsEnough(int[] piles, int k, int h)
        {
            int hours = 0;

            foreach (var pile in piles)
            {
                hours += (pile + k - 1) / k;
            }

            return hours <= h;
        }

        public int MinEatingSpeed(int[] piles, int h)
        {
            int l = 1;
            int r = piles.Max();

            while (l < r)
            {
                int m = l + (r - l) / 2;

                if (IsEnough(piles, m, h))
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            return l;
        }
    }
}
