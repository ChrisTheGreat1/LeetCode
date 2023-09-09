using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _0042_TrappingRainWater
    {
        /*
        
        Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.

        Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
        Output: 6
        Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.


        Input: height = [4,2,0,3,2,5]
        Output: 9
 

        Constraints:
        n == height.length
        1 <= n <= 2 * 10^4
        0 <= height[i] <= 10^5

        */
        public int Trap(int[] height)
        {
            int n = height.Length;
            if (n <= 2)
                return 0;

            int left = 0, right = n - 1;
            int leftMax = 0, rightMax = 0;
            int trappedWater = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] > leftMax)
                        leftMax = height[left];
                    else
                        trappedWater += leftMax - height[left];
                    left++;
                }
                else
                {
                    if (height[right] > rightMax)
                        rightMax = height[right];
                    else
                        trappedWater += rightMax - height[right];
                    right--;
                }
            }

            return trappedWater;
        }
    }
}
