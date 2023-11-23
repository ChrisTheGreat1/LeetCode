using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean. 
    The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.

    The island is partitioned into a grid of square cells. You are given an m x n integer matrix heights
    where heights[r][c] represents the height above sea level of the cell at coordinate (r, c).

    The island receives a lot of rain, and the rain water can flow to neighboring cells directly 
    north, south, east, and west if the neighboring cell's height is less than or equal to the 
    current cell's height. Water can flow from any cell adjacent to an ocean into the ocean.

    Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water 
    can flow from cell (ri, ci) to both the Pacific and Atlantic oceans.

    Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
    Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
    Explanation: The following cells can flow to the Pacific and Atlantic oceans, as shown below:
    [0,4]: [0,4] -> Pacific Ocean 
           [0,4] -> Atlantic Ocean
    [1,3]: [1,3] -> [0,3] -> Pacific Ocean 
           [1,3] -> [1,4] -> Atlantic Ocean
    [1,4]: [1,4] -> [1,3] -> [0,3] -> Pacific Ocean 
           [1,4] -> Atlantic Ocean
    [2,2]: [2,2] -> [1,2] -> [0,2] -> Pacific Ocean 
           [2,2] -> [2,3] -> [2,4] -> Atlantic Ocean
    [3,0]: [3,0] -> Pacific Ocean 
           [3,0] -> [4,0] -> Atlantic Ocean
    [3,1]: [3,1] -> [3,0] -> Pacific Ocean 
           [3,1] -> [4,1] -> Atlantic Ocean
    [4,0]: [4,0] -> Pacific Ocean 
           [4,0] -> Atlantic Ocean
    Note that there are other possible paths for these cells to flow to the Pacific and Atlantic oceans.
   

    Input: heights = [[1]]
    Output: [[0,0]]
    Explanation: The water can flow from the only cell to the Pacific and Atlantic oceans.
 
    Constraints:

    m == heights.length
    n == heights[r].length
    1 <= m, n <= 200
    0 <= heights[r][c] <= 10^5

    */
    internal class _0417_PacificAtlanticWaterFlow
    {
        // Two solutions:

        // 1. Traverse through each cell of the grid using DFS/BFS and see if you can reach both oceans ( O(n*m)^2 )
        // 2. Only start at cells that border the oceans, then traverse through them and see if you can touch the other ocean ( O(n*m) )

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            List<IList<int>> res = new();
            int numRows = heights.Length;
            int numCols = heights[0].Length;

            bool[,] isPacific = new bool[numRows, numCols];
            bool[,] isAtlantic = new bool[numRows, numCols];

            // Run two loops so that you have a starting point at every outermost cell of the entire grid.

            for (int row = 0; row < numRows; row++)
            {
                DFSPacificAtlantic(row, 0, heights, isPacific, heights[row][0]); 
                DFSPacificAtlantic(row, numCols - 1, heights, isAtlantic, heights[row][numCols - 1]); 
            }

            for (int col = 0; col < numCols; col++)
            {
                DFSPacificAtlantic(0, col, heights, isPacific, heights[0][col]);
                DFSPacificAtlantic(numRows - 1, col, heights, isAtlantic, heights[numRows - 1][col]);
            }
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (isAtlantic[i, j] && isPacific[i, j])
                    {
                        res.Add(new List<int> { i, j });
                    }
                }
            }

            return res;
        }

        private void DFSPacificAtlantic(int row, int col, int[][] heights, bool[,] visits, int prev)
        {
            int m = heights.Length, n = heights[0].Length;
            if (row < 0 || row >= m || col < 0 || col >= n || visits[row, col] || heights[row][col] < prev)
            {
                return;
            }

            visits[row, col] = true;
            DFSPacificAtlantic(row, col + 1, heights, visits, heights[row][col]);
            DFSPacificAtlantic(row, col - 1, heights, visits, heights[row][col]);
            DFSPacificAtlantic(row + 1, col, heights, visits, heights[row][col]);
            DFSPacificAtlantic(row - 1, col, heights, visits, heights[row][col]);
        }
    }
}
