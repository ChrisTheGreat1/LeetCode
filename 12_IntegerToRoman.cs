using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

    Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

    Symbol       Value
    I             1
    V             5
    X             10
    L             50
    C             100
    D             500
    M             1000

    For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

    Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

    I can be placed before V (5) and X (10) to make 4 and 9.
    X can be placed before L (50) and C (100) to make 40 and 90.
    C can be placed before D (500) and M (1000) to make 400 and 900.
    Given an integer, convert it to a roman numeral.

    Input: num = 3
    Output: "III"
    Explanation: 3 is represented as 3 ones.

    Input: num = 58
    Output: "LVIII"
    Explanation: L = 50, V = 5, III = 3.

    Input: num = 1994
    Output: "MCMXCIV"
    Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

    Constraints:

    1 <= num <= 3999

    */

    // This problem would be easy if there weren't the special cases of 4/9/40/90/400/900 since you could just do
    // straight integer division/modulo on the regular letters and find the result that way.

    // But since there are the special cases, just add them to the list of "regular letters"

    internal class _12_IntegerToRoman
    {
        /*

        Symbol       Value
        I             1
        IV            4
        V             5
        IX            9
        X             10
        XL            40
        L             50
        XC            90
        C             100
        CD            400
        D             500
        CM            900
        M             1000

        */

        private readonly List<(int integerNumeral, string romanNumeral)> IntToRomanList = new()
        {
                (1000, "M"),
                (900, "CM"),
                (500, "D"),
                (400, "CD"),
                (100, "C"),
                (90, "XC"),
                (50, "L"),
                (40, "XL"),
                (10, "X"),
                (9, "IX"),
                (5, "V"),
                (4, "IV"),
                (1, "I"),
        };

        public string IntToRoman(int num)
        {
            var sb = new StringBuilder();
            int remaining = num;

            foreach (var (integerNumeral, romanNumeral) in IntToRomanList)
            {
                if (remaining == 0) break;

                var dividedResult = remaining / integerNumeral;

                if (dividedResult == 0) continue;

                for (int i = 0; i < dividedResult; i++)
                {
                    sb.Append(romanNumeral);
                }

                remaining %= integerNumeral;
            }

            return sb.ToString();
        }
    }
}