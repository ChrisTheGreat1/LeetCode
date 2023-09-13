using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    You are given an m x n integer matrix matrix with the following two properties:

    Each row is sorted in non-decreasing order.
    The first integer of each row is greater than the last integer of the previous row.
    Given an integer target, return true if target is in matrix or false otherwise.

    You must write a solution in O(log(m * n)) time complexity.

    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
    Output: true

    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
    Output: false

    Constraints:
    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 100
    -10^4 <= matrix[i][j], target <= 10^4

    */
    internal class _0074_Search2dMatrix
    {
        //var nums = new int[][]
        //   {
        //                   new int[] {1, 3, 5, 7},
        //                   new int[] {10, 11, 16, 20},
        //                   new int[] {23, 30, 34, 60}
        //   };
        //var target = 3;
        //var target = 13;

        // Treats the matrix as a 1D array.
        // Can alternatively solve it by binary search checking if target falls between first and last value of the "middle" matrix row that is being evaluated.
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int left = 0, right = m * n - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int mid_val = matrix[mid / n][mid % n];

                if (mid_val == target)
                    return true;
                else if (mid_val < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return false;
        }
    }
}
