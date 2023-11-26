using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
     
    You are given a stream of points on the X-Y plane. Design an algorithm that:

    Adds new points from the stream into a data structure. Duplicate points are allowed and should be treated as different points.
    Given a query point, counts the number of ways to choose three points from the data structure such that the three points and the query point form an axis-aligned square with positive area.
    An axis-aligned square is a square whose edges are all the same length and are either parallel or perpendicular to the x-axis and y-axis.

    Implement the DetectSquares class:

    DetectSquares() Initializes the object with an empty data structure.
    void add(int[] point) Adds a new point point = [x, y] to the data structure.
    int count(int[] point) Counts the number of ways to form axis-aligned squares with point point = [x, y] as described above.

    */
    internal class _2013_DetectSquares
    {
        public class DetectSquares
        {
            private Dictionary<(int x, int y), int> _pointsCounter = new();
            private List<(int x, int y)> _points = new();

            public DetectSquares() { }

            public void Add(int[] point)
            {
                var p = (point[0], point[1]);
                _points.Add(p);
                _pointsCounter[p] = 1 + _pointsCounter.GetValueOrDefault(p, 0);
            }

            public int Count(int[] point)
            {
                int px = point[0], py = point[1];
                int result = 0;

                foreach (var (x, y) in _points)
                {

                    if (Math.Abs(px - x) != Math.Abs(py - y)
                        || x == px || y == py)
                    {
                        continue;
                    }
                    result += _pointsCounter.GetValueOrDefault((px, y), 0) * _pointsCounter.GetValueOrDefault((x, py), 0);
                }
                return result;
            }
        }

        /**
         * Your DetectSquares object will be instantiated and called as such:
         * DetectSquares obj = new DetectSquares();
         * obj.Add(point);
         * int param_2 = obj.Count(point);
         */
    }
}
