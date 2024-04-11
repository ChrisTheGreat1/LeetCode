/*

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]


Constraints:

2 <= nums.length <= 10^4
-10^9 <= nums[i] <= 10^9
-10^9 <= target <= 10^9
Only one valid answer exists.

*/

/*

A more efficient approach is to use a hash table (unordered_map in C++). 
We can iterate through the array once, and for each element, check if the 
target minus the current element exists in the hash table. 

If it does, we have found a valid pair of numbers. If not, we add the current element to the hash table.

1.Create an empty hash table to store elements and their indices.

2.Iterate through the array from left to right.

3.For each element nums[i], calculate the complement by subtracting it from the target: complement = target - nums[i].

4.Check if the complement exists in the hash table. If it does, we have found a solution.

5.If the complement does not exist in the hash table, add the current element nums[i] to the hash table with its index as the value.

6.Repeat steps 3-5 until we find a solution or reach the end of the array.

7. If no solution is found, return an empty array or an appropriate indicator.

This approach has a time complexity of O(n)

*/

#include <iostream>
#include <algorithm>
#include <unordered_map>
#include <vector>

class _0001_TwoSum {
public:
    std::vector<int> twoSum(std::vector<int>& nums, int target) {
        std::unordered_map<int, int> numMap;
        int n = nums.size();

        for (int i = 0; i < n; i++) {
            int complement = target - nums[i];
            if (numMap.count(complement)) {
                return { numMap[complement], i };
            }
            numMap[nums[i]] = i;
        }

        return {}; // No solution found
    }
};