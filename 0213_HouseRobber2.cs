﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
 
    You are a professional robber planning to rob houses along a street. 
    Each house has a certain amount of money stashed. 
    All houses at this place are arranged in a circle. 
    That means the first house is the neighbor of the last one. 
    Meanwhile, adjacent houses have a security system connected, and it will automatically 
    contact the police if two adjacent houses were broken into on the same night.

    Given an integer array nums representing the amount of money of each house, 
    return the maximum amount of money you can rob tonight without alerting the police.


    Input: nums = [2,3,2]
    Output: 3
    Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2), because they are adjacent houses.


    Input: nums = [1,2,3,1]
    Output: 4
    Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
    Total amount you can rob = 1 + 3 = 4.


    Input: nums = [1,2,3]
    Output: 3
 

    Constraints:

    1 <= nums.length <= 100
    0 <= nums[i] <= 1000

    */
    internal class _0213_HouseRobber2
    {
        /*
        
        Since House[0] and House[n] are adjacent, they cannot be robbed together. 
        Therefore, the problem becomes to rob either House[0]-House[n-1] or House[1]-House[n], 
        depending on which choice offers more money. Now the problem has degenerated to the House Robber

        */

        public int Rob(int[] nums)
        {
            return Math.Max(nums[0], 
                Math.Max(
                getMaxRobAmount(nums, 0, nums.Length - 1),
                getMaxRobAmount(nums, 1, nums.Length)
                )
            );
        }

        public int getMaxRobAmount(int[] nums, int start, int end)
        {
            int rob1 = 0, rob2 = 0;

            for (int i = start; i < end; i++)
            {
                int temp = Math.Max(nums[i] + rob1, rob2);
                rob1 = rob2;
                rob2 = temp;
            }

            return rob2;
        }
    }
}
