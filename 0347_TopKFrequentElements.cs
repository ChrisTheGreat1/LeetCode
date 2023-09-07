using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
     
    Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

    Input: nums = [1,1,1,2,2,3], k = 2
    Output: [1,2]

    Input: nums = [1], k = 1
    Output: [1]
 

    Constraints:

    1 <= nums.length <= 10^5
    -10^4 <= nums[i] <= 10^4
    k is in the range [1, the number of unique elements in the array].
    It is guaranteed that the answer is unique.

    */

    internal class _0347_TopKFrequentElements
    {
        //var nums = new int[] { 1, 1, 1, 2, 2, 3 };
        //int k = 2;

        //var nums = new int[] { 1 };
        //int k = 1;

        //var nums = new int[] { 3, 0, 1, 0 };
        //int k = 1;

        //public int[] TopKFrequent(int[] nums, int k) 
        //{
        //    var resultArray = new int[k];
        //    var list = new List<(int, int)>();
        //    var unique = nums.Distinct();

        //    foreach (var key in unique)
        //    {
        //        var item1 = key;
        //        var item2 = nums.Where(x => x == key).Count();

        //        list.Add((item1, item2));
        //    }

        //    list = list.OrderByDescending(x => x.Item2).ToList();

        //    for(int i  = 0; i < k; i++)
        //    {
        //        resultArray[i] = list[i].Item1;
        //    }

        //    return resultArray;
        //}

        public int[] TopKFrequent(int[] nums, int k)
        {
            return nums.GroupBy(num => num)
            .OrderByDescending(num => num.Count())
            .Take(k)
            .Select(c => c.Key)
            .ToArray();
        }
    }
}
