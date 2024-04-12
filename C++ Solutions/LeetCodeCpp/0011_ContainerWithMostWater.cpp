/*

You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the
ith line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.

*/

// 2 pointers outside in, greedily iterate pointer w/ lower height

#include <vector>

class _0011_ContainerWithMostWater {
public:
    int maxArea(std::vector<int>& height) {
        int i = 0;
        int j = height.size() - 1;

        int curr = 0;
        int result = 0;

        while (i < j) {
            curr = (j - i) * std::min(height[i], height[j]);
            result = std::max(result, curr);

            if (height[i] <= height[j]) {
                i++;
            }
            else {
                j--;
            }
        }

        return result;
    }
};