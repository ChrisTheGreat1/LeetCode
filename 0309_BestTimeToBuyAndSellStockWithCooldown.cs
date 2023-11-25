using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    You are given an array prices where prices[i] is the price of a given stock on the ith day.

    Find the maximum profit you can achieve. You may complete as many transactions as you like 
    (i.e., buy one and sell one share of the stock multiple times) with the following restrictions:

    After you sell your stock, you cannot buy stock on the next day (i.e., cooldown one day).
    Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).

 

    Input: prices = [1,2,3,0,2]
    Output: 3
    Explanation: transactions = [buy, sell, cooldown, buy, sell]


    Input: prices = [1]
    Output: 0
 

    Constraints:

    1 <= prices.length <= 5000
    0 <= prices[i] <= 1000

    */

    internal class _0309_BestTimeToBuyAndSellStockWithCooldown
    {
        // Visualize problem as a decision tree where you can either buy/sell or cooldown. You want to return the ending node
        // that has the maximum value

        // var prices = new int[] { 1, 2, 3, 0, 2 };

        /*
        

        Approach:
        We create two arrays, sell and buy, to store the maximum profit we can achieve at each day 
        by selling or buying the stock. sell[i] represents the maximum profit we can achieve on the 
        ith day by selling the stock and buy[i] represents the maximum profit we can achieve on the ith day by buying the stock.

        We initialize sell[0] and buy[0] as follows:

        sell[0] = 0
        buy[0] = -prices[0]

        For each day i, we calculate sell[i] and buy[i] as follows:

        sell[i] = max(sell[i-1], buy[i-1] + prices[i])
        buy[i] = max(buy[i-1], sell[i-2] - prices[i])

        The first equation represents the maximum profit we can achieve on the ith day by either 
        selling the stock that we bought on the previous day or 
        selling the stock that we bought before the previous day and taking the cooldown into account.

        The second equation represents the maximum profit we can achieve on the ith day by either buying the stock or not doing anything.

        Finally, the maximum profit we can achieve is the value in sell[n-1], where n is the number of days.

        Complexity
        Time complexity:
        The complexity of this solution is O(n), where n is the number of days. 
        We only need to traverse the prices array once to calculate the maximum profit, so the time complexity is linear.

        Space complexity:
        The space complexity is also O(n), as we use two arrays of size n to store the maximum profit at each day.

        */

        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;

            if (n == 0 || n == 1)
            {
                return 0;
            }

            int[] sell = new int[n];
            int[] buy = new int[n];

            buy[0] = -prices[0];
            sell[0] = 0;

            for (int i = 1; i < n; i++)
            {
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);

                if (i == 1)
                {
                    buy[i] = Math.Max(buy[i - 1], -prices[i]);
                }
                else
                {
                    buy[i] = Math.Max(buy[i - 1], sell[i - 2] - prices[i]);
                }
            }

            return sell[n - 1];
        }



        /*
        public int MaxProfit(int[] prices)
        {
            int sold = 0, rest = 0, hold = Int32.MinValue;

            for (int i = 0; i < prices.Length; i++)
            {
                int prevSold = sold;
                sold = hold + prices[i];
                hold = Math.Max(hold, rest - prices[i]);
                rest = Math.Max(rest, prevSold);
            }

            return Math.Max(sold, rest);
        }
        */
    }
}
