/*

Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.

Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6

Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. 
In this case, 6 units of rain water (blue section) are being trapped.


Input: height = [4,2,0,3,2,5]
Output: 9


Constraints:
n == height.length
1 <= n <= 2 * 10^4
0 <= height[i] <= 10^5

*/

//  2 pointers, outside in, track max left/right
//  For lower max, curr only dependent on that one
//  Compute height of these, iterate lower one

//  Time: O(n)
//  Space : O(1)

#include <vector>

class _0042_TrappingRainWater {
public:
    int trap(std::vector<int>& height) {

        int i = 0;
        int j = height.size() - 1;

        int maxLeft = height[i];
        int maxRight = height[j];

        int result = 0;

        while (i < j) {
            if (maxLeft <= maxRight) {
                i++;
                maxLeft = std::max(maxLeft, height[i]);
                result += maxLeft - height[i];
            }
            else {
                j--;
                maxRight = std::max(maxRight, height[j]);
                result += maxRight - height[j];
            }
        }

        return result;
    }
};