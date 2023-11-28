using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    

    Alice has some number of cards and she wants to rearrange the cards into groups so that each group is of size groupSize, and consists of groupSize consecutive cards.

    Given an integer array hand where hand[i] is the value written on the ith card and an integer groupSize, return true if she can rearrange the cards, or false otherwise.


    Input: hand = [1,2,3,6,2,3,4,7,8], groupSize = 3
    Output: true
    Explanation: Alice's hand can be rearranged as [1,2,3],[2,3,4],[6,7,8]


    Input: hand = [1,2,3,4,5], groupSize = 4
    Output: false
    Explanation: Alice's hand can not be rearranged into groups of 4.

 

    Constraints:

    1 <= hand.length <= 10^4
    0 <= hand[i] <= 10^9
    1 <= groupSize <= hand.length

    */

    internal class _0846_HandOfStraights
    {
        //T: O(logN) for min heap, N is for all the items-> so overall O(NlogN)
        public bool IsNStraightHand(int[] hand, int groupSize)
        {
            if (hand.Length % groupSize != 0)
                return false;

            var dictionary = new Dictionary<int, int>();
            var minHeap = new PriorityQueue<int, int>();

            foreach (var item in hand)
            {
                dictionary.TryAdd(item, 0);
                dictionary[item]++;
            }

            // heapify is linear algorithm
            foreach (var key in dictionary.Keys)
                minHeap.Enqueue(key, key);

            while (minHeap.Count > 0)
            {
                var first = minHeap.Peek();

                for (var i = first; i < first + groupSize; i++)
                {
                    if (!dictionary.ContainsKey(i))
                        return false;

                    dictionary[i]--;
                    if (dictionary[i] == 0)
                        if (i != minHeap.Peek())
                            return false;
                        else
                            minHeap.Dequeue();
                }

            }

            return true;
        }
    }
}
