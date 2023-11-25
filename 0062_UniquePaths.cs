using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). 
    The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). 
    The robot can only move either down or right at any point in time.

    Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.

    The test cases are generated so that the answer will be less than or equal to 2 * 109.

    Input: m = 3, n = 7
    Output: 28


    Input: m = 3, n = 2
    Output: 3
    Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
    1. Right -> Down -> Down
    2. Down -> Down -> Right
    3. Down -> Right -> Down
 

    Constraints:

    1 <= m, n <= 100

    */
    internal class _0062_UniquePaths
    {
        // Imagine filling in grid with number of ways to reach that specific cell. The result is the addition of the results of the
        // surrounding cells.

        public int UniquePaths(int m, int n)
        {
            var row = new int[n]; // Want to use number of columns to satisfy the base case of the below line
            Array.Fill(row, 1); // Populate with one's since there is always only 1 path to reach the cells in the top or bottom row

            for (int i = 0; i < m - 1; i++)
            {
                var newRow = new int[n];
                Array.Fill(newRow, 1);

                for (int j = n - 2; j >= 0; j--)
                {
                    newRow[j] = newRow[j + 1] + row[j];
                }

                row = newRow;
            }

            return row[0];
        }
    }
}
