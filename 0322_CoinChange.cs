using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    You are given an integer array coins representing coins of different denominations and an 
    integer amount representing a total amount of money.

    Return the fewest number of coins that you need to make up that amount. If that amount 
    of money cannot be made up by any combination of the coins, return -1.

    You may assume that you have an infinite number of each kind of coin.


    Input: coins = [1,2,5], amount = 11
    Output: 3
    Explanation: 11 = 5 + 5 + 1


    Input: coins = [2], amount = 3
    Output: -1


    Input: coins = [1], amount = 0
    Output: 0
 

    Constraints:

    1 <= coins.length <= 12
    1 <= coins[i] <= 2^31 - 1
    0 <= amount <= 10^4

    */
    internal class _0322_CoinChange
    {
        //var coins = new int[] { 1, 2, 5 };
        //var amount = 11;
        
        // Bottom up solution
        public int CoinChange(int[] coins, int amount)
        {
            var dp = Enumerable.Repeat(amount + 1, amount + 1).ToArray();

            dp[0] = 0;

            // This loop basically performs a dynamic programming memoization.
            // Iterate through and calculate the number of coins it takes to equal the value of i, ex. when i = 1 and there is a coin of value 1, then populate dp[1] as value 1.
            // Finally, once you've iterated to where i = amount, the value of dp[amount] is the min number of coins

            for (var i = 1; i <= amount; i++)
            {
                foreach (var coinValue in coins)
                {
                    if (i - coinValue >= 0)
                    {
                        dp[i] = Math.Min(dp[i], 1 + dp[i - coinValue]); // Use 1 + dp[i - coinValue] so if you find a single coin that can total the amount (satisfy "i - coinValue"), dp[i] gets assigned value of 1. Since dp[0] = 0
                    }
                }
            }

            if (dp[amount] == amount + 1)
            {
                return -1;
            }
            else
            {
                return dp[amount];
            }
        }



        // Greedy solution, incorrect. Need to use dynamic programming for min amount
        /*
        public int CoinChange(int[] coins, int amount)
        {
            var coinsSorted = new int[coins.Length];
            Array.Copy(coins, coinsSorted, coins.Length);
            Array.Sort(coinsSorted);
            Array.Reverse(coinsSorted);

            int numOfCoins = 0;
            int count = 0;

            while (count < amount)
            {
                int i = 0;

                while(i < coinsSorted.Length)
                {
                    if (count >= amount) break;

                    if (coinsSorted[i] < amount && 
                       (coinsSorted[i] + count <= amount))
                    {
                        count += coinsSorted[i];
                        numOfCoins++;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            if(count <= 0)
            {
                return -1;
            }
            else
            {
                return numOfCoins;
            }
        }
        */
    }
}
