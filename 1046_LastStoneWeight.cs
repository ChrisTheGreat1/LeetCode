using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

        You are given an array of integers stones where stones[i] is the weight of the ith stone.

        We are playing a game with the stones. On each turn, we choose the heaviest two stones 
        and smash them together. Suppose the heaviest two stones have weights x and y with x <= y. The result of this smash is:

        If x == y, both stones are destroyed, and
        If x != y, the stone of weight x is destroyed, and the stone of weight y has new weight y - x.
        At the end of the game, there is at most one stone left.

        Return the weight of the last remaining stone. If there are no stones left, return 0.


        Input: stones = [2,7,4,1,8,1]
        Output: 1
        Explanation: 
        We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,
        we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,
        we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,
        we combine 1 and 1 to get 0 so the array converts to [1] then that's the value of the last stone.

        Input: stones = [1]
        Output: 1

        Constraints:

        1 <= stones.length <= 30
        1 <= stones[i] <= 1000

*/

    internal class _1046_LastStoneWeight
    {
        // T: O(NLogN)
        public int LastStoneWeight(int[] stones)
        {
            // Priority queue is a min-heap by default. Therefore need to use the MaxHeapComparer to convert it to a max-heap
            var data = new PriorityQueue<int, int>(new MaxHeapComparer());

            foreach (var stone in stones)
            {
                // T: Heapify is O(N) for every enqueued item
                data.Enqueue(stone, stone);
            }

            // T: O(NLogN), to get max value its O(LogN) and we perform this for N items => O(NLogN)
            while (data.Count > 1)
            {
                var y = data.Dequeue();
                var x = data.Dequeue();

                if (x != y)
                {
                    var diff = y - x;
                    data.Enqueue(diff, diff);
                }
            }

            if (data.Count == 0)
            {
                return 0;
            }
            else
            {
                return data.Dequeue();
            }

        }

        public class MaxHeapComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }
    }
}
