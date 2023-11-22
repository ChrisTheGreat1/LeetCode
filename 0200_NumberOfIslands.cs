using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

    An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
    You may assume all four edges of the grid are all surrounded by water.

    Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
    ]
    Output: 1


    Input: grid = [
        ["1","1","0","0","0"],
        ["1","1","0","0","0"],
        ["0","0","1","0","0"],
        ["0","0","0","1","1"]
    ]
    Output: 3
 

    Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 300
    grid[i][j] is '0' or '1'.

    */

    /*

        char[][] grid = new char[][]
        {
            new char[] {'1', '1', '1', '1', '0'},
            new char[] {'1', '1', '0', '1', '0'},
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'0', '0', '0', '0', '0'}
        };

    */

internal class _0200_NumberOfIslands
{
    public int NumIslands(char[][] grid)
    {
        var numRows = grid.Length;
        var numCols = grid[0].Length;
        var visited = new bool[numRows, numCols]; // Creates a 2D array of false booleans
        var numIslands = 0;

        // Perform this loop to ensure that each cell gets visited atleast once.
        // If you finished iterating through all the land pieces of a single island,
        // this loop is how you can start looping through the water tiles until you find
        // the next undiscovered island tile.
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                if (visited[i, j] == false && grid[i][j] == '1')
                {
                    numIslands++;

                    // Use the call stack as your stack and keep navigating through
                    // each neighbour that is possible to navigate to if you are currently on an island
                    dfs(i, j, grid);                  
                }
            }
        }
        return numIslands;

        void dfs(int row, int col, char[][] grid)
        {
            if (row < 0 || row >= numRows) return;
            if (col < 0 || col >= numCols) return;
            if (visited[row, col] == true || grid[row][col] == '0') return;

            visited[row, col] = true;

            // The call stack is your DFS stack. Traverse through each neighbour tile relative to the current tile.
            dfs(row + 1, col, grid);
            dfs(row - 1, col, grid);
            dfs(row, col - 1, grid);
            dfs(row, col + 1, grid);
        }
    }
}
}
