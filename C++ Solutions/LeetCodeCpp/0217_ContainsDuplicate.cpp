/*

Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

Example 1:

Input: nums = [1,2,3,1]
Output: true
Example 2:

Input: nums = [1,2,3,4]
Output: false
Example 3:

Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true


Constraints:

1 <= nums.length <= 105
-109 <= nums[i] <= 109

*/

// std::vector<int> v{ 1,2,3,4 };
// std::vector<int> v{ 1,2,3,1 };

#include <iostream>
#include <vector>
#include <unordered_set>

class _0217_ContainsDuplicate {
public:
    void run() 
    {
        std::cout << "_0217_ContainsDuplicate is running!\n";
    }
    
    bool containsDuplicate(std::vector<int>& nums) 
    {
        std::unordered_set<int> seen;
        for (int num : nums) {
            if (seen.count(num) > 0) // seen.count(num) returns the number of elements matching key "num"
                return true;
            seen.insert(num);
        }
        return false;
    }
};