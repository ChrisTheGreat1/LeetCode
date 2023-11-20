using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
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

    internal class _0017_LetterCombinationsOfPhoneNumber
    {
        readonly Dictionary<char, char[]> keypad = new()
        {
            {'2', new char[]{'a', 'b', 'c'}},
            {'3', new char[]{'d', 'e', 'f'}},
            {'4', new char[] {'g', 'h', 'i'}},
            {'5', new char[] {'j', 'k', 'l'}},
            {'6', new char[] {'m', 'n', 'o'}},
            {'7', new char[] {'p', 'q', 'r', 's'}},
            {'8', new char[] {'t', 'u', 'v'}},
            {'9', new char[] {'w', 'x', 'y', 'z'}}
        };

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> combinations = new List<string>();

            if (digits.Length > 0) AddCombination("", digits, 0, combinations);

            return combinations;
        }

        private void AddCombination(string curr, string digits, int index, IList<string> combinations)
        {
            if (index >= digits.Length)
            {
                combinations.Add(curr);
            }
            else
            {
                char[] map = keypad[digits[index]];

                for (int i = 0; i < map.Length; i++)
                {
                    string newCurr = curr + map[i];

                    AddCombination(newCurr, digits, index + 1, combinations);
                }
            }
        }
    }
}