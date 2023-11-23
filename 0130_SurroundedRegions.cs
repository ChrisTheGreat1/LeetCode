using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an m x n matrix board containing 'X' and 'O', capture all regions that are 4-directionally surrounded by 'X'.

    A region is captured by flipping all 'O's into 'X's in that surrounded region.

    Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
    Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]
    Explanation: Notice that an 'O' should not be flipped if:
    - It is on the border, or
    - It is adjacent to an 'O' that should not be flipped.
    The bottom 'O' is on the border, so it is not flipped.
    The other three 'O' form a surrounded region, so they are flipped.

    Input: board = [["X"]]
    Output: [["X"]]
 
    Constraints:

    m == board.length
    n == board[i].length
    1 <= m, n <= 200
    board[i][j] is 'X' or 'O'.

    */
    internal class _0130_SurroundedRegions
    {
        // "O" tiles on border are guaranteed to not be flipped. So you can just run a DFS on all of the border "O" and any connected
        // O's are part of the solution set

        public void Solve(char[][] board)
        {
            var numRows = board.Length;

            if (numRows == 0) return;
            var numCols = board[0].Length;

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    // Only run DFS on outside border cells that have value "O"
                    if ((row == 0 || col == 0 || row == numRows - 1 || col == numCols - 1) && board[row][col] == 'O')
                    {
                        CaptureDfs(board, row, col);
                    }
                }
            }

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                }
            }

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (board[i][j] == 'T')
                    {
                        board[i][j] = 'O';
                    }
                }
            }
        }

        private void CaptureDfs(char[][] board, int x, int y)
        {
            var n = board.Length;
            var m = board[0].Length;

            if (x >= n || x < 0 || y >= m || y < 0)
            {
                return;
            }

            if (board[x][y] == 'T' || board[x][y] == 'X') return;

            board[x][y] = 'T'; // Temp value so that after the entire loop is completed, you can change anything not part of the solution set to an X
            CaptureDfs(board, x + 1, y);
            CaptureDfs(board, x - 1, y);
            CaptureDfs(board, x, y + 1);
            CaptureDfs(board, x, y - 1);

        }
    }
}
