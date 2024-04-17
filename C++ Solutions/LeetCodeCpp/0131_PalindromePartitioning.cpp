/*

Given a string s, partition s such that every substring of the partition is a
palindrome. Return all possible palindrome partitioning of s.

Input: s = "aab"
Output: [["a","a","b"],["aa","b"]]

Input: s = "a"
Output: [["a"]]

Constraints:

1 <= s.length <= 16
s contains only lowercase English letters.

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
    vector<vector<string>> partition(string s) {
        vector<string> curr;
        vector<vector<string>> result;
        dfs(s, 0, curr, result);
        return result;
    }
private:
    void dfs(string s, int start, vector<string>& curr, vector<vector<string>>& result) {
        if (start == s.size()) {
            result.push_back(curr);
            return;
        }
        for (int i = start; i < s.size(); i++) {
            if (isPalindrome(s, start, i)) {
                string str = s.substr(start, i - start + 1);
                curr.push_back(str);
                dfs(s, i + 1, curr, result);
                curr.pop_back();
            }
        }
    }
    bool isPalindrome(string s, int left, int right) {
        while (left < right) {
            if (s[left] != s[right]) {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
};
