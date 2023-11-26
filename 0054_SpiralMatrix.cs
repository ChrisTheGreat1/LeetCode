using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an m x n matrix, return all elements of the matrix in spiral order.

    Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
    Output: [1,2,3,6,9,8,7,4,5]

    Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
    Output: [1,2,3,4,8,12,11,10,9,5,6,7]

    */
    internal class _0054_SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();
            int top = 0;
            int left = 0;
            int right = matrix[0].Length - 1;
            int bottom = matrix.Length - 1;

            while (true)
            {
                //Left to Right
                for (int i = left; i <= right; i++)
                {
                    result.Add(matrix[top][i]);
                }

                top++;

                if (left > right || top > bottom) break;

                //Top to Bottom
                for (int i = top; i <= bottom; i++)
                {
                    result.Add(matrix[i][right]);
                }

                right--;

                if (left > right || top > bottom) break;

                //Right to Left
                for (int i = right; i >= left; i--)
                {
                    result.Add(matrix[bottom][i]);
                }

                bottom--;

                if (left > right || top > bottom) break;

                //Bottom to Top
                for (int i = bottom; i >= top; i--)
                {
                    result.Add(matrix[i][left]);
                }

                left++;

                if (left > right || top > bottom) break;
            }//Repeat
            return result;
        }
    }
}
