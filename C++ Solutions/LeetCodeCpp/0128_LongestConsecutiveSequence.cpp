/*

Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in O(n) time.


Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9

Constraints:

0 <= nums.length <= 10^5
-10^9 <= nums[i] <= 10^9

*/

#include <vector>
#include <unordered_set>

class _0128_LongestConsecutiveSequence {
public:
    int longestConsecutive(std::vector<int>& nums) {

        std::unordered_set<int> s(nums.begin(), nums.end());

        int longest = 0;

        for (auto& n : s) {

            // if this is the start of the sequence

            if (!s.count(n - 1)) { // 	returns the number of elements matching specific key (ie. if s does not contain integer value 'n - 1', then start counting the run)

                int length = 1;

                while (s.count(n + length))
                    ++length;

                longest = std::max(longest, length);
            }

        }

        return longest;
    }
};