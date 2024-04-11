/*

Given two strings s and t, return true if t is an anagram of s, and false otherwise.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Input: s = "anagram", t = "nagaram"
Output: true

Input: s = "rat", t = "car"
Output: false

*/

//std::string s1{ "anagram" };
//std::string s2{ "nagaram" };

#include <iostream>
#include <algorithm>

class _0242_ValidAnagram {
public:
    bool isAnagram(std::string s, std::string t) {

        // Low memory allocation but slow run time solution:

        std::sort(s.begin(), s.end());
        std::sort(t.begin(), t.end());

        if (s == t)
            return true;

        return false;

        /*
        
        Faster solution with hash table:

        unordered_map<char, int> count;

        // Count the frequency of characters in string s
        for (auto x : s) {
            count[x]++;
        }

        // Decrement the frequency of characters in string t
        for (auto x : t) {
            count[x]--;
        }

        // Check if any character has non-zero frequency
        for (auto x : count) {

            // x.first is the key
            // x.second is the value

            if (x.second != 0) {
                return false;
            }
        }

        return true;

        */
    }
};