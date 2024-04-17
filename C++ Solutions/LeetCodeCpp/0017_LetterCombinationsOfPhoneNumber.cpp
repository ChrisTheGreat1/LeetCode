/*

Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

Input: digits = ""
Output: []

Input: digits = "2"
Output: ["a","b","c"]

Constraints:

0 <= digits.length <= 4
digits[i] is a digit in the range ['2', '9'].

2 - abc
3 - def
4 - ghi
5 - jkl
6 - mno
7 - pqrs
8 - tuv
9 - wxyz

*/

#include <iostream>
#include <vector>
#include <algorithm>
#include <stack>
#include <string>
#include <unordered_set>
#include <unordered_map>

using namespace std;

class Solution {
public:
    vector<string> letterCombinations(string digits) {
        if (digits.empty()) {
            return {};
        }

        unordered_map<char, string> m = {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };
        string curr = "";
        vector<string> result;

        dfs(digits, 0, m, curr, result);
        return result;
    }
private:
    void dfs(string digits, int index, unordered_map<char, string>& m, string& curr, vector<string>& result) {
        if (index == digits.size()) {
            result.push_back(curr);
            return;
        }
        string str = m[digits[index]];
        for (int i = 0; i < str.size(); i++) {
            curr.push_back(str[i]);
            dfs(digits, index + 1, m, curr, result);
            curr.pop_back();
        }
    }
};