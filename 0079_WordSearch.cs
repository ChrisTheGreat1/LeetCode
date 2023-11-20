using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an m x n grid of characters board and a string word, return true if word exists in the grid.

    The word can be constructed from letters of sequentially adjacent cells, 
    where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.

    Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
    Output: true

    Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
    Output: true

    Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
    Output: false
 
    Constraints:

    m == board.length
    n = board[i].length
    1 <= m, n <= 6
    1 <= word.length <= 15
    board and word consists of only lowercase and uppercase English letters.

    */

    internal class _0079_WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            var rows = board.Length;
            var cols = board[0].Length;
            var visited = new bool[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (board[i][j] == word[0] && search(i, j, 0, word, board, visited))
                        return true;
                }
            }

            return false;
        }

        public bool search(int r, int c, int index, string word, char[][] board, bool[,] visited)
        {
            var rows = board.Length;
            var cols = board[0].Length;

            if (index == word.Length) return true;

            if (r < 0) return false;
            if (c < 0) return false;
            if (r >= rows) return false;
            if (c >= cols) return false;
            if (word[index] != board[r][c]) return false;
            if (visited[r, c]) return false;

            visited[r, c] = true;
            var result = 
                search(r + 1, c, index + 1, word, board, visited) ||
                search(r - 1, c, index + 1, word, board, visited) ||
                search(r, c + 1, index + 1, word, board, visited) ||
                search(r, c - 1, index + 1, word, board, visited);

            visited[r, c] = false;
            return result;
        }
    }
}
