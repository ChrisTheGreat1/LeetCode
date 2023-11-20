using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.

    Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the answer in any order.

    Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate 
    a queen and an empty space, respectively.

    Input: n = 4
    Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
    Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above

    Input: n = 1
    Output: [["Q"]]
 
    Constraints:

    1 <= n <= 9

    */

    // Can determine if a cell is within a positive or negative column by checking if the addition of row +/- column index remains constant
    internal class _0051_N_Queens
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            var result = new List<IList<string>>();
            IList<StringBuilder> board = new List<StringBuilder>();
            for (int i = 0; i < n; i++)
            {
                board.Add(new StringBuilder(n));
                board[i].Append('.', n);
            }
            backtrackingNQueens(n, 0, board, result, new HashSet<(int i, int j)>(), new HashSet<(int i, int j)>(), new HashSet<(int i, int j)>());
            return result;
        }

        private void backtrackingNQueens(int n, int row, IList<StringBuilder> board, List<IList<string>> result, HashSet<(int i, int j)> col, HashSet<(int i, int j)> positiveDiag, HashSet<(int i, int j)> negativeDiag)
        {
            if (n == 0)
            {
                result.Add(board.Select(s => s.ToString()).ToList());
                return;
            }
            if (row == board.Count) return;

            for (int c = 0; c < board.Count; c++)
            {
                (int i, int j) column = (0, c);
                int m = Math.Min(row, c);
                (int i, int j) diag1 = (row - m, c - m);
                m = Math.Min(row, board.Count - 1 - c);
                (int i, int j) diag2 = (row - m, c + m);

                if (col.Contains(column) || positiveDiag.Contains(diag1) ||
                   negativeDiag.Contains(diag2)) continue;

                col.Add(column);
                positiveDiag.Add(diag1);
                negativeDiag.Add(diag2);


                board[row][c] = 'Q';
                backtrackingNQueens(n - 1, row + 1, board, result, col, positiveDiag, negativeDiag);

                board[row][c] = '.';
                col.Remove(column);
                positiveDiag.Remove(diag1);
                negativeDiag.Remove(diag2);
            }
        }
    }
}
