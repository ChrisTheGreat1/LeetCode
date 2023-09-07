using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
     
    Given an array of strings strs, group the anagrams together. You can return the answer in any order.

    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.


    Input: strs = ["eat","tea","tan","ate","nat","bat"]
    Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

    Input: strs = [""]
    Output: [[""]]

    Input: strs = ["a"]
    Output: [["a"]]
 

    Constraints:

    1 <= strs.length <= 10^4
    0 <= strs[i].length <= 100
    strs[i] consists of lowercase English letters.

    */

    internal class _0049_GroupAnagrams
    {
        //var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
        //var strs = new string[] { "" };
        //var strs = new string[] { "a" };

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var list = new List<(int, string)>();

            for(int i = 0; i < strs.Length; i++)
            {
                list.Add((i, String.Concat(strs[i].OrderBy(c => c))));
            }

            var orderedlist = list.GroupBy(x => x.Item2).ToList();
            var groupedList = new List<IList<string>>();

            foreach(var group in orderedlist)
            {
                var insideList = new List<string>();

                foreach(var item in group)
                {
                    insideList.Add(strs[item.Item1]);
                }

                groupedList.Add(insideList);
            }

            return groupedList;
        }
    }
}
