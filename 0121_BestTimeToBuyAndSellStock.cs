using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{

    /*

     You are given an array prices where prices[i] is the price of a given stock on the ith day.

    You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

    Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

    Example 1:
    Input: prices = [7,1,5,3,6,4]
    Output: 5
    Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
   
    Example 2:
    Input: prices = [7,6,4,3,1]
    Output: 0
    Explanation: In this case, no transactions are done and the max profit = 0.
 
    Constraints:

    1 <= prices.length <= 10^5
    0 <= prices[i] <= 10^4
     
     */

    //var prices = new int[] { 7, 1, 5, 3, 6, 4 };
    //var prices = new int[] { 7, 6, 4, 3, 1 };
    //var prices = new int[] { 2, 1, 4 };

    internal class _0121_BestTimeToBuyAndSellStock
    {
        // Basically a 2 pointer solution
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int minVal = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                int rightVal = prices[i];
                minVal = Math.Min(minVal, rightVal);
                maxProfit = Math.Max(maxProfit, rightVal - minVal);
            }

            return maxProfit;
        }

        /*
        // "Brute force" solution
        public int MaxProfit(int[] prices)
        {
            var maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                var subset = prices.Skip(i+1);

                if (!subset.Any()) break;

                var subsetMin = subset.Max();

                if (subsetMin <= prices[i]) continue;

                var profit = subsetMin - prices[i];

                if (profit > maxProfit)
                {
                    maxProfit = profit;
                }
            }

            return maxProfit;
        }
        */
    }
}
