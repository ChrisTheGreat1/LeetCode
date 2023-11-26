using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

    You must do it in place.

    */
    internal class _0073_SetMatrixZeroes
    {
        public void SetZeroes(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            bool firstRowHasZeros = matrix[0].Contains(0);

            for (int i = 1; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (matrix[i][j] == 0)
                        matrix[i][0] = matrix[0][j] = 0;

            for (int i = 1; i < m; i++)
                if (matrix[i][0] == 0)
                    Array.Fill(matrix[i], 0);

            for (int j = 0; j < n; j++)
                if (matrix[0][j] == 0)
                    for (int i = 0; i < m; i++)
                        matrix[i][j] = 0;

            if (firstRowHasZeros)
                Array.Fill(matrix[0], 0);
        }
    }
}
