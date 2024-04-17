/*

Given a collection of candidate numbers (candidates) and a target number (target),
find all unique combinations in candidates where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.

Note: The solution set must not contain duplicate combinations.

Input: candidates = [10,1,2,7,6,1,5], target = 8
Output:
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]


Input: candidates = [2,5,2,1,2], target = 5
Output:
[
[1,2,2],
[5]
]


Constraints:

1 <= candidates.length <= 100
1 <= candidates[i] <= 50
1 <= target <= 30

*/

#include <iostream>
#include <vector>
#include <algorithm>
#include <stack>
#include <string>
#include <unordered_set>

using namespace std;

class Solution {
public:
    vector<vector<int>> combinationSum2(vector<int>& candidates, int target) {
        sort(candidates.begin(), candidates.end());

        vector<int> curr;
        vector<vector<int>> result;

        dfs(candidates, target, 0, 0, curr, result);
        return result;
    }
private:
    void dfs(vector<int>& candidates, int target, int sum, int start, vector<int>& curr, vector<vector<int>>& result) {
        if (sum > target) {
            return;
        }
        if (sum == target) {
            result.push_back(curr);
            return;
        }
        for (int i = start; i < candidates.size(); i++) {
            if (i > start && candidates[i] == candidates[i - 1]) {
                continue;
            }
            curr.push_back(candidates[i]);
            dfs(candidates, target, sum + candidates[i], i + 1, curr, result);
            curr.pop_back();
        }
    }
};