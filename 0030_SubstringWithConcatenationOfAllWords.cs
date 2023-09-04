using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*

    You are given a string s and an array of strings words. All the strings of words are of the same length.

    A concatenated substring in s is a substring that contains all the strings of any permutation of words concatenated.

    For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated substring because it is not the concatenation of any permutation of words.
    Return the starting indices of all the concatenated substrings in s. You can return the answer in any order.

    Example 1:
    Input: s = "barfoothefoobarman", words = ["foo","bar"]
    Output: [0,9]
    Explanation: Since words.length == 2 and words[i].length == 3, the concatenated substring has to be of length 6.
    The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is a permutation of words.
    The substring starting at 9 is "foobar". It is the concatenation of ["foo","bar"] which is a permutation of words.
    The output order does not matter. Returning [9,0] is fine too.

    Example 2:
    Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
    Output: []
    Explanation: Since words.length == 4 and words[i].length == 4, the concatenated substring has to be of length 16.
    There is no substring of length 16 in s that is equal to the concatenation of any permutation of words.
    We return an empty array.

    Example 3:
    Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
    Output: [6,9,12]
    Explanation: Since words.length == 3 and words[i].length == 3, the concatenated substring has to be of length 9.
    The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"] which is a permutation of words.
    The substring starting at 9 is "barthefoo". It is the concatenation of ["bar","the","foo"] which is a permutation of words.
    The substring starting at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"] which is a permutation of words.

    Constraints:

    1 <= s.length <= 10^4
    1 <= words.length <= 5000
    1 <= words[i].length <= 30
    s and words[i] consist of lowercase English letters.

    //string s = "barfoothefoobarman";
    //var words = new string[] { "foo", "bar" };

    //string s = "wordgoodgoodgoodbestword";
    //var words = new string[] { "word", "good", "best", "word" };

    //string s = "barfoofoobarthefoobarman";
    //var words = new string[] { "bar", "foo", "the" };

    //string s = "";
    //var words = new string[] { "ab", "cd", "ef" };

    string s = "wordgoodgoodgoodbestword";
    var words = new string[] { "word", "good", "best", "good" };

    */

    internal class _0030_SubstringWithConcatenationOfAllWords
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();

            var permutations = GetPermutations(words.ToList(), words.Length).Select(x => String.Concat(x));

            foreach (var perm in permutations)
            {
                if (s.Contains(perm))
                {
                    result.Add(s.IndexOf(perm));
                }
            }

            return result;
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1).SelectMany(
                t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /*

        First a few notable properties of the problem:

        Every word is the same length.
        Words can repeat in the input.
        The problems looks for permutations, not combinations
        This means that if the input is ["foo", "bar"], then the substring "foofoobar" is valid.
        The result should report the starting index(es) only.

        Approach:
        The Sliding Window Algorithm approach seems appropriate, because we only have to check if the next n letters form a word from the input, where n is the length of the words in the input.

        The sliding window algorithm is a commonly used technique in computer science and data analysis. It involves defining a window or subset of data that "slides" along a larger dataset, with the purpose of extracting relevant information or performing calculations on the smaller window. The size of the window is one parameter that can be adjusted, depending on the specific task at hand.

        Explanation:
        The first step is to count how many times each word appears in the words array. We store this information in a dictionary called wordCount.

        To improve the performance, we use a sliding window approach. We examine each possible starting position within the length of a single word (wordLength).

        For each starting position, we create a window of a fixed length, substringLength, which represents the length of the concatenated substring.

        Inside this window, we keep track of the count of words we encounter using the currentWordCount dictionary. Additionally, we keep a tally of the total number of words found (wordsFound) and the index at the left side of the window (left).

        We iterate through the string s using steps of wordLength, moving the window one word length at a time.

        If the current word is present in the wordCount dictionary, we update the counts in currentWordCount and increment wordsFound. If the count of any word exceeds the required count, we adjust the left side of the window until the counts are balanced again.

        When we have found all the required words (wordsFound equals totalWords), we add the index at the left side of the window to the result. Then, we decrease the count for the word at the left side, decrement wordsFound, and move the left side of the window forward by one word length.

        If the current word is not present in the wordCount dictionary, it means the window is no longer valid. In this case, we reset the counts and move the left side of the window to the next valid position.

        Finally, we return the list of valid starting indices of the concatenated substrings as the result.

        Complexity
        Time complexity: O(N)O(N)O(N), where NNN is the length of the input string s.
        Space complexity: O(M)O(M)O(M), where MMM is the total number of characters in all the words combined.

        */

        //public IList<int> FindSubstring(string s, string[] words)
        //{
        //    IList<int> result = new List<int>();

        //    if (s.Length == 0 || words.Length == 0)
        //        return result;

        //    int wordLength = words[0].Length; // Length of each word in the words array
        //    int totalWords = words.Length; // Total number of words in the words array
        //    int substringLength = wordLength * totalWords; // Length of the concatenated substring

        //    if (s.Length < substringLength)
        //        return result;

        //    Dictionary<string, int> wordCount = new Dictionary<string, int>();

        //    // Count the occurrences of each word in the words array
        //    foreach (string word in words)
        //    {
        //        if (wordCount.ContainsKey(word))
        //            wordCount[word]++;
        //        else
        //            wordCount[word] = 1;
        //    }

        //    // Sliding window approach
        //    for (int i = 0; i < wordLength; i++)
        //    {
        //        Dictionary<string, int> currentWordCount = new Dictionary<string, int>(); // Track counts of words in the current window
        //        int wordsFound = 0; // Total number of words found in the current window
        //        int left = i; // Left index of the sliding window

        //        // Move the window one word length at a time
        //        for (int j = i; j <= s.Length - wordLength; j += wordLength)
        //        {
        //            string currentWord = s.Substring(j, wordLength);

        //            // If the current word is in the wordCount dictionary, update the counts
        //            if (wordCount.ContainsKey(currentWord))
        //            {
        //                if (currentWordCount.ContainsKey(currentWord))
        //                    currentWordCount[currentWord]++;
        //                else
        //                    currentWordCount[currentWord] = 1;

        //                wordsFound++;

        //                // Adjust the left index of the window if any word count exceeds the required count
        //                while (currentWordCount[currentWord] > wordCount[currentWord])
        //                {
        //                    string leftWord = s.Substring(left, wordLength);
        //                    currentWordCount[leftWord]--;
        //                    wordsFound--;
        //                    left += wordLength;
        //                }

        //                // If all words are found, add the left index to the result
        //                if (wordsFound == totalWords)
        //                {
        //                    result.Add(left);
        //                    string leftWord = s.Substring(left, wordLength);
        //                    currentWordCount[leftWord]--;
        //                    wordsFound--;
        //                    left += wordLength;
        //                }
        //            }
        //            // If the current word is not in the wordCount dictionary, reset the counts and move the left index
        //            else
        //            {
        //                currentWordCount.Clear();
        //                wordsFound = 0;
        //                left = j + wordLength;
        //            }
        //        }
        //    }

        //    return result;
        //}
    }
}