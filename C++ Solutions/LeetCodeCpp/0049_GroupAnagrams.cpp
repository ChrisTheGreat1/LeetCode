/*

Given an array of strings strs, group the anagrams together. You can return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Input: strs = ["eat","tea","tan","ate","nat","bat"]
Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Input: strs = [""]
Output: [[""]]

Input: strs = ["a"]
Output: [["a"]]


Constraints:

1 <= strs.length <= 10^4
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.

*/

#include <iostream>
#include <algorithm>
#include <unordered_map>
#include <vector>

using namespace std;

class _0049_GroupAnagrams {
public:
    vector<vector<string>> groupAnagrams(vector<string>& strs) {

        unordered_map<string, vector<string>> mp; // Stores groups of anagrams

        for (auto x : strs) {
            string word = x;
            sort(word.begin(), word.end());
            mp[word].push_back(x); // insert word as the key into the mp unordered map using mp[word], 
                                   // and we push the original word into the vector associated with that key
        }

        // iterate through each key-value pair in the mp map using a range-based for loop. 
        // For each pair, we push the vector of anagrams (x.second) into the ans vector
        vector<vector<string>> ans;
        for (auto x : mp) {
            ans.push_back(x.second);
        }
        return ans;

    }
};