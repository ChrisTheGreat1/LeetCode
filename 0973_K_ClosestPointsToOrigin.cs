using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    
    Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane and an integer k, 
    return the k closest points to the origin (0, 0).

    The distance between two points on the X-Y plane is the Euclidean distance (i.e., √(x1 - x2)^2 + (y1 - y2)^2).

    You may return the answer in any order. The answer is guaranteed to be unique (except for the order that it is in).

    Input: points = [[1,3],[-2,2]], k = 1
    Output: [[-2,2]]
    Explanation:
    The distance between (1, 3) and the origin is sqrt(10).
    The distance between (-2, 2) and the origin is sqrt(8).
    Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
    We only want the closest k = 1 points from the origin, so the answer is just [[-2,2]].


    Input: points = [[3,3],[5,-1],[-2,4]], k = 2
    Output: [[3,3],[-2,4]]
    Explanation: The answer [[-2,4],[3,3]] would also be accepted.

    Constraints:

    1 <= k <= points.length <= 10^4
    -10^4 <= xi, yi <= 10^4

    */

    // [[3,3],[5,-1],[-2,4]]
    //var points = new int[][] { new int[] { 3, 3 }, new int[] { 5, -1 }, new int[] { -2, 4 } };

    // [1,3],[-2,2]
    //var points = new int[][] { new int[] { 1, 3 }, new int[] { -2, 2 } };

    internal class _0973_K_ClosestPointsToOrigin
    {
        public int[][] KClosest(int[][] points, int k)
        {
            // Create min heap
            var data = new PriorityQueue<int, double>();
            int[][] result = new int[k][];

            for (int i = 0; i < points.Length; i++)
            {
                var x = points[i][0];
                var y = points[i][1];

                var mag = Math.Sqrt(x * x + y * y);

                data.Enqueue(i, mag);
            }

            for (int i = 0; i < k; i++)
            {
                var index = data.Dequeue();

                result[i] = new int[2];  // Initialize the inner array
                result[i][0] = points[index][0];
                result[i][1] = points[index][1];
            }

            return result;
        }
    }
}
