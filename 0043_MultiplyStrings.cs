using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.

    Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.


    Input: num1 = "2", num2 = "3"
    Output: "6"


    Input: num1 = "123", num2 = "456"
    Output: "56088"

    */
    internal class _0043_MultiplyStrings
    {
        public string Multiply(string num1, string num2)
        {
            if (string.Equals(num1, "0") || string.Equals(num2, "0"))
                return "0";
            var m = num1.Length;
            var n = num2.Length;

            var result = new int[m + n];

            num1 = Reverse(num1);
            num2 = Reverse(num2);

            for (var i1 = 0; i1 < num1.Length; i1++)
            {
                for (var i2 = 0; i2 < num2.Length; i2++)
                {

                    var digit = (num1[i1] - '0') * (num2[i2] - '0');
                    result[i1 + i2] += digit;
                    result[i1 + i2 + 1] += (result[i1 + i2]) / 10;
                    result[i1 + i2] = (result[i1 + i2]) % 10;
                }
            }

            Array.Reverse(result);
            var i = 0;
            while (i < result.Length && result[i] == 0)
            {
                i++;
            }

            var str = new StringBuilder();
            for (; i < result.Length; i++)
            {
                //Console.WriteLine(result[i]);
                str.Append(result[i]);
            }
            return str.ToString();

        }

        private string Reverse(string str)
        {
            var array = str.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
