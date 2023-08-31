namespace LeetCode
{
    // Given a string s, find the length of the longest substring without repeating characters.
    internal class _0003_LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string inputString)
        {
            int pointerA = 0;
            int pointerB = 0;
            int max = 0;
            var hash_set = new HashSet<char>();

            while (pointerA < inputString.Length)
            {
                if (!hash_set.Contains(inputString[pointerA]))
                {
                    hash_set.Add(inputString[pointerA]);
                    pointerA++;
                    max = Math.Max(hash_set.Count, max);
                }
                else
                {
                    hash_set.Remove(inputString[pointerB]);
                    pointerB++;
                }
            }

            return max;
        }
    }
}