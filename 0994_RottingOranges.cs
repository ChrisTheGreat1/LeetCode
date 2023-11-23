using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    You are given an m x n grid where each cell can have one of three values:

    0 representing an empty cell,
    1 representing a fresh orange, or
    2 representing a rotten orange.
    Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

    Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.

    Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
    Output: 4


    Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
    Output: -1
    Explanation: The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.


    Input: grid = [[0,2]]
    Output: 0
    Explanation: Since there are already no fresh oranges at minute 0, the answer is just 0.
 

    Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 10
    grid[i][j] is 0, 1, or 2.

    */

    internal class _0994_RottingOranges
    {
        // BFS solution
        public int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid[0].Length == 0)
                return 0;

            int numRows = grid.Length, numCols = grid[0].Length, numFresh = 0, time = 0;

            Queue<(int, int)> queue = new Queue<(int, int)>();

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (grid[row][col] == 1)
                        numFresh++;
                    else if (grid[row][col] == 2)
                    {
                        queue.Enqueue((row, col));
                    };
                }
            }

            if (numFresh == 0)
                return 0;

            int[,] dir = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
            while (queue.Any())
            {
                time++;
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var curr = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        int row = curr.Item1 + dir[j, 0];
                        int col = curr.Item2 + dir[j, 1];

                        if (row >= 0 && row < numRows && col >= 0 && col < numCols && grid[row][col] == 1)
                        {
                            grid[row][col] = 2;
                            queue.Enqueue((row, col));
                            numFresh--;
                        }
                    }
                }
            }

            return numFresh == 0 ? time - 1 : -1;
        }
    }
}
