﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    You are given an integer array cost where cost[i] is the cost of ith step on a staircase. 
    Once you pay the cost, you can either climb one or two steps.

    You can either start from the step with index 0, or the step with index 1.

    Return the minimum cost to reach the top of the floor.


    Input: cost = [10,15,20]
    Output: 15
    Explanation: You will start at index 1.
    - Pay 15 and climb two steps to reach the top.
    The total cost is 15.


    Input: cost = [1,100,1,1,1,100,1,1,100,1]
    Output: 6
    Explanation: You will start at index 0.
    - Pay 1 and climb two steps to reach index 2.
    - Pay 1 and climb two steps to reach index 4.
    - Pay 1 and climb two steps to reach index 6.
    - Pay 1 and climb one step to reach index 7.
    - Pay 1 and climb two steps to reach index 9.
    - Pay 1 and climb one step to reach the top.
    The total cost is 6.
 

    Constraints:

    2 <= cost.length <= 1000
    0 <= cost[i] <= 999

    */

    // var cost = new int[] { 10, 15, 20 };
    // var cost = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };

    internal class _0746_MinCostClimbingStairs
    {
        // Min cost to reach cost.Length

        public int MinCostClimbingStairs(int[] cost)
        {
            // return topDown(cost);
            return bottomUp(cost);
        }

        private int topDown(int[] cost)
        {
            var l = cost.Length;

            for (var i = 2; i < l; i++)
            {
                cost[i] += Math.Min(cost[i - 1], cost[i - 2]);
            }

            return Math.Min(cost[l - 1], cost[l - 2]);
        }

        private int bottomUp(int[] cost)
        {
            for (var i = cost.Length - 3; i >= 0; i--)
            {
                cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
            }

            return Math.Min(cost[0], cost[1]);
        }

        /*
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 2)
            {
                return Math.Min(cost[0], cost[1]);
            }

            var newCostArray = new int[cost.Length + 1];
            Array.Copy(cost, newCostArray, cost.Length);
            newCostArray[cost.Length] = 0;
            int counter = 0;

            // Determine starting stair.
            if (newCostArray[1] + newCostArray[3] <= newCostArray[0] + newCostArray[2])
            {
                counter = 1;
            }

            int lowestCost = newCostArray[counter];

            while (counter < newCostArray.Length - 3)
            {
                if (lowestCost + newCostArray[counter + 2] <= lowestCost + newCostArray[counter + 1])
                {
                    lowestCost += newCostArray[counter + 2];
                    counter += 2;
                }
                else
                {
                    lowestCost += newCostArray[counter + 1];
                    counter += 1;
                }
            }

            return lowestCost;
        }
        */
    }
}
