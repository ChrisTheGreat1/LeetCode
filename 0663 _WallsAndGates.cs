using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    You are given a m x n 2D grid initialized with these three possible values.

    -1 - A wall or an obstacle.
    0 - A gate.
    INF - Infinity means an empty room. We use the value 2^31 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than 2147483647.
    Fill each empty room with the distance to its nearest gate. If it is impossible to reach a Gate, that room should remain filled with INF

    */

    internal class _0663__WallsAndGates
    {
        // Perform a BFS starting from each gate position (initialize the queue with the gates).
        // Then run concurrent BFS from each gate starting position, if the cell has already been counted in 
        // another BFS then don't count it again

        private Queue<(int, int)> queue = new Queue<(int, int)>();
        private int numRows;
        private int numCols;


        public void WallsAndGates(int[][] rooms)
        {
            numRows = rooms.Length;
            numCols = rooms[0].Length;
            var visited = new int[numRows, numCols];


            void addRoom(int row, int col)
            {
                if (row < 0 || col < 0 || row == numRows || col == numCols || rooms[row][col] == -1 || visited[row, col] == 1)
                    return;

                visited[row, col] = 1;
                queue.Enqueue((row, col));
            }

            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numCols; j++)
                {
                    if (rooms[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                        visited[i, j] = 1;
                    }
                }
            }

            var currentDistance = 0;
            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (var i = 0; i < count; i++)
                {
                    var (row, col) = queue.Dequeue();
                    rooms[row][col] = currentDistance;
                    addRoom(row + 1, col);
                    addRoom(row - 1, col);
                    addRoom(row, col + 1);
                    addRoom(row, col - 1);

                }

                currentDistance++;
            }

        }
    }
}
