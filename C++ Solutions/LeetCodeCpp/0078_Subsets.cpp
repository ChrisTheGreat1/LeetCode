/*

Given an integer array nums of unique elements, return all possible
subsets (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.

Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

Input: nums = [0]
Output: [[],[0]]

Constraints:

1 <= nums.length <= 10
-10 <= nums[i] <= 10
All the numbers of nums are unique.

*/

// Total number of subsets is 2^n

#include <iostream>
#include <vector>
#include <stack>
#include <string>
#include <unordered_set>

using namespace std;

class Solution {
public:
    vector<vector<int>> subsets(vector<int>& nums) {
        vector<int> curr;
        vector<vector<int>> result;
        dfs(nums, 0, curr, result);
        return result;
    }
private:
    void dfs(vector<int>& nums, int start, vector<int>& curr, vector<vector<int>>& result) {
        result.push_back(curr);
        for (int i = start; i < nums.size(); i++) {
            curr.push_back(nums[i]);
            dfs(nums, i + 1, curr, result);
            curr.pop_back();
        }
    }
};