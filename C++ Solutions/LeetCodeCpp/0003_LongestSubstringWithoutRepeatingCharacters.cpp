// Given a string s, find the length of the longest substring without repeating characters.

#include <vector>
#include <stack>
#include <string>
#include <unordered_set>

using namespace std;

class _0003_LongestSubstringWithoutRepeatingCharacters {
public:
    int lengthOfLongestSubstring(string& s) {
        unordered_set<char> chars;
        int maxSize = 0;
        int i = 0, j = 0;
        while (j < s.size()) {
            while (chars.find(s[j]) != chars.end()) {
                chars.erase(s[i]);
                ++i;
            }
            maxSize = max(maxSize, j - i + 1);
            chars.insert(s[j]);
            ++j;
        }
        return maxSize;
    }
};