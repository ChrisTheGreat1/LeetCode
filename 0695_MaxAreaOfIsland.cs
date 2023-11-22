using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    You are given an m x n binary matrix grid. An island is a group of 1's (representing land) 
    connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

    The area of an island is the number of cells with a value 1 in the island.

    Return the maximum area of an island in grid. If there is no island, return 0.
    
    Input: grid = [
    [0,0,1,0,0,0,0,1,0,0,0,0,0],
    [0,0,0,0,0,0,0,1,1,1,0,0,0],
    [0,1,1,0,1,0,0,0,0,0,0,0,0],
    [0,1,0,0,1,1,0,0,1,0,1,0,0],
    [0,1,0,0,1,1,0,0,1,1,1,0,0],
    [0,0,0,0,0,0,0,0,0,0,1,0,0],
    [0,0,0,0,0,0,0,1,1,1,0,0,0],
    [0,0,0,0,0,0,0,1,1,0,0,0,0]]
    Output: 6
    Explanation: The answer is not 11, because the island must be connected 4-directionally.


    Input: grid = [[0,0,0,0,0,0,0,0]]
    Output: 0

    Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 50
    grid[i][j] is either 0 or 1.

    */

    /*
    int[][] array = new int[][]
            {
                new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0},
                new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0},
                new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0},
                new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
                new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0}
            };
    */

    internal class _0695_MaxAreaOfIsland
    {
        private int maxArea;
        private int currentArea;

        public int MaxAreaOfIsland(int[][] grid)
        {
            var numRows = grid.Length;
            var numCols = grid[0].Length;

            if (numRows == 0 || numCols == 0) return 0;

            var visited = new HashSet<(int, int)>();
            maxArea = 0;

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (grid[row][col] == 0) continue;
                    currentArea = 0;
                    DFS(grid, row, col, numRows, numCols, visited);
                }
            }

            return maxArea;
        }

        private void DFS(
            int[][] grid,
            int row,
            int col,
            int numRows,
            int numCols,
            HashSet<(int, int)> visited)
        {
            if (row < 0 || row >= numRows) return;
            if (col < 0 || col >= numCols) return;
            if (visited.TryGetValue((row, col), out var _)) return;

            visited.Add((row, col));

            if (grid[row][col] == 1)
            {
                currentArea += 1;
                if (currentArea > maxArea)
                {
                    maxArea = currentArea;
                }

                DFS(grid, row + 1, col, numRows, numCols, visited);
                DFS(grid, row - 1, col, numRows, numCols, visited);
                DFS(grid, row, col + 1, numRows, numCols, visited);
                DFS(grid, row, col - 1, numRows, numCols, visited);
            }
        }
    }
}
