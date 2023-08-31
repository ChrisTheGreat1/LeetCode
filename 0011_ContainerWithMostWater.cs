using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

    You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the
    ith line are (i, 0) and (i, height[i]).

    Find two lines that together with the x-axis form a container, such that the container contains the most water.

    Return the maximum amount of water a container can store.

    Notice that you may not slant the container.

    */

    // int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
    // int[] height = new int[] { 1, 1 };

    internal class _0011_ContainerWithMostWater
    {
        // O(n) solution:
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                int area = Math.Min(height[left], height[right]) * (right - left);
                maxArea = Math.Max(maxArea, area);

                if (height[left] <= height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }

        // O(n^2) solution:
        /*
        public int MaxArea(int[] height)
        {
            int maxArea = 0;

            for(int i = 0; i < height.Length - 1; i++)
            {
                int elem1Height = height[i];

                for(int j = i+1; j < height.Length; j++)
                {
                    int elem2Height = height[j];

                    int area = Math.Min(elem1Height, elem2Height)*(j-i);

                    if(area > maxArea) maxArea = area;
                }
            }

            return maxArea;
        }
        */
    }
}