/*

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.


Input: s = "()"
Output: true

Input: s = "()[]{}"
Output: true

Input: s = "(]"
Output: false

Constraints:
1 <= s.length <= 10^4
s consists of parentheses only '()[]{}'.

*/

#include <string>
#include <stack>
#include <unordered_map>

class _0020_ValidParentheses {
public:
    bool isValid(std::string s) {

        std::stack<char> open;
        std::unordered_map<char, char> parens = {
            {')', '('},
            {']', '['},
            {'}', '{'},
        };

        for (const auto& c : s) {

            if (parens.find(c) != parens.end()) // find() returns an iterator to the requested element, if it's not found then the 'end' iterator is returned
            { 
                // if input starts with a closing bracket.
                if (open.empty()) {
                    return false;
                }

                if (open.top() != parens[c]) {
                    return false;
                }

                open.pop();
            }
            else {
                open.push(c);
            }
        }

        return open.empty();
    }
};