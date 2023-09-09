using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _0238_ProductOfArrayExceptSelf
    {
        /*
         
        Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

        The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

        You must write an algorithm that runs in O(n) time and without using the division operation.


        Input: nums = [1,2,3,4]
        Output: [24,12,8,6]

        Input: nums = [-1,1,0,-3,3]
        Output: [0,0,9,0,0]

        Constraints:

        2 <= nums.length <= 10^5
        -30 <= nums[i] <= 30
        The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

        */

        //var nums = new int[] { 1, 2, 3, 4 };
        //var nums = new int[] { -1, 1, 0, -3, 3 };

        /*
        // Exceeds time limit
        public int[] ProductExceptSelf(int[] nums)
        {
            var answer = new int[nums.Length];

            for(int i = 0; i < nums.Length; i++)
            {
                var temp = nums.ToList();
                temp.RemoveAt(i);

                for(int j = 0; j < temp.Count; j++)
                {
                    if(j == 0)
                    {
                        answer[i] = temp[j];
                    }
                    else
                    {
                        answer[i] *= temp[j];
                    }
                }
            }

            return answer;
        }
        */

        public int[] ProductExceptSelf(int[] nums)
        {
            var answer = new int[nums.Length];

            for (int i = 0, prev = 1; i < nums.Length; i++)
            {
                answer[i] = prev;
                prev = nums[i] * prev;
            }

            for (int i = nums.Length - 1, prev = 1; i >= 0; i--)
            {
                answer[i] = answer[i] * prev;
                prev = nums[i] * prev;
            }

            return answer;
        }
    }
}
