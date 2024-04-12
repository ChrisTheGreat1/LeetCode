/*

Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]

Input: nums = [1], k = 1
Output: [1]


Constraints:

1 <= nums.length <= 10^5
-10^4 <= nums[i] <= 10^4
k is in the range [1, the number of unique elements in the array].
It is guaranteed that the answer is unique.

*/

#include <vector>
#include <unordered_map>

using namespace std;

class _0347_TopKFrequentElements {
public:
    std::vector<int> topKFrequent(std::vector<int>& nums, int k) 
    {
        int n = nums.size();

        unordered_map<int, int> mp;

        // Step 1: Iterate through the vector to populate the `mp` dictionary.
        for (int i = 0; i < n; i++) {
            mp[nums[i]]++;
        }

        vector<vector<int>> containers(n + 1);

        // Step 2: Iterate through the `mp` dictionary and distribute elements into the corresponding buckets based on their frequency.
        for (auto it = mp.begin(); it != mp.end(); it++) {
            containers[it->second].push_back(it->first);
        }

        vector<int> ans;

        // Step 3: Iterate through the buckets from right to left (highest to lowest frequency) and append elements to the answer list until the desired k elements are collected.
        for (int i = n; i >= 0; i--) {
            if (ans.size() >= k) {
                break;
            }
            if (!containers[i].empty()) {
                ans.insert(ans.end(), containers[i].begin(), containers[i].end());
            }
        }

        return ans;
    }
};