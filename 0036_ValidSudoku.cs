using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _0036_ValidSudoku
    {
        /*
         
        Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

        Each row must contain the digits 1-9 without repetition.
        Each column must contain the digits 1-9 without repetition.
        Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        
        Note:
        A Sudoku board (partially filled) could be valid but is not necessarily solvable.
        Only the filled cells need to be validated according to the mentioned rules.

        Input: board = 
        [["5","3",".",".","7",".",".",".","."]
        ,["6",".",".","1","9","5",".",".","."]
        ,[".","9","8",".",".",".",".","6","."]
        ,["8",".",".",".","6",".",".",".","3"]
        ,["4",".",".","8",".","3",".",".","1"]
        ,["7",".",".",".","2",".",".",".","6"]
        ,[".","6",".",".",".",".","2","8","."]
        ,[".",".",".","4","1","9",".",".","5"]
        ,[".",".",".",".","8",".",".","7","9"]]
        Output: true

        Input: board = 
        [["8","3",".",".","7",".",".",".","."]
        ,["6",".",".","1","9","5",".",".","."]
        ,[".","9","8",".",".",".",".","6","."]
        ,["8",".",".",".","6",".",".",".","3"]
        ,["4",".",".","8",".","3",".",".","1"]
        ,["7",".",".",".","2",".",".",".","6"]
        ,[".","6",".",".",".",".","2","8","."]
        ,[".",".",".","4","1","9",".",".","5"]
        ,[".",".",".",".","8",".",".","7","9"]]
        Output: false
        Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.
 

        Constraints:

        board.length == 9
        board[i].length == 9
        board[i][j] is a digit 1-9 or '.'.

        */

        /*
        // First attempt, does not work.
        public bool IsValidSudoku(char[][] board)
        {
            // Check groups of 3
            for(int partition = 0; partition < 7; partition += 3)
            {
                var temp1 = new HashSet<char>();
                var temp2 = new HashSet<char>();

                for (int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        if (board[i + partition][j] == '.') continue;
                        if (board[i][j + partition] == '.') continue;

                        if(temp1.Contains(board[i + partition][j]) || temp2.Contains(board[i][j + partition]))
                        {
                            return false;
                        }
                        else
                        {
                            temp1.Add(board[i + partition][j]);
                            temp2.Add(board[i][j + partition]);
                        }
                    }
                }
            }

            // Check rows & columns
            for (int i = 0; i < 9; i++)
            {
                var temp1 = new HashSet<char>();
                var temp2 = new HashSet<char>();

                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.') continue;
                    if (board[j][i] == '.') continue;

                    if (temp1.Contains(board[i][j]) || temp2.Contains(board[j][i]))
                    {
                        return false;
                    }
                    else
                    {
                        temp1.Add(board[i][j]);
                        temp2.Add(board[j][i]);
                    }
                }
            }

            return true;
        }
        */

        public bool IsValidSudoku(char[][] board)
        {
            //Time - O(n) as we traverse entire array twice
            //Space - O(1)

            //First going through entire rows and columns
            for (int i = 0; i < board.Length; i++)
            {
                HashSet<int> rowRecords = new HashSet<int>();
                HashSet<int> colRecords = new HashSet<int>();
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        if (rowRecords.Contains(board[i][j])) return false;
                        rowRecords.Add(board[i][j]);
                    }
                    if (board[j][i] != '.')
                    {
                        if (colRecords.Contains(board[j][i])) return false;
                        colRecords.Add(board[j][i]);
                    }
                }
            }

            //Checking each 3x3 square for duplicates
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    HashSet<int> sqRecords = new HashSet<int>();
                    for (int m = i; m < i + 3; m++)
                    {
                        for (int n = j; n < j + 3; n++)
                        {
                            if (board[m][n] == '.') continue;
                            if (sqRecords.Contains(board[m][n])) return false;
                            sqRecords.Add(board[m][n]);
                        }
                    }
                    j += 2;
                }
                i += 2;
            }

            return true;
        }
    }
}
